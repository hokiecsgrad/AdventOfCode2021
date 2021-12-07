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
            Dictionary<int, int> positions = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(x => x)
                    .Select(x => new { Pos = int.Parse(x.Key), NumSubs = x.Count() })
                    .ToDictionary(group => group.Pos, group => group.NumSubs);

            int maxPositions = positions.Keys.Max();
            int fuleNeeded = int.MaxValue;
            for (int posIndex = 0; posIndex < maxPositions; posIndex++)
            {
                int fuleNeededToMoveAllSubsToCurrPos = 0;
                foreach (var posInfo in positions)
                    fuleNeededToMoveAllSubsToCurrPos += SumOfNumbers(Math.Abs(posIndex - posInfo.Key)) * posInfo.Value;

                fuleNeeded = Math.Min(fuleNeeded, fuleNeededToMoveAllSubsToCurrPos);
            }

            System.Console.WriteLine($"The minimum amount of fule needed to align all crab subs is: {fuleNeeded}");
        }

        private int SumOfNumbers(int num)
            => Enumerable.Range(1, num).Sum();
    }
}
