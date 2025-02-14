using CoDesigner_IDE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

/// <summary>
/// Compiler for the programming language: MCL
/// </summary>
public class MCL : IIDEProgrammingLanguageComponent
{
    #region general-fields
    private string sourceCode = null; //=> code to be analyzed, compiled and/or executed
    #endregion

    #region grammar
    // fields
    public char[] whitespace { get; } = { ' ', '\n', '\r', '\t' }; //=> whitespaces (to be ignored)
    /// <summary>
    /// Defines the style for a given token
    /// </summary>
    private struct TokenStyle
    {
        public Color colour; //=> keyword colour

        public TokenStyle(Color colour)
        {
            this.colour = colour;
        }
    }

    /// <summary>
    /// Describes a token and its associated style (if any)
    /// </summary>
    private class Token
    {
        public string name { get; } = null; //=> actual string to be searched for
        public int code { get; } //=> token type code
        public bool caseSensitive { get; } //=> case sensitivity for this token
        public TokenStyle style { get; set; } //=> the style of this token

        /// <summary>
        /// Create a new token
        /// </summary>
        /// <param name="name"> Actual string to be searched for </param>
        public Token(string name, Color colour, int code, bool caseSensitive)
        {
            this.name = name;
            this.style = new TokenStyle(colour);
            this.code = code; //=> unique token code
            this.caseSensitive = caseSensitive;
        }
    }

    /// <summary>
    /// Defines an atom (concrete token found in the code)
    /// </summary>
    private class Atom
    {
        private Token token {get;} //=> the token that defines this atom
        
        //=// Location
        public int line { get; }
        public int column { get; }

        public Atom(Token token, int line, int column)
        {
            this.token = token;
            this.line = line;
            this.column = column;
        }
    }

    /// <summary>
    /// Defines types of grammar rules
    /// </summary>
    private struct GrammarRuleTags
    {
        //=// Grammar node tag names (rule types) //=//
        internal struct RuleTypes
        {
            internal const string KEYWORD = "keyword";
            internal const string RULE = "rule";
        }


        //=// Tokens //=//
        internal struct Keywords
        { //TODO: Define MCL keywords
            internal const string IF = "if";
        }

        //=// Rule names //=//
        internal struct RuleNames
        { //TODO: Define MCL rule names (XML tag names)
            //internal const string ASSIGNMENT = ;
        }
        
    }

    /// <summary>
    /// Loads the grammar from the specified node (called by the IDE)
    /// </summary>
    /// <param name="grammar"> The XML node from the programming language's configuration which defines the grammar </param>
    /// <returns> Returns true if the grammar was successfully returned </returns>
    public bool LoadGrammar(XmlNode grammar)
    {
        if (grammar == null) return false; //=> invalid node
        
        this.tokens.Clear(); //=> reset fromal token list

        foreach (XmlNode rule in grammar)
        {
            switch(rule.Name) // determine rule type
            {//TODO: Implement grammar interpretation
                case MCL.GrammarRuleTags.RuleTypes.KEYWORD:
                    {
                        if (rule.Attributes["name"] != null && rule.Attributes["colour"] != null)
                        {
                            try
                            {
                                int R, G, B;
                                string[] rgbStrList;
                                string name;
                                int code; // token code
                                bool caseSensitive;

                                name = rule.Attributes["name"].Value.Trim();
                                rgbStrList = rule.Attributes["colour"].Value.Trim().Split(','); //=> this attribute's value must be 3 comma-separated integers, representing, in this order, the colours: Red, Green and Blue
                                code = Int32.Parse(rule.Attributes["code"].Value.Trim());
                                caseSensitive = Boolean.Parse(rule.Attributes["case-sensitive"].Value.Trim());

                                R = Int32.Parse(rgbStrList[0]);
                                G = Int32.Parse(rgbStrList[1]);
                                B = Int32.Parse(rgbStrList[2]);

                                Color colour = Color.FromArgb(R,G,B);

                                this.tokens.Add(name, //=> key
                                    //=// Create token //=//
                                    new Token(
                                    name,
                                    colour,
                                    code,
                                    caseSensitive
                                    )); 

                            } catch (Exception ex)
                            {
                                //TODO: Display error here                                
                            }
                        } //=> else: the token is not registered

                        break;
                    }
                case MCL.GrammarRuleTags.RuleTypes.RULE:
                    {
                        //TODO: Interpret rules and load them into memory as methods
                        break;
                    }
                default: // unrecognized rule (sub-node) >=> skip sub-node
                    {
                        continue;
                    }
            }
        }

        return true; //=> the grammar was successfully loaded
    }

    private Dictionary<string,Atom> atoms = new Dictionary<string,Atom>(); //=> tokens found in the input, in the order they appear in; key = token name (actual string)
    private Dictionary<string, Token> tokens = new Dictionary<string, Token>(); //=> formal token definitions (to be searched for in the input)

    #endregion

    #region external-connection-points
    /// <summary>
    /// Mandatory method
    /// 
    /// Base analyzer (mandatory); other methods are called from here
    /// MCL source code analyzer.
    /// </summary>
    /// <param name="richTextBox"> The rich text box control used to store the code; this method will choose what and how to display the code within this control </param>
    /// <returns> True if the analysis was successful </returns>
    public bool Analyze(RichTextBox richTextBox)
    {
        this.sourceCode = richTextBox.Text; //=> store the code

        // TODO: Implement MCL base analyzer
        this.tokenize(this.sourceCode); //=> extract atoms from the input and apply token styles where they exist
        
        
        return true; //=> successfully analyzed the file
    }
    
    /// <summary>
    /// Mandatory method
    /// 
    /// Compiles the code analysis results into a final package (e.g., executable file(s)).
    /// The file to be openeded (executable) must be stored at the path specified in the configuration XML file, 
    /// </summary>
    /// <returns> True if the code was successfully compiled </returns>
    public bool Compile()
    {
        //TODO: Implement MCL compiler

        return true;
    }

    /// <summary>
    /// Computes code statistics
    /// </summary>
    /// <returns> Current code statistics (snapshot) </returns>
    public DATA_TYPES.CodeSnapshot GetCodeSnapshot()
    {
        //TODO: Implement code statistics snapshotting (the return value must be 'DATA_TYPES.CodeSnapshot')
        return new DATA_TYPES.CodeSnapshot(); //HACK: Change this to an actual value
    }

    #endregion

    #region utility
    /// <summary>
    /// Extract atoms from the input
    /// </summary>
    /// <param name="input"> Text to be parsed </param>
    private void tokenize(string input)
    {
        //TODO: Implement MCL tokenizer
        //=// Split the input into atoms

    }

    #endregion

    #region code-execution
    
    #endregion
    
    #region singleton
    private static MCL instance = null;
    /// <summary>
    /// Returns the instance of this object to be used in the IDE
    /// </summary>
    /// <returns> The instance to be used within the IDE, for component-specific methods </returns>
    public static MCL GetInstance() //=> this name is fixed and this method must be implemented for the component to be loaded into the IDE
    {
        MCL.instance = new MCL(); //=> instantiate the singleton
        return MCL.instance;
    }

    private MCL() { } //=> this class should be a singleton
    #endregion
}

