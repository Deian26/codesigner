using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoDesigner_IDE
{
    #region abstract-sim-elements
    /// <summary>
    /// Abstract class used as a base for all abstract simulation elements
    /// </summary>
    public abstract class AbstractSimElement
    {
        public string name { get; }

        public string description { get; }

        public int blueprintIndex { get; }

        public Image img { get; } // blueprint and concrete element image

        public Type concreteType { get; } // concrete type to be instantiated when a concrete element is created based on this abstract element
        /// <summary>
        /// Instantiates a new Abstract element; used when creating blueprints
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="blueprintIndex"></param>
        /// <param name="imageFilePath"></param>
        /// <param name="concreteType"></param>
        public AbstractSimElement(string name, string description, int blueprintIndex, string imageFilePath, Type concreteType) 
        {
            this.name = name;
            this.description = description;
            this.blueprintIndex = blueprintIndex;

            //load image, if a valid file path and format was given; otherwise, a default image will be displayed for the component
            try
            {
                this.img = Image.FromFile(imageFilePath);
            }
            catch // load default image
            {
                this.img = Image.FromFile(SimulationManager.SIM_ABSTRACT_ELEMENT_DEF_IMG_FILEPATH);
            }

            // add the image to the global image list
            SimulationManager.BlueprintImagelist.Images.Add(name, img); // key = the name of the abstract element

            this.concreteType = concreteType;
        }   

    }

    /// <summary>
    /// Defines the hardware basics of a transport protocol
    /// </summary>
    public class AbstractTransportMedium : AbstractSimElement
    {
        
        public int parallel_bits { get; } // parallel data lines
        public bool selection { get; } // medium selection

        public AbstractTransportMedium(string name, string description, int blueprintIndex, string imageFilePath, // base
            int parallel_bits, bool selection) 
            : base(name, description, blueprintIndex, imageFilePath, typeof(ConcreteTransportMedium))
        {
            this.parallel_bits = parallel_bits;
            this.selection = selection;
        }
    }

    /// <summary>
    /// Defines an 'AbstractMicroprocessor' abstract simulation element
    /// </summary>
    public class AbstractMicroprocessor : AbstractSimElement
    {
        /// <summary>
        /// Defines a port, part of a microprocessor
        /// </summary>
        public class Port
        {
            public string name { get; }
            public List<AbstractTransportMedium> transport_mediums { get; } // transport mediums supported by this port

            /// <summary>
            /// Creates a new abstract port, to be added to a uC simulation element's blueprint 
            /// </summary>
            /// <param name="name"> Unique </param>
            /// <param name="transport_mediums"> Supported transport mediums </param>
            public Port(string name, List<AbstractTransportMedium> transport_mediums)
            {
                this.name = name;
                this.transport_mediums = transport_mediums;
            }
        }

        // AbstractMicroprocessor details
        public bool supports_floating_point { get; }
        public bool supports_programming_point { get; }
        public List<Port> ports { get; } // the list of this AbstractMicroprocessor's ports

        /// <summary>
        /// Construct the blueprint of a microprocessor simulation element
        /// </summary>
        /// <param name="name"> Unique, formal name </param>
        /// <param name="supports_floating_point"> If True, this AbstractMicroprocessor supports floating-point operations </param>
        /// <param name="ports"> A list of ports contained by this AbstractMicroprocessor </param>
        public AbstractMicroprocessor(string name, string description, int blueprintIndex, string imageFilePath, // base
            bool supports_floating_point, bool supports_programming_point, List<Port> ports) 
            : base(name, description, blueprintIndex, imageFilePath, typeof(ConcreteMicroprocessor))
        {
            this.supports_floating_point = supports_floating_point;
            this.supports_programming_point = supports_programming_point;
            this.ports = ports;
        }
    }

    /// <summary>
    /// Defines a logical input
    /// </summary>
    public class AbstractLogicalInput : AbstractSimElement
    {
        public AbstractLogicalInput(string name, string description, int blueprintIndex, string imageFilePath // base
            ) 
            : base(name, description, blueprintIndex, imageFilePath, typeof(ConcreteLogicalInput))
        {

        }
    }

    /// <summary>
    /// Defines a logical output
    /// </summary>
    public class AbstractLogicalOutput : AbstractSimElement
    {
        public AbstractLogicalOutput(string name, string description, int blueprintIndex, string imageFilePath // base
            ) 
            : base(name, description, blueprintIndex, imageFilePath, typeof(ConcreteLogicalOutput))
        {

        }
    }

    #endregion

    #region concrete-sim-elements
    /// <summary>
    /// Defines a concrete element (the instance of an abstract element); an abstract element can be used to create multiple concrete-elements
    /// This is used as a base class for all concrete elements.
    /// </summary>
    public abstract class ConcreteElement
    {
        public AbstractSimElement abstractElement {  get; } // the abstract element on which this concrete element is based
        public string name { get; } // concrete name
        public int simElementId { get; } // element ID, unique within the simulation; bitcoded:
                                  //    byte0 = simulation number
                                  //    bytes 1-3 = element number within the simulation (incremented from 0, with each new element added)
        public byte simNr { get; }
        public int simElementNr { get; }
        public Point location { get; set; } // element location in the simulation window

        // display elements
        public PictureBox elementDisplay { get; } = new PictureBox(); // visual representation of the element
        private ToolTip toolTip { get; } = new ToolTip();
        public string elementSummary { get; } // a summary of this element's role

        /// <summary>
        /// Create a new concrete element
        /// </summary>
        /// <param name="abstractElement"> Blueprint for this component </param>
        /// <param name="name"> Concrete name </param>
        /// <param name="simNr"> The number of the simulation containing this concrete element </param>
        /// <param name="simElementNr"> This element's number in the containing simulation </param>
        /// <param name="location"> The location of the concrete element in the simulation form </param>
        public ConcreteElement(AbstractSimElement abstractElement, string name, byte simNr, int simElementNr, Point location)
        {
            this.abstractElement = abstractElement;
            this.name = name;
            this.simNr = simNr;
            this.simElementNr = simElementNr;
            this.simElementId = (simNr<<24) | simElementNr; // compute simulation element ID
            this.location = location;

            // construct display elements
            this.elementSummary = $"FileNameAndExt: {this.name}\n"+
                                  $"Blueprint: {this.abstractElement.name}\n"+
                                  $"Element ID {this.simElementId}";

            // configure the main display element
            this.toolTip.SetToolTip(this.elementDisplay, this.elementSummary); // display element summary on mouse hover
            
            this.elementDisplay.Font = Customization.DefaultFonts.DefaultFont;
            this.elementDisplay.Text = this.name;
            this.elementDisplay.BorderStyle = BorderStyle.FixedSingle;
            this.elementDisplay.MaximumSize = this.elementDisplay.MinimumSize = this.elementDisplay.Size;
            this.elementDisplay.BackColor = Color.LightGoldenrodYellow;
            this.elementDisplay.Location = this.location;
            this.elementDisplay.Visible = true;
        }

        /// <summary>
        /// Return the element's summary
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.elementSummary;
        }
    }

    /// <summary>
    /// Defines a concrete transport medium element
    /// </summary>
    public class ConcreteTransportMedium : ConcreteElement
    {
        public Color color { get; set; }

        public ConcreteTransportMedium(AbstractSimElement abstractElement, string name, byte simNr, int simElementNr, Point location) // base 
            : base(abstractElement, name, simNr, simElementNr, location) // concrete element details
            {

            }
    }

    /// <summary>
    /// Defines a concrete uP element
    /// </summary>
    public class ConcreteMicroprocessor : ConcreteElement
    {
        public ConcreteMicroprocessor( AbstractSimElement abstractElement, string name, byte simNr, int simElementNr, Point location // base concrete element details
            ) // concrete uP details 
            : base(abstractElement, name, simNr, simElementNr, location)
        {

        }
    }


    /// <summary>
    /// Defines a concrete logical input which sends values to other simulation elements
    /// </summary>
    public class ConcreteLogicalInput : ConcreteElement
    {
        /// <summary>
        /// Defines objects that generate signals (waves)
        /// </summary>
        internal class SignalGenerator
        {
            #region function-delegate-types
            /// <summary>
            /// // the signature of the functions used to compute signal values; the function will return y = f(x), for the given 'x'
            /// </summary>
            /// <param name="x"> Function input (f(x)) </param>
            /// <returns></returns>
            public delegate double SignalGeneratorFunctionType(double x);
            
            #endregion

            #region signal-generator-specifications
            private SignalGeneratorFunctionType signalFunction = null; // actual function for this signal generator
            private double x { get; set; } // current input for f(x)
            private double start { get; } // value domain start
            private double stop { get; } // value domain end
            private double step { get;} // step for parsing the value domain; the 'x' Variable is incremented by this value at every simulation tick event
            private int precision { get; } // the number of digits to take into account when outputting a real the result; is set to 1 if the representedType is set to 'int'
            private Type representedType { get; } // the representation of the returned value; all return values are real, but if this Variable marks the 'int' type, then
                                                  // the y value would be rounded, using the first digit after the comma, to the next integer, away from 0 (e.g., if y = 1.912,
                                                  // but the numeric type is an integer, then the value returned would be 2.0)
            #endregion

            /// <summary>
            /// Creates a new signal generator, defined by the specified function (function passed as the argument 'function';
            /// must return a real - double - number)
            /// </summary>
            /// <param name="function"> Signal generator function </param>
            /// <param name="start"> Value domain starting point </param>
            /// <param name="stop"> Value domain end point; when reached, the current input is reset to 'start' </param>
            /// <param name="step"> Increment value for the current input </param>
            /// <param name="representedType"> The type to be represented in the output value 'y'; for example, if this is 'int', then the returned value will be a double value rounded away from zero </param>
            /// <param name="realPrecision"> The number of digits to be taken into account when outputting or rounding the result; is ignored when the represented type is set to 'int' </param>
            internal SignalGenerator(SignalGeneratorFunctionType function, double start, double stop, double step, Type representedType, int realPrecision)
            {
                this.signalFunction = function;
                this.x = this.start = start;
                this.stop = stop;
                this.step = step;
                this.representedType = representedType;

                // compute represent type details
                if (this.representedType.Equals(typeof(double)) || this.representedType.Equals(typeof(float))) //real
                {
                    this.precision = realPrecision;
                }
                else if (this.representedType.Equals(typeof(int))) // integer
                {
                    this.precision = 1; 
                }
                else // unsupported represented type
                {
                    Diagnostics.LogSilentEvent(Diagnostics.DefaultEventCodes.SIGNAL_GENERATOR_UNSUPPORTED_VALUE_TYPE, this.representedType.FullName);
                }
            }

            /// <summary>
            /// Computes and returns the current y-value
            /// </summary>
            /// <returns> The result of the function ( y = f(x) ) </returns>
            public double computeY()
            {

                if((this.x + this.step) < this.stop) // the next value would be within the value domain
                {
                    this.x += this.step; // increment current input value
                }
                else // value domain end reached --> reset input to 'start'
                {
                    this.x = this.start; 
                }

                // compute the result
                return Math.Round(this.signalFunction(this.x),this.precision,MidpointRounding.AwayFromZero); // y
            }
        }

        internal Type representedType { get; set; } // determines how the double value will be represented when output


        public ConcreteLogicalInput(AbstractSimElement abstractElement, string name, byte simNr, int simElementNr, Point location) // base concrete element details
            : base(abstractElement, name, simNr, simElementNr, location)
        {

        }
    }

    /// <summary>
    /// Defines a concrete logical output, which displays data sent by various simulation elements it is linked to
    /// </summary>
    public class ConcreteLogicalOutput : ConcreteElement
    {
        public TextBox outputTextBox { get; } = new TextBox(); // control that displays the value
        public ConcreteLogicalOutput(AbstractSimElement abstractElement, string name, byte simNr, int simElementNr, Point location) // base concrete element details
            : base(abstractElement, name, simNr, simElementNr, location)
        {
            this.outputTextBox.ReadOnly = true;
        }
    }
    
    #endregion

    /// <summary>
    /// Manages simulation elements and their interaction, as well as implementing low-level user interaction functions.
    /// </summary>
    public static class SimulationManager
    {
        // blueprint keys
        public const string SIM_BLUEPRINT_KEY_tm = "Transport Mediums";
        public const string SIM_BLUEPRINT_KEY_uP = "Microprocessors";
        
        // simulation management files
        public const string SIM_ABSTRACT_ELEMENT_DEF_IMG_FILEPATH = "../../RESOURCES/DefaultImages/DEF_ABSTRACT_SIM_ELEMENT_IMAGE.jpg";
        
        // global variables
        public static int BLUEPRINT_INDEX = 0; // abstract simulation element blueprint index (unique); is incremented with each created blueprint
        public static Dictionary<string, AbstractSimElement> SimBlueprints = new Dictionary<string, AbstractSimElement>(); // available abstract simulation element blueprints
                                                                                                                           // key = blueprint category (transport medium, uP etc.) 
        public static ImageList BlueprintImagelist { get; } = new ImageList(); // images to be used for the simulation blueprint treeview
        
    }
}
