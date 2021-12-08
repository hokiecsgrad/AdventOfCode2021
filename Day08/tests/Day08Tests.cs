using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day08;
using Xunit;

namespace AdventOfCode2021.Day08.Tests
{
    public class Day08Tests
    {
        string[] data;

        public Day08Tests()
        {
            data = SampleData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
        }

        [Fact]
        public void Part1_WithSampleData_ShouldReturn26()
        {
            int uniqueDigits = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string output = data[i].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[1];
                uniqueDigits += output
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)
                                .Where(z => z.Length == 2 || z.Length == 3 || z.Length == 4 || z.Length == 7)
                                .Select(x => x.Length)
                                .Count();
            }

            Assert.Equal(26, uniqueDigits);
        }

        [Fact]
        public void DecodeSegments_WithFirstRowOfSampleData_ShouldAssignProperly()
        {
            string[] input = data[0].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[0].Split(' ');
            string output = data[0].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[1];
            Dictionary<int, char[]> numbers = new();
            Dictionary<string, char> segments = new();
            numbers.Add(1, input.Where(x => x.Length == 2).First().ToCharArray() );
            numbers.Add(7, input.Where(x => x.Length == 3).First().ToCharArray() );
            numbers.Add(4, input.Where(x => x.Length == 4).First().ToCharArray() );
            numbers.Add(8, input.Where(x => x.Length == 7).First().ToCharArray() );

            segments.Add("top row", numbers[7].Where( c => !numbers[1].Contains(c) ).First() );

            string[] bottomRowCandidates = input.Where(x => x.Length == 6).ToArray();
            foreach (var candidate in bottomRowCandidates)
            {
            }

            Assert.Equal('d', segments["top row"]);
        }

        private string RemoveCharsFromString(string source, char[] subtractions)
        {
            string result = string.Empty;
            return result;
        }

        private string SampleData = "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe\nedbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc\nfgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg\nfbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb\naecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea\nfgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb\ndbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe\nbdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef\negadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb\ngcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";
    }
}