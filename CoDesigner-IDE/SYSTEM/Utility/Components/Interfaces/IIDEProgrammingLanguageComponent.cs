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
            public string name { get; } //=> function name
            public int totalSize { get; } //=> allocated memory, in bytes; includes parameters, local variables and the return value(s)

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
            public List<Variable> variables { get; } //=> current variable list
            public List<Function> functions { get; } //=> current function list
            public int codeLines { get; } //=> current lines of code
            public int functionCalls { get; } //=> current number of function calls

            public int conditionalInstr { get; } //=> current number of conditional instructions (e.g., 'if')
            public List<Tuple<int, int>> scopes { get; } //=> current number of scopes, each defines by 2 indices: start (includes the first instruction, if applicable) and end line of the scope
            public int loops { get; } //=> current number of loop instructions

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
