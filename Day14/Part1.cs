using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day14
{
    public class Part1
    {
        public void Run(string[] data)
        {
            string startingTemplate = data[0];
            Dictionary<string, string> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Polymer polyProcessor = new Polymer();
            Dictionary<string, long> result = polyProcessor.PairInsertion(startingTemplate, instructions, 10);
            Dictionary<char, long> letterCounts = polyProcessor.CountLetters(startingTemplate, result);

            long max = letterCounts.Max(p => p.Value);
            long min = letterCounts.Min(p => p.Value);

            System.Console.WriteLine($"The result of subtracting the number of occurances of the max letter from the min letter is: {max-min}");
        }
    }
}
