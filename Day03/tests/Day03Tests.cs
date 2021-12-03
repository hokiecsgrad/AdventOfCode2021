using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021;
using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void PowerConsumption_WithSampleData_ShouldReturn198()
        {
            string sampleData = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            string[] data = sampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            Part1 calculator = new Part1();

            string gamma, epsilon;
            (gamma, epsilon) = calculator.CalculateGammaAndEpsilon(data);

            Assert.Equal("10110", gamma);
            Assert.Equal(22, Convert.ToInt32(gamma, 2));
            Assert.Equal("01001", epsilon);
            Assert.Equal(9, Convert.ToInt32(epsilon, 2));
            Assert.Equal(198, Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
        }

        [Fact]
        public void LifeSupportRating_WithSampleData_ShouldReturn230()
        {
            string sampleData = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
            string[] data = sampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            Part2 airQualCalc = new Part2();
            string oxygen = airQualCalc.CalculateOxygen(data);
            string co2 = airQualCalc.CalculateCo2(data);

            Assert.Equal("10111", oxygen);
            Assert.Equal("01010", co2);
            Assert.Equal(23, Convert.ToInt32(oxygen, 2));
            Assert.Equal(10, Convert.ToInt32(co2, 2));
            Assert.Equal(230, Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2));
        }
    }
}