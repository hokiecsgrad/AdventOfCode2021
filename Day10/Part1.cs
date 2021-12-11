using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day10
{
    public class Part1
    {
        public void Run(string[] data)
        {
            Dictionary<char, int> Scores = new Dictionary<char, int> { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            Dictionary<char, int> Errors = new Dictionary<char, int> { { ')', 0 }, { ']', 0 }, { '}', 0 }, { '>', 0 } };

            Parser parser = new Parser();
            for (int i = 0; i < data.Length; i++)
            {
                (bool isCorrupted, char errorChar) = parser.HasCorruptedChunk(data[i]);
                if (isCorrupted)
                    Errors[errorChar]++;
            }

            long score = 0;
            foreach (var item in Errors)
                score += Scores[item.Key] * item.Value;

            System.Console.WriteLine($"The score for the syntax checker is: {score}");
        }
    }
}
