using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day07
{
    public class Part2
    {
        public void Run(string[] data)
        {
            List<int> positions = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            // refactored based on solution from /u/fmorel
            int min = positions.Min();
            int max = positions.Max();
            int fuel = Enumerable.Range(min, max - min + 1)
                                    .Min( i => positions.Select( x => Math.Abs(x - i) )
                                                        .Select( x => x * (x + 1) / 2 )
                                                        .Sum() 
                                    );

            System.Console.WriteLine($"The minimum amount of fuel needed to align all crab subs is: {fuel}");
        }

        private int SumOfNumbers(int num)
            => Enumerable.Range(1, num).Sum();
    }
}
