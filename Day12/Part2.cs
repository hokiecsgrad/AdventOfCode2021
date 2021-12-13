using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day12
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPathsWithOneSmallCaveVisitedTwice();
            paths = paths.Distinct().ToList();

            System.Console.WriteLine($"The number of paths through the caves is: {paths.Count()}");
        }
    }
}
