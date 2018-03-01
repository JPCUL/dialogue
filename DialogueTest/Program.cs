using System;
using System.Collections.Generic;
using DialogueTree;
using System.Xml.Serialization;
using System.IO;

namespace DialogueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            //Create_Dialogue();
            
            Dialogue dia = Load_Dialogue("test_dia.xml");
            //Console.WriteLine("aaaaaaaabbbbbbbbbbbbbbbbaaaaa");
            run_dialogue(dia);
            Console.ReadLine();
        }


        static void run_dialogue(Dialogue dia)
        {
            int node_id = 0;

            while (node_id != -1)
            {
                node_id = run_node(dia.Nodes[node_id]);
            }
        }

        static int run_node(DialogueNode node_)
        {
            int next_node = -1;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(node_.Text);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Response Num:");

            for (int i = 0; i < node_.Options.Count; i++)
            {
                Console.WriteLine(String.Format("       {0}: {1}", i + 1, node_.Options[i].Text));
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------");

            char key = Console.ReadKey().KeyChar;

            next_node = node_.Options[int.Parse(key.ToString()) - 1].DestinationNodeID;

            return next_node;
        }

        private static void Create_Dialogue()
        {
            Dialogue dia = new Dialogue();
           
            DialogueNode node1 = new DialogueNode("Hello, this is Test Dialogue Node 1");
            DialogueNode node2 = new DialogueNode("Hello, this is Test Dialogue Node 2");
            DialogueNode node3 = new DialogueNode("Hello, this is Test Dialogue Node 3");
            DialogueNode node4 = new DialogueNode("Hello, this is Test Dialogue Node 4");

            Console.WriteLine(node1 == null);

            dia.AddNode(node1);
            dia.AddNode(node2);
            dia.AddNode(node3);
            dia.AddNode(node4);

            //Options : Exit
            dia.AddOption("Exit dialogue", node2, null);
            dia.AddOption("Exit dialogue", node4, null);

            //Options : Transition
            dia.AddOption("Go to Node 2 from Node 1", node1, node2);
            dia.AddOption("Go to Node 3 from Node 2", node2, node3);
            dia.AddOption("Go to Node 1 from Node 2", node2, node1);
            dia.AddOption("Go to Node 3 from Node 2", node2, node3);
            dia.AddOption("Go to Node 4 from Node 3", node3, node4);

            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("test_dia.xml");

            serz.Serialize(writer, dia);
        }

        private static Dialogue Load_Dialogue(string path)
        {
            XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);

            Dialogue dia = (Dialogue)serz.Deserialize(reader);

            return dia;
        }
    }
}
