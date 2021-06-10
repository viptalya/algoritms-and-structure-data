using System;

namespace lesson2._1
{
    //1. Двусвязный список
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
            public int GetCount()
            {
                int count = 0;
                Node nodeCount = this;
                while (nodeCount.NextNode != null)
                {
                    count++;
                    nodeCount = nodeCount.NextNode;
                }
                return ++count;
            }
            public void AddNode(int value)
            {
                Node nodeAdd = this;
                while (nodeAdd.NextNode != null)
                {
                    nodeAdd = nodeAdd.NextNode;
                }
                Node nodeNewAdd = new Node();
                nodeNewAdd.Value = value;
                nodeNewAdd.NextNode = null;
                nodeNewAdd.PrevNode = nodeAdd;
                nodeAdd.NextNode = nodeNewAdd;
            }
            public void AddNodeAfter(Node node, int value)
            {
                Node nodeAfter = node.NextNode;
                Node nodeNewAfter = new Node();
                nodeNewAfter.Value = value;
                nodeNewAfter.NextNode = nodeAfter;
                nodeNewAfter.PrevNode = node;
                node.NextNode = nodeNewAfter;
                if (nodeAfter != null)
                {
                    nodeAfter.PrevNode = nodeNewAfter;
                }
            }
            public void RemoveNode(int index)
            {
                Node nodeIndex = this;
                while (index != 0)
                {
                    if (nodeIndex.NextNode == null)
                        return;
                    nodeIndex = nodeIndex.NextNode;
                    index--;
                }
                RemoveNode(nodeIndex);
            }
            public void RemoveNode(Node node)
            {
                if (node.PrevNode == null)
                {
                    node.Value = node.NextNode.Value;
                    node.NextNode = node.NextNode.NextNode;
                    return;
                }
                node.PrevNode.NextNode = node.NextNode;
                if (node.NextNode != null)
                    node.NextNode.PrevNode = node.PrevNode;
            }
            public Node FindNode(int searchValue)
            {
                Node nodeSearch = this;
                while (true)
                {
                    if (nodeSearch.Value == searchValue)
                    {
                        break;
                    }
                    nodeSearch = nodeSearch.NextNode;

                }
                return nodeSearch;
            }
        }
        public interface ILinkedList
        {
            int GetCount();
            void AddNode(int value);
            void AddNodeAfter(Node node, int value);
            void RemoveNode(int index);
            void RemoveNode(Node node);
            Node FindNode(int searchValue);
        }

        static void PrintNode(Node nodePrint)
        {
            Node node = nodePrint;
            while (node.NextNode != null)
            {
                Console.Write(node.Value);
                node = node.NextNode;
            }
            Console.WriteLine(node.Value);
        }
        static void Main(string[] args)
        {
            Node node = new Node();
            node.Value = 1;
            node.AddNode(5);
            PrintNode(node);
            node.AddNodeAfter(node.NextNode, 4);
            PrintNode(node);
            node.RemoveNode(0);
            PrintNode(node);
            Console.WriteLine($"Кол-во значений: {node.GetCount()}");
            Console.WriteLine($"Искомое значение: {node.FindNode(5).Value}");
            node.RemoveNode(node);
            PrintNode(node);
        }
    }
}
