using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Custom data types used with Programming Language components
    /// </summary>
    public struct DATA_TYPES
    {
        /// <summary>
        /// Details about a given Variable
        /// </summary>
        public struct Variable
        {
            string name { get; }
            int size { get; } //=> allocated memory, in bytes

            /// <summary>
            /// Creates a new Variable details struct
            /// </summary>
            /// <param name="name"></param>
            /// <param name="size"></param>
            public Variable(string name, int size)
            {
                this.name = name;
                this.size = size;
            }
        }

        /// <summary>
        /// Details about a given function
        /// </summary>
        public struct Function
        {
            /// <summary>
            /// Function name
            /// </summary>
            public string name { get; }
            /// <summary>
            /// Allocated memory, in bytes; includes parameters, local variables and the return value(s)
            /// </summary>
            public int totalSize { get; }

            /// <summary>
            /// Creates a new Function details struct
            /// </summary>
            /// <param name="name"></param>
            /// <param name="totalSize"></param>
            public Function(string name, int totalSize)
            {
                this.name = name;
                this.totalSize = totalSize;
            }
        }

        /// <summary>
        /// Defines the code statistics that must be computed by the 'ComputeStats()' method of each 
        /// Programming Language component's. An instance of this structure contains details about the 
        /// current code, at the moment it is created (non-updateable)
        /// </summary>
        public struct CodeSnapshot
        {
            /// <summary>
            /// Current variable list
            /// </summary>
            public List<Variable> variables { get; }
            /// <summary>
            /// Current function list
            /// </summary>
            public List<Function> functions { get; }
            /// <summary>
            /// Current lines of code
            /// </summary>
            public int codeLines { get; }
            /// <summary>
            /// Current number of function calls
            /// </summary>
            public int functionCalls { get; }

            /// <summary>
            /// Current number of conditional instructions (e.g., 'if')
            /// </summary>
            public int conditionalInstr { get; }
            /// <summary>
            /// Current number of scopes, each defines by 2 indices: start (includes the first instruction, if applicable) and end line of the scope
            /// </summary>
            public List<Tuple<int, int>> scopes { get; }
            /// <summary>
            /// Current number of loop instructions
            /// </summary>
            public int loops { get; }

            /// <summary>
            /// Creates a new code snapshot struct
            /// </summary>
            /// <param name="variables"></param>
            /// <param name="functions"></param>
            /// <param name="codeLines"></param>
            /// <param name="functionCalls"></param>
            /// <param name="conditionalInstr"></param>
            /// <param name="scopes"></param>
            /// <param name="loops"></param>
            public CodeSnapshot(
                List<Variable> variables,
                List<Function> functions,
                int codeLines,
                int functionCalls,
                int conditionalInstr,
                List<Tuple<int, int>> scopes,
                int loops
                )
            {
                this.variables = variables;
                this.functions = functions;
                this.codeLines = codeLines;
                this.functionCalls = functionCalls;
                this.conditionalInstr = conditionalInstr;
                this.scopes = scopes;
                this.loops = loops;
            }
        }
    }


    /// <summary>
    /// Defines the mandatory format for all components used in the IDE
    /// </summary>
    internal interface IIDEProgrammingLanguageComponent
    {
        /// <summary>
        /// Analyzes the source code given; other methods can be called from here
        /// </summary>
        /// <param name="richTextBox"> Text editor which contains the source code </param>
        /// <returns> True if the analysis is successful </returns>
        bool Analyze(
            RichTextBox richTextBox //=> the control in which the analyzed text is stored and will also be displayed; this method, or methods called by it, must fill in this control
            );

        /// <summary>
        /// Compiles the code into final products (e.g., executable files)
        /// </summary>
        /// <returns> True if the compilation is successful </returns>
        bool Compile();

        /// <summary>
        /// Returns a code statistics snapshot for the current code
        /// </summary>
        /// <returns> A code statistics snapshot </returns>
        DATA_TYPES.CodeSnapshot GetCodeSnapshot();
        
        /// <summary>
        /// Loads the language's grammar
        /// </summary>
        /// <param name="grammarNode"> The XML node, from the component configuration, which contains the grammar </param>
        /// <returns> True if the grammar is successfully loaded </returns>
        bool LoadGrammar(
            XmlNode grammarNode //=> the node defining the programming language's grammar, from the component configuration
            );
    
    }
}
