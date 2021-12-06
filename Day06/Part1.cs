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
            int numDays = 80;

            Dictionary<int, long> ages = data[0].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(x => x)
                    .Select( x => new {Days = int.Parse(x.Key), Fish = (long)x.Count()} )
                    .ToDictionary(group => group.Days, group => group.Fish);
            ages.Add(0, 0);
            ages.Add(6, 0);
            ages.Add(7, 0);
            ages.Add(8, 0);
            
            for (int i = 0; i < numDays; i++)
            {
                long numBabies = ages[0];
                for (int j = 1; j <= ages.Count()-1; j++)
                    ages[j-1] = ages[j];
                ages[8] = numBabies;
                ages[6] += numBabies;
            }

            long sum = ages.Sum(x => x.Value);
            System.Console.WriteLine($"The number of fish after {numDays} days is: {sum}");
        }
    }
}
