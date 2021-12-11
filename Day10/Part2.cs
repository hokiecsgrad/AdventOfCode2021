using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day10
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Dictionary<char, int> Scoring = new Dictionary<char, int> { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
            Parser parser = new Parser();

            List<long> scores = new();
            for (int i = 0; i < data.Length; i++)
            {
                string ending = parser.CompleteLine(data[i]);
                if (!String.IsNullOrEmpty(ending))
                {
                    long score = 0;
                    for (int j = 0; j < ending.Length; j++)
                        score = (score * 5) + Scoring[ending[j]];
                    scores.Add(score);
                }
            }

            scores.Sort();
            long finalScore = scores[(scores.Count() / 2)];

            System.Console.WriteLine($"Final autocomplete score is: {finalScore}");
        }
    }
}
