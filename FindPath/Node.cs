using System;
using System.Collections.Generic;

namespace FindPath
{
    // временное хранилище для данных
    public class Item
    {
        public string start { get; set; }
        public string end { get; set; }
        public float weight { get; set; }

        public Item()
        {
        }

        public Item(string start, string end, float weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
        }

        public Node ToNode()
        { 
            return new Node(start, weight);
        }

        public void Print()
        {
            View.PrintMessage(string.Format("[{0}, {1}, {3}]", start, end, weight));
        }
    }

    public class Node
    {
        public string name { get; set; }
        public float weight { get; set; }
        public List<Node> children { get; set; }

        public Node(string name, float weight)
        {
            this.name = name;
            this.weight = weight;
            children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }
    }

}

