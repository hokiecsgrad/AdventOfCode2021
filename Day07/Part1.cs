using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day07
{
    public class Part1
    {
        public void Run(string[] data)
        {
            List<int> positions = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            // refactored based on solution from /u/fmorel
            int fuel = Enumerable.Range(0, positions.Max()).Min( i => positions.Select( x => Math.Abs(x - i) ).Sum() );

            System.Console.WriteLine($"The minimum amount of fuel needed to align all crab subs is: {fuel}");
        }
    }
}
