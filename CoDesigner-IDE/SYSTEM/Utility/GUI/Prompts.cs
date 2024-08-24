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
    /// Defines a user message (caption, text, buttons, icons etc.); used for dialog boxes, logs, labels etc.
    /// </summary>
    public class PromptMessage
    {
        public string Caption { get; }
        public string Text { get; }
        public MessageBoxButtons Buttons { get; }
        public MessageBoxIcon Icon { get; }
        
        public PromptMessage(string Caption, string Text, int Buttons, int Icon)
        {
            this.Caption = Caption;
            this.Text = Text;

            try
            {
                this.Buttons = (MessageBoxButtons)Buttons;
                this.Icon = (MessageBoxIcon)Icon;

            }catch(Exception ex) 
            {
                Diagnostics.LogEvent(0x00000004, ex.Message);
            }
        }
    }
    /// <summary>
    /// Handles IDE wide prompts and messages
    /// </summary>
    public static class Prompts
    {
        public static Dictionary<int,PromptMessage> Messages = new Dictionary<int,PromptMessage>();
        public static int DEFAULT_MESSAGES_ORIGIN_CODE = 0x000F; //2 bytes

        /// <summary>
        /// Opens a dialog configured based on the given code (which must be found in the list of loaded messages)
        /// </summary>
        /// <param name="code"></param>
        public static DialogResult OpenDialog(int code)
        {
            return MessageBox.Show(
                Prompts.Messages[code].Text, 
                Prompts.Messages[code].Caption,
                Prompts.Messages[code].Buttons,
                Prompts.Messages[code].Icon
                );
        }

        /// <summary>
        /// Opens a dialog based on the given origin and message codes (same as the overload with 1 integer - code - but this method constructs the code, whereas the other one expects the full code)
        /// </summary>
        /// <param name="originCode"></param>
        /// <param name="messageCode"></param>
        /// <returns></returns>
        public static DialogResult OpenDialog(int originCode, int messageCode)
        {
            int code;

            code = (originCode<<16) | messageCode;

            return MessageBox.Show(
                Prompts.Messages[code].Text,
                Prompts.Messages[code].Caption,
                Prompts.Messages[code].Buttons,
                Prompts.Messages[code].Icon
                );
        }
    }
}
