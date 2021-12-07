using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day07;
using Xunit;

namespace AdventOfCode2021.Day07.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part1_WithSampleData_ShouldReturn37()
        {
            // Dictionary<int, int> positions = SampleData.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //         .GroupBy(x => x)
            //         .Select(x => new { Pos = int.Parse(x.Key), NumSubs = x.Count() })
            //         .ToDictionary(group => group.Pos, group => group.NumSubs);
            List<int> positions = SampleData.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int maxPositions = positions.Max();
            int fuel = Enumerable.Range(0, maxPositions).Min( i => positions.Select( x => Math.Abs(x - i) ).Sum() );

            Assert.Equal(37, fuel);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn168()
        {
            Dictionary<int, int> positions = SampleData.Split(',', StringSplitOptions.RemoveEmptyEntries)
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

            Assert.Equal(168, fuleNeeded);
        }

        private int SumOfNumbers(int num)
            => Enumerable.Range(1, num).Sum();

        private string SampleData = @"16,1,2,0,4,2,7,1,2,14";
    }
}