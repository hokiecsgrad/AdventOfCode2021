using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day08
{
    public class Part2
    {
        public void Run(string[] data)
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

            System.Console.WriteLine($"The sum of all the outputs is: {sum}");
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
    }
}
