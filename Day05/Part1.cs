using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day05
{
    public class Part1
    {
        public void Run(string[] data)
        {
            Parser parser = new Parser(data);
            List<Line> straightLines = parser.ReadLines().Where(x => x.IsStraight()).ToList();

            List<Point> allPoints = new();
            foreach (Line line in straightLines)
                allPoints.AddRange(line.GetAllPointsOnLine());
            var duplicatePoints = allPoints.OrderBy(x => x).GroupBy(x => x).Where(x => x.Count() > 1);

            int sum = duplicatePoints.Count();
            System.Console.WriteLine($"The number of danger zones is: {sum}");
        }
    }
}
