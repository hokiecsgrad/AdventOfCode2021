using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Common;
using AdventOfCode2021.Day06;
using Xunit;

namespace AdventOfCode2021.Day06.Tests
{
    public class Day06Tests
    {
        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void Part1_WithSampleData_ShouldReturnExpectedLengthAfterSetNumberOfDays(int numDays, int expectedFish)
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            //List<int> ages = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Dictionary<int, long> ages = new Dictionary<int, long> { {0, 0}, {1, 1}, {2, 1}, {3, 2}, {4, 1}, {5, 0}, {6, 0}, {7, 0}, {8, 0} };

            for (int i = 0; i < numDays; i++)
            {
                long numBabies = ages[0];
                for (int j = 1; j <= ages.Count()-1; j++)
                    ages[j-1] = ages[j];
                ages[8] = numBabies;
                ages[6] += numBabies;
            }

            long sum = ages.Sum(x => x.Value);
            Assert.Equal(expectedFish, sum);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn26984457539()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            //List<int> ages = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Dictionary<int, long> ages = new Dictionary<int, long> { {0, 0}, {1, 1}, {2, 1}, {3, 2}, {4, 1}, {5, 0}, {6, 0}, {7, 0}, {8, 0} };

            for (int i = 0; i < 256; i++)
            {
                long numBabies = ages[0];
                for (int j = 1; j <= ages.Count()-1; j++)
                    ages[j-1] = ages[j];
                ages[8] = numBabies;
                ages[6] += numBabies;
            }

            long sum = ages.Sum(x => x.Value);
            Assert.Equal(26984457539, sum);
        }

        private string SampleData = @"3,4,3,1,2";
    }
}