using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class DialogueNode
    {
        public int NodeID = -1;

        public string Text;

        public List<DialogueOption> Options;

        public DialogueNode()
        {
            //Options = new List<DialogueOption>();
        }

        public DialogueNode(string text)
        {
            Text = text;
            Options = new List<DialogueOption>();
        }
    }
}
