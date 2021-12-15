using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day14;
using Xunit;

namespace AdventOfCode2021.Day14.Tests
{
    public class Day14Tests
    {
        [Fact]
        public void ReadData_WithSampleData_ShouldReturnOneStringAndOneList()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            string startingTemplate = data[0];
            Dictionary<string, char> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1][0]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Assert.Equal("NNCB", startingTemplate);
            Assert.Equal(16, instructions.Count());
        }

        [Fact]
        public void Tick_WithSampleDataAfterOneStep_ShouldReturnDictionary()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            string startingTemplate = data[0];
            Dictionary<string, string> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Polymer polyProcessor = new Polymer();
            Dictionary<string, long> result = polyProcessor.PairInsertion(startingTemplate, instructions, 1);
            Dictionary<char, long> letterCounts = polyProcessor.CountLetters(startingTemplate, result);

            Assert.Equal(6, result.Count());
            Assert.Equal(2, letterCounts['N']);
            Assert.Equal(2, letterCounts['C']);
            Assert.Equal(2, letterCounts['B']);
            Assert.Equal(1, letterCounts['H']);
        }

        [Fact]
        public void Tick_WithSampleDataAfterTwoSteps_ShouldReturnDictionary()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            string startingTemplate = data[0];
            Dictionary<string, string> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Polymer polyProcessor = new Polymer();
            Dictionary<string, long> result = polyProcessor.PairInsertion(startingTemplate, instructions, 2);
            Dictionary<char, long> letterCounts = polyProcessor.CountLetters(startingTemplate, result);

            Assert.Equal(8, result.Count());
            Assert.Equal(2, letterCounts['N']);
            Assert.Equal(4, letterCounts['C']);
            Assert.Equal(6, letterCounts['B']);
            Assert.Equal(1, letterCounts['H']);
        }

        [Fact]
        public void Tick_WithSampleDataAfterThreeSteps_ShouldReturnDictionary()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            string startingTemplate = data[0];
            Dictionary<string, string> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Polymer polyProcessor = new Polymer();
            Dictionary<string, long> result = polyProcessor.PairInsertion(startingTemplate, instructions, 3);
            Dictionary<char, long> letterCounts = polyProcessor.CountLetters(startingTemplate, result);

            Assert.Equal(11, result.Count());
            Assert.Equal(5, letterCounts['N']);
            Assert.Equal(5, letterCounts['C']);
            Assert.Equal(11, letterCounts['B']);
            Assert.Equal(4, letterCounts['H']);
        }

        [Fact]
        public void Part1_WithSampleData_ShouldReturn1588()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
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

            Assert.Equal(1588, max - min);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn2188189693529()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            string startingTemplate = data[0];
            Dictionary<string, string> instructions = 
                data.Skip(2)
                    .Select(s => (s.Split(" -> ")[0], s.Split(" -> ")[1]) )
                    .ToDictionary(s => s.Item1, s => s.Item2);

            Polymer polyProcessor = new Polymer();
            Dictionary<string, long> result = polyProcessor.PairInsertion(startingTemplate, instructions, 40);
            Dictionary<char, long> letterCounts = polyProcessor.CountLetters(startingTemplate, result);

            long max = letterCounts.Max(p => p.Value);
            long min = letterCounts.Min(p => p.Value);

            Assert.Equal(2188189693529, max - min);
        }

        private string SampleData = "NNCB\n\nCH -> B\nHH -> N\nCB -> H\nNH -> C\nHB -> C\nHC -> B\nHN -> C\nNN -> C\nBH -> H\nNC -> B\nNB -> B\nBN -> B\nBB -> N\nBC -> B\nCC -> N\nCN -> C";
    }
}