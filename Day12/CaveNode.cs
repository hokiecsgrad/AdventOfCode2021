using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day12
{
    public class CaveNode
    {
        public string Name { get; set; }
        public List<CaveNode> Edges { get; private set; } = new();

        public CaveNode(string name)
        {
            Name = name;
        }

        public void AddEdge(CaveNode dest)
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