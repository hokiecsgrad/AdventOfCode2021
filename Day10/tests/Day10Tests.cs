using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day10;
using Xunit;

namespace AdventOfCode2021.Day10.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1_WithSampleData_ShouldReturn26397()
        {
            string[] data = SampleData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, int> Scores = new Dictionary<char, int> { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            Dictionary<char, int> Errors = new Dictionary<char, int> { { ')', 0 }, { ']', 0 }, { '}', 0 }, { '>', 0 } };

            Parser parser = new Parser();
            for (int i = 0; i < data.Length; i++)
            {
                (bool isCorrupted, char errorChar) = parser.HasCorruptedChunk(data[i]);
                if (isCorrupted)
                    Errors[errorChar]++;
            }

            long score = 0;
            foreach (var item in Errors)
                score += Scores[item.Key] * item.Value;
            Assert.Equal(26397, score);
        }

        [Theory]
        [InlineData("([])")]
        [InlineData("{()()()}")]
        [InlineData("<([{}])>")]
        [InlineData("[<>({}){}[([])<>]]")]
        [InlineData("(((((((((())))))))))")]
        public void IsValidChunk_WithExamplesOfGoodData_ShouldReturnTrue(string chunk)
        {
            Parser parser = new Parser();
            (bool isCorrupted, char errorChar) = parser.HasCorruptedChunk(chunk);
            Assert.False(isCorrupted);
        }

        [Theory]
        [InlineData("(]")]
        [InlineData("{()()()>")]
        [InlineData("(((()))}")]
        [InlineData("<([]){()}[{}])")]
        public void IsValidChunk_WithExamplesOfBadData_ShouldReturnFalse(string chunk)
        {
            Parser parser = new Parser();
            (bool isCorrupted, char errorChar) = parser.HasCorruptedChunk(chunk);
            Assert.True(isCorrupted);
        }

        [Fact]
        public void IsValidChunk_WithExampleOfBadChunkInLine_ShouldReturnFalse()
        {
            string line = "{([(<{}[<>[]}>{[]{[(<()>";
            Parser parser = new Parser();
            (bool isCorrupted, char errorChar) = parser.HasCorruptedChunk(line);
            Assert.True(isCorrupted);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn288957()
        {
            string[] data = SampleData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
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

            Assert.Equal(288957, finalScore);
        }

        [Theory]
        [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
        [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
        [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
        [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
        [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
        public void IsValidLine_WithValidExampleData_ShouldCompleteLine(string line, string expected)
        {
            Parser parser = new Parser();
            string ending = parser.CompleteLine(line);
            Assert.Equal(expected, ending);
        }

        private string SampleData = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
    }
}