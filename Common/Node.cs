using System;
using System.Collections.Generic;

namespace AdventOfCode.Common
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Edges { get; private set; } = new();

        public Node(string name)
        {
            Name = name;
        }

        public void AddEdge(Node dest)
        {
            if (!Edges.Contains(dest))
                Edges.Add(dest);
        }

        public bool IsSmallCave()
        {
            if (Name == Name.ToLower())
                return true;
            else
                return false;
        }
    }
}