using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day08
{
    public class Part1
    {
        public void Run(string[] data)
        {
            int uniqueDigits = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string output = data[i].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[1];
                uniqueDigits += output
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)
                                .Where(z => z.Length == 2 || z.Length == 3 || z.Length == 4 || z.Length == 7)
                                .Select(x => x.Length)
                                .Count();
            }

            System.Console.WriteLine($"The number of unique segment digits is: {uniqueDigits}");
        }
    }
}
