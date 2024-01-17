using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();
            Node node7 = new Node();
            Node node8 = new Node();
            Node node9 = new Node();
            Node node10 = new Node();
            Node currentNode = new Node();

            node1.childrens.AddRange(new Node[] { node2, node3 }); //adding children
            node2.childrens.AddRange(new Node[] { node5, node6 });
            node3.childrens.AddRange(new Node[] { node7, node8 });
            node4.childrens.AddRange(new Node[] { node9, node10 });

            node2.parents.AddRange(new Node[] { node1 });
            node3.parents.AddRange(new Node[] { node1 });
            node4.parents.AddRange(new Node[] { node1 }); 
            node5.parents.AddRange(new Node[] { node2 });
            node6.parents.AddRange(new Node[] { node2 });
            node7.parents.AddRange(new Node[] { node3 });
            node8.parents.AddRange(new Node[] { node3 });
            node9.parents.AddRange(new Node[] { node4 });
            node10.parents.AddRange(new Node[] { node4 });

            node1.id = 1;
            node2.id = 2;
            node3.id = 3;
            node4.id = 4;
            node5.id = 5;
            node6.id = 6;
            node7.id = 7;
            node8.id = 8;
            node9.id = 9;
            node10.id = 10;
            while (true)
            {
                string stringChildren = currentNode.childrens.ToString();
                Console.WriteLine("Jseš na node" + currentNode.id); ". Má děti " + stringChildren + ". Napiš, kam se chceš posunout");
            }
           
        }
    }
    public class Node
    {
        public int id;
        public List<Node> childrens;
        public List<Node> parents;

    }
}
