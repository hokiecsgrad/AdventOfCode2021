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
            List<int> positions = SampleData.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int maxPositions = positions.Max();
            int fuel = Enumerable.Range(0, maxPositions).Min( i => positions.Select( x => Math.Abs(x - i) ).Sum() );

            Assert.Equal(37, fuel);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn168()
        {
            List<int> positions = SampleData.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int min = positions.Min();
            int max = positions.Max();
            int fuel = Enumerable.Range(min, max - min + 1)
                                    .Min( i => positions.Select( x => Math.Abs(x - i) )
                                                        .Select( x => x * (x + 1) / 2 )
                                                        .Sum() 
                                    );

            Assert.Equal(168, fuel);
        }

        private int SumOfNumbers(int num)
            => Enumerable.Range(1, num).Sum();

        private string SampleData = @"16,1,2,0,4,2,7,1,2,14";
    }
}