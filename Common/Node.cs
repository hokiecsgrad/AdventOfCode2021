using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Common
{
    public class Node
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public List<Node> Edges = new();

        public Node(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public Node() { }

        public void AddEdge(Node destination)
        {
            Edges.Add(destination);
        }
    }
}