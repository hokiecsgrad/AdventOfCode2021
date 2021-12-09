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
        public void DecodeSegments_WithOneRowOfSampleData_ShouldReturn5353()
        {
            string[] input = { "acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab" };
            string[] output = { "cdfeb", "fcadb", "cdfeb", "cdbaf" };
            Dictionary<int, char[]> numbers = new();
            Dictionary<string, char> segments = new();
            numbers.Add(1, input.Where(x => x.Length == 2).First().ToCharArray());
            numbers.Add(7, input.Where(x => x.Length == 3).First().ToCharArray());
            numbers.Add(4, input.Where(x => x.Length == 4).First().ToCharArray());
            numbers.Add(8, input.Where(x => x.Length == 7).First().ToCharArray());

            // find top row
            segments.Add("top row", numbers[7].Where(c => !numbers[1].Contains(c)).First());

            // find bottom row and letters for 9
            string[] bottomRowCandidates = input.Where(x => x.Length == 6).ToArray();
            foreach (var candidate in bottomRowCandidates)
            {
                string result = string.Empty;
                result = RemoveCharsFromString(candidate, numbers[7]);
                result = RemoveCharsFromString(result, numbers[4]);
                if (result.Length == 1)
                {
                    segments.Add("bottom row", result[0]);
                    numbers.Add(9, candidate.ToCharArray());
                }
            }

            // find left bottom segment
            string[] leftBottomCandidates = input.Where(x => x.Length == 6).Where(x => x != new string(numbers[9])).ToArray();
            segments.Add("left bottom", RemoveCharsFromString(leftBottomCandidates[0], numbers[9]).First());

            // find middle row and zero
            foreach (var candidate in leftBottomCandidates)
            {
                string result = string.Empty;
                result = RemoveCharsFromString(new string(numbers[9]), numbers[1]);
                result = RemoveCharsFromString(result, candidate.ToCharArray());
                if (result.Length == 1)
                {
                    segments.Add("middle row", result[0]);
                    numbers.Add(0, candidate.ToCharArray());
                }
                else
                    numbers.Add(6, candidate.ToCharArray());
            }

            // find right top
            segments.Add("right top", RemoveCharsFromString(new string(numbers[4]), numbers[6]).First());

            // find right bottom
            segments.Add("right bottom", RemoveCharsFromString(new string(numbers[1]), new char[] { segments["right top"] }).First());

            // find left top
            segments.Add("left top", RemoveCharsFromString("abcdefg", segments.Values.ToArray()).First());

            // find 2, 3, and 5
            string[] fiveSegCandidates = input.Where(x => x.Length == 5).ToArray();
            foreach (var candidate in fiveSegCandidates)
            {
                string result = string.Empty;
                result = RemoveCharsFromString(new string(numbers[1]), candidate.ToCharArray());
                if (result.Length == 0)
                    numbers.Add(3, candidate.ToCharArray());
                else if (result[0] == segments["right top"])
                    numbers.Add(5, candidate.ToCharArray());
                else if (result[0] == segments["right bottom"])
                    numbers.Add(2, candidate.ToCharArray());
            }

            string outputResult = string.Empty;
            for (int i = 0; i < output.Length; i++)
            {
                outputResult += GetNumberFromSegments(output[i], numbers);
            }

            Assert.Equal('d', segments["top row"]);
            Assert.Equal('c', segments["bottom row"]);
            Assert.Equal('g', segments["left bottom"]);
            Assert.Equal('f', segments["middle row"]);
            Assert.Equal('a', segments["right top"]);
            Assert.Equal('b', segments["right bottom"]);
            Assert.Equal('e', segments["left top"]);

            Assert.True(new HashSet<char>(numbers[0]).SetEquals("cagedb"));
            Assert.True(new HashSet<char>(numbers[1]).SetEquals("ab"));
            Assert.True(new HashSet<char>(numbers[2]).SetEquals("gcdfa"));
            Assert.True(new HashSet<char>(numbers[3]).SetEquals("fbcad"));
            Assert.True(new HashSet<char>(numbers[4]).SetEquals("eafb"));
            Assert.True(new HashSet<char>(numbers[5]).SetEquals("cdfbe"));
            Assert.True(new HashSet<char>(numbers[6]).SetEquals("cdfgeb"));
            Assert.True(new HashSet<char>(numbers[7]).SetEquals("dab"));
            Assert.True(new HashSet<char>(numbers[8]).SetEquals("acedgfb"));
            Assert.True(new HashSet<char>(numbers[9]).SetEquals("cefabd"));

            Assert.Equal(5353, int.Parse(outputResult));
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn61229()
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                string[] input = data[i].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[0].Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
                string[] output = data[i].Split(" | ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);
                Dictionary<int, char[]> numbers = new();
                Dictionary<string, char> segments = new();
                numbers.Add(1, input.Where(x => x.Length == 2).First().ToCharArray());
                numbers.Add(7, input.Where(x => x.Length == 3).First().ToCharArray());
                numbers.Add(4, input.Where(x => x.Length == 4).First().ToCharArray());
                numbers.Add(8, input.Where(x => x.Length == 7).First().ToCharArray());

                // find top row
                segments.Add("top row", numbers[7].Where(c => !numbers[1].Contains(c)).First());

                // find bottom row and letters for 9
                string[] bottomRowCandidates = input.Where(x => x.Length == 6).ToArray();
                foreach (var candidate in bottomRowCandidates)
                {
                    string result = string.Empty;
                    result = RemoveCharsFromString(candidate, numbers[7]);
                    result = RemoveCharsFromString(result, numbers[4]);
                    if (result.Length == 1)
                    {
                        segments.Add("bottom row", result[0]);
                        numbers.Add(9, candidate.ToCharArray());
                    }
                }

                // find left bottom segment
                string[] leftBottomCandidates = input.Where(x => x.Length == 6).Where(x => x != new string(numbers[9])).ToArray();
                segments.Add("left bottom", RemoveCharsFromString(leftBottomCandidates[0], numbers[9]).First());

                // find middle row and zero
                foreach (var candidate in leftBottomCandidates)
                {
                    string result = string.Empty;
                    result = RemoveCharsFromString(new string(numbers[9]), numbers[1]);
                    result = RemoveCharsFromString(result, candidate.ToCharArray());
                    if (result.Length == 1)
                    {
                        segments.Add("middle row", result[0]);
                        numbers.Add(0, candidate.ToCharArray());
                    }
                    else
                        numbers.Add(6, candidate.ToCharArray());
                }

                // find right top
                segments.Add("right top", RemoveCharsFromString(new string(numbers[4]), numbers[6]).First());

                // find right bottom
                segments.Add("right bottom", RemoveCharsFromString(new string(numbers[1]), new char[] { segments["right top"] }).First());

                // find left top
                segments.Add("left top", RemoveCharsFromString("abcdefg", segments.Values.ToArray()).First());

                // find 2, 3, and 5
                string[] fiveSegCandidates = input.Where(x => x.Length == 5).ToArray();
                foreach (var candidate in fiveSegCandidates)
                {
                    string result = string.Empty;
                    result = RemoveCharsFromString(new string(numbers[1]), candidate.ToCharArray());
                    if (result.Length == 0)
                        numbers.Add(3, candidate.ToCharArray());
                    else if (result[0] == segments["right top"])
                        numbers.Add(5, candidate.ToCharArray());
                    else if (result[0] == segments["right bottom"])
                        numbers.Add(2, candidate.ToCharArray());
                }

                string outputResult = string.Empty;
                for (int j = 0; j < output.Length; j++)
                {
                    outputResult += GetNumberFromSegments(output[j], numbers);
                }

                sum += long.Parse(outputResult);
            }

            Assert.Equal(61229, sum);
        }

        private string RemoveCharsFromString(string source, char[] subtractions)
        {
            string result = string.Empty;
            result = String.Join("", source.Where(c => !subtractions.Contains(c)).ToArray());
            return result;
        }

        private int GetNumberFromSegments(string number, Dictionary<int, char[]> numbers)
        {
            string result = string.Empty;
            for (int i = 0; i < 10; i++)
                if (new HashSet<char>(number).SetEquals(numbers[i])) result += i.ToString();
            return int.Parse(result);
        }

        private string SampleData = "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe\nedbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc\nfgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg\nfbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb\naecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea\nfgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb\ndbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe\nbdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef\negadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb\ngcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";
    }
}