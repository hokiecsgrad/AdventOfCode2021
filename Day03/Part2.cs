using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Part2 airQualCalc = new Part2();
            string oxygen = airQualCalc.CalculateOxygen(data);
            string co2 = airQualCalc.CalculateCo2(data);

            int airQuality = Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2);
            System.Console.WriteLine($"The air quality for the submarine is: {airQuality}");
        }

        public string CalculateOxygen(string[] data)
        {
            return CalculateAirQuality(data, true);
        }

        public string CalculateCo2(string[] data)
        {
            return CalculateAirQuality(data, false);
        }

        public string CalculateAirQuality(string[] data, bool upperBound = true)
        {
            List<string> airQuality = data.ToList();

            for (int currPos = 0; currPos < airQuality[0].Count(); currPos++)
            {
                Part1 calculator = new Part1();
                string gamma, epsilon, bounding;
                (gamma, epsilon) = calculator.CalculateGammaAndEpsilon(airQuality.ToArray());
                if (upperBound) bounding = gamma; else bounding = epsilon;

                List<char> mostCommon = new();
                mostCommon.AddRange(bounding);

                for (int i = airQuality.Count-1; i >= 0; i--)
                {
                    if (airQuality.Count == 1) break;
                    if (airQuality[i][currPos] != mostCommon[currPos]) 
                        airQuality.RemoveAt(i);
                }
            }

            return airQuality[0].ToString();
        }
    }
}