using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day06
{
    public class Part1
    {
        public void Run(string[] data)
        {
            List<int> ages = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            for (int i = 0; i < 80; i++)
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

            System.Console.WriteLine($"The number of fish after 80 days is: {ages.Count()}");
        }
    }
}
