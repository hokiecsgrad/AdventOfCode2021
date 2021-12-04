using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Part2
    {
        public void Run(string[] data)
        {
            int[] input = Array.ConvertAll(data, x => int.Parse(x));
            int[] triples = Enumerable.Range(0, input.Length - 2).Select(x => input[x] + input[x + 1] + input[x + 2]).ToArray();
            int numIncreases = Enumerable.Range(1, triples.Length - 1).Where(index => triples[index] > triples[index - 1]).Count();

            Console.WriteLine($"The number of increases in the data is: {numIncreases}");
        }
    }
}