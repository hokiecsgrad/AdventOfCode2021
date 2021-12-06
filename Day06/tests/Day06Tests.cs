using System;
using System.Collections.Generic;
using System.Linq;
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
            List<int> ages = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            for (int i = 0; i < numDays; i++)
            {
                for (int j = ages.Count() - 1; j >= 0; j--)
                {
                    if (ages[j] == 0)
                    {
                        ages[j] = 6;
                        ages.Add(8);
                    }
                    else
                        ages[j] -= 1;
                }
            }

            Assert.Equal(expectedFish, ages.Count);
        }

        private string SampleData = @"3,4,3,1,2";
    }
}