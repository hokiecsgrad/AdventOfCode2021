using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day15
{
    public class Part1
    {
        public void Run(string[] data)
        {
            Graph g = new Graph(data);
            Dictionary<string, int> path = g.FindShortestPath();

            // Expecting 398
            System.Console.WriteLine($"The shortest path is: {path.Last().Value}");
        }
    }
}
