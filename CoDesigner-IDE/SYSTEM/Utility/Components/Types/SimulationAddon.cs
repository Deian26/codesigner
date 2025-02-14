using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static CoDesigner_IDE.Diagnostics;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Defines additional simulation elements
    /// </summary>
    internal class SimulationAddon : Component
    {
        /// <summary>
        /// Configuration tag names
        /// </summary>
        private static class CONFIG_TAGS
        {
            // category
            public const string simulation = "simulation";
            public const string description = "description";

            // sub-categories
            public const string transport_mediums = "transport-mediums";
            public const string abstract_sim_elements = "abstract-simulation-elements";

            // transport medium
            public const string transport_medium = "transport-medium";

            // abstract element types
            public const string abstract_element_type_uP = "uP";
            public const string abstract_element_type_logicInput = "logic-input";
            public const string abstract_element_type_logicOutput = "logic-output";
            public const string abstract_element_type_note = "note";

            // special characters
            public const char attr_separator_char = ',';
        }

        private List<AbstractTransportMedium> TransportMediums = new List<AbstractTransportMedium>();

        /// <summary>
        /// Creates a new simulation addon component
        /// </summary>
        /// <param name="componentFolderPath"></param>
        /// <param name="Name"></param>
        /// <param name="Version"></param>
        /// <param name="Timestamp"></param>
        /// <param name="Description"></param>
        /// <param name="simConfigRoot"></param>
        public SimulationAddon(string componentFolderPath, string Name, string Version, DateTime Timestamp, string Description, XmlNode simConfigRoot) : base(componentFolderPath, Name, Version, Timestamp, Description)
        {
            //parse the configuration file and extract simulation element definitions
            try
            {
                foreach(XmlNode configElement in simConfigRoot.ChildNodes)
                {

                    switch (configElement.Name) // category
                    {
                        case SimulationAddon.CONFIG_TAGS.description:
                            {
                                // the description is kept as a read-only property, thus is extracted before the constructor is called
                                break;
                            }

                        case SimulationAddon.CONFIG_TAGS.simulation:
                            {
                                // parse simulation elements
                                foreach (XmlNode simConfigElement in configElement.ChildNodes)
                                {
                                    switch (simConfigElement.Name)
                                    {
                                        case SimulationAddon.CONFIG_TAGS.transport_mediums:
                                            {
                                                // get transport protocols
                                                string name, description, imgFilePath;
                                                int parallel_bits;
                                                bool medium_selection;
                                                AbstractTransportMedium TM = null;

                                                foreach (XmlNode tm in simConfigElement.ChildNodes)
                                                {
                                                    if (simConfigElement.Name.Equals(SimulationAddon.CONFIG_TAGS.transport_medium))
                                                    {
                                                        name = tm.Attributes["name"].Value.Trim();
                                                        description = tm.Attributes["description"].Value.Trim();
                                                        imgFilePath = tm.Attributes["image-filepath"].Value.Trim();
                                                          
                                                        parallel_bits = Int32.Parse(tm.Attributes["parallel-bits"].Value.Trim());
                                                        medium_selection = Boolean.Parse(tm.Attributes["sel"].Value.Trim());

                                                        TM = new AbstractTransportMedium(name, description, SimulationManager.BLUEPRINT_INDEX++, imgFilePath, // general for all simulation abstract elements 
                                                                                                        parallel_bits, medium_selection);
                                                        this.TransportMediums.Add(TM); // specific to the transport medium object
                                                    }
                                                }
                                                // add transport medium blueprint
                                                SimulationManager.SimBlueprints.Add(SimulationManager.SIM_BLUEPRINT_KEY_tm, TM);
                                                break;
                                            }

                                        case SimulationAddon.CONFIG_TAGS.abstract_sim_elements:
                                            {
                                                // get abstract element definitions
                                                foreach (XmlNode abstractElementConfig in simConfigElement.ChildNodes)
                                                {
                                                    // supported abstract element types
                                                    // create a blueprint of each abstract element
                                                    switch (abstractElementConfig.Name)
                                                    {
                                                        case SimulationAddon.CONFIG_TAGS.abstract_element_type_uP:
                                                            {
                                                                // get uC details
                                                                bool floating_point, programming;
                                                                string name, description, imgFilePath;
                                                                List<AbstractMicroprocessor.Port> ports = null;

                                                                name = abstractElementConfig.Attributes["name"].Value.Trim();
                                                                description = abstractElementConfig.Attributes["description"].Value.Trim();
                                                                imgFilePath = Path.Combine(componentFolderPath, abstractElementConfig.Attributes["image-filepath"].Value.Trim()); // the path is relative to the top directory of the component

                                                                floating_point = false;
                                                                programming = false;
                                                                foreach (XmlNode upConfigElement in abstractElementConfig.ChildNodes)
                                                                {
                                                                    switch (upConfigElement.Name)
                                                                    {
                                                                        case "logic":
                                                                            {
                                                                                floating_point = Boolean.Parse(upConfigElement.Attributes["supports-floating-point"].Value.Trim());
                                                                                programming = Boolean.Parse(upConfigElement.Attributes["supports-programming"].Value.Trim());

                                                                                break;
                                                                            }

                                                                        case "ports":
                                                                            {
                                                                                // create part-blueprints for all of this AbstractMicroprocessor's ports
                                                                                ports = new List<AbstractMicroprocessor.Port>();
                                                                                List<AbstractTransportMedium> supportedTransportMediums;

                                                                                foreach (XmlNode portElement in upConfigElement.ChildNodes)
                                                                                {
                                                                                    if (portElement.Name.Equals("port") == true)
                                                                                    {
                                                                                        string[] transportMediumStrList;

                                                                                        supportedTransportMediums = new List<AbstractTransportMedium>();
                                                                                        transportMediumStrList = portElement.Attributes["transport-mediums"].Value.Trim().Split(SimulationAddon.CONFIG_TAGS.attr_separator_char).ToArray();

                                                                                        // find transport mediums that are supported by this port
                                                                                        foreach (string supportedTM in transportMediumStrList)
                                                                                        {
                                                                                            supportedTransportMediums.Add(this.TransportMediums.Find(
                                                                                                    delegate (AbstractTransportMedium tm)
                                                                                                    {
                                                                                                        return tm.name.Equals(supportedTM);
                                                                                                    }
                                                                                            ));
                                                                                        }

                                                                                        ports.Add(new AbstractMicroprocessor.Port(portElement.Attributes["name"].Value, supportedTransportMediums));
                                                                                    }
                                                                                }
                                                                                break;
                                                                            }

                                                                        default: // unrecognized AbstractMicroprocessor part
                                                                            {
                                                                                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_SIM_ADDON_ELEM_DEFINITION, upConfigElement.Name);
                                                                                break;
                                                                            }
                                                                    }
                                                                }
                                                                // create AbstractMicroprocessor blueprint
                                                                AbstractMicroprocessor _uP = new AbstractMicroprocessor(name, description, SimulationManager.BLUEPRINT_INDEX++, imgFilePath, floating_point, programming, ports);
                                                                SimulationManager.SimBlueprints.Add(SimulationManager.SIM_BLUEPRINT_KEY_uP, _uP);
                                                                break;
                                                            }

                                                        default: // unsupported abstract element types
                                                            {
                                                                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE,Diagnostics.DefaultEventCodes.INVALID_SIM_ADDON_ELEM_DEFINITION, abstractElementConfig.Name);
                                                                break;
                                                            }
                                                    }
                                                }

                                                break;
                                            }

                                        default: // unrecognized simulation configuration element
                                            {
                                                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_SIM_ADDON_ELEM_DEFINITION, simConfigElement.Name);
                                                break;
                                            }
                                    }
                                }

                                break;
                            }

                        default: // unrecognized category
                            {
                                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_SIM_ADDON_ELEM_DEFINITION, configElement.Name);
                                break;
                            }
                    }
                }

            }catch (Exception ex) // format error
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_COMPONENT_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_SIM_ADDON_DEFINITION, ex.Message);
            }
        }

        /// <summary>
        /// Display the Programming Language component details
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string str;

            str = base.ToString();

            // add type-specific attributes
            str += "Type: F1_SimulationContainer Addon\n";
            str += "\n";

            return str;
        }

    }

}
