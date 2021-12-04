using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Part1
    {
        public void Run(string[] data)
        {
            int[] input = Array.ConvertAll(data, x => int.Parse(x));
            int numIncreases = Enumerable.Range(1, input.Length - 1).Where(index => input[index] > input[index - 1]).Count();

            Console.WriteLine($"The number of increases in the data is: {numIncreases}");
        }
    }
}