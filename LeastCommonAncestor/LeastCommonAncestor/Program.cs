using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastCommonAncestor
{
    public class Program
    {
        private static List<Node> _nodes;

        static void Main(string[] args)
        {
            Initialize();
            int firstCase = LCA(6, 7);
            int secondCase = LCA(3, 7);
            int thirdCase = LCA(5, 7);

            Console.WriteLine(string.Format(" {0} \n {1} \n {2}", firstCase, secondCase, thirdCase));
            Console.ReadKey();
        }

        public static void Initialize()
        {
            _nodes = new List<Node>();
            Node node1 = new Node(1, null);
            _nodes.Add(node1);
            Node node2 = new Node(2, node1);
            _nodes.Add(node2);
            Node node3 = new Node(3, node1);
            _nodes.Add(node3);
            Node node4 = new Node(4, node2);
            _nodes.Add(node4);
            Node node5 = new Node(5, node2);
            _nodes.Add(node5);
            Node node6 = new Node(6, node3);
            _nodes.Add(node6);
            Node node7 = new Node(7, node3);
            _nodes.Add(node7);
            Node node8 = new Node(8, node4);
            _nodes.Add(node8);
            Node node9 = new Node(9, node4);
            _nodes.Add(node9);
        }

        private static int LCA(int node1, int node2)
        {
            Node firstNode = _nodes.GetNodeByValue(node1);
            Node secondNode = _nodes.GetNodeByValue(node2);
            List<int> firstAncestors = firstNode.GetAncestors();
            List<int> secondAncestors = secondNode.GetAncestors();

            for (int firstCounter = 0; firstCounter < firstAncestors.Count; firstCounter++)
            {
                for (int secondCounter = 0; secondCounter < secondAncestors.Count; secondCounter++)
                {
                    if (firstAncestors[firstCounter] == secondAncestors[secondCounter])
                    {
                        return firstAncestors[firstCounter];
                    }
                }
            }

            return -1;
        }

    }

    public class Node
    {
        public int value;
        public Node parent;

        public Node(int value, Node parent)
        {
            this.value = value;
            this.parent = parent;
        }
    }

    public static class Extensions
    {
        public static Node GetNodeByValue(this List<Node> nodes, int value)
        {
            foreach (Node item in nodes)
            {
                if (item.value == value)
                {
                    return item;
                }
            }

            return null;
        }

        public static List<int> GetAncestors(this Node node)
        {
            List<int> ancestors = new List<int>();
            Node currentNode = node;

            while (currentNode != null)
            {
                ancestors.Add(currentNode.value);
                currentNode = currentNode.parent;
            }

            return ancestors;
        }
    }

}
