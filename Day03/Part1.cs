using System;

namespace AdventOfCode2021
{
    public class Part1
    {
        public void Run(string[] data)
        {
            string gamma, epsilon;
            (gamma, epsilon) = CalculateGammaAndEpsilon(data);

            int powerConsumption = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            System.Console.WriteLine($"The power consumption is: {powerConsumption}");
        }

        public (string, string) CalculateGammaAndEpsilon(string[] data)
        {
            string gamma = string.Empty, epsilon = string.Empty;

            for (int currPos = 0; currPos < data[0].Length; currPos++)
            {
                int currSum = 0;
                for (int i = 0; i < data.Length; i++)
                    currSum += int.Parse(data[i][currPos].ToString());
                gamma += (currSum >= Math.Ceiling(data.Length / 2.0)) ? "1" : "0";
                epsilon += (currSum >= Math.Ceiling(data.Length / 2.0)) ? "0" : "1";
            }

            return (gamma, epsilon);
        }
    }
}