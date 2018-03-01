using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueOption
    {
        public string Text;
        public int DestinationNodeID;

        public DialogueOption()
        {

        }
        public DialogueOption(string text, int dest)
        {
            this.Text = text;
            this.DestinationNodeID = dest;
        }
    }
}
