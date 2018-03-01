using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> Nodes = new List<DialogueNode>();

        public void AddNode(DialogueNode node_)
        {
            if (node_ == null)
                return;
            Console.WriteLine(node_.Text);
            Nodes.Add(node_);

            node_.NodeID = Nodes.IndexOf(node_);
        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest)
        {
            if (!Nodes.Contains(dest))
                AddNode(dest);

            if (!Nodes.Contains(node))
                AddNode(node);

            DialogueOption opt;

            if (dest == null)
            {
                opt = new DialogueOption(text, -1);
            }
            else
            {
                opt = new DialogueOption(text, dest.NodeID);
            }
            node.Options.Add(opt);
        }

    }
}
