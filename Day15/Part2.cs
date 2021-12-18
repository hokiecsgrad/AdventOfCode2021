using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day15
{
    public class Part2
    {
        public void Run(string[] data)
        {
            int path = Solve(ScaleUp(GetRiskLevelMap(data)));
            System.Console.WriteLine(path);
        }

        // solution from
        // https://github.com/encse/adventofcode/blob/master/2021/Day15/Solution.cs
        int Solve(Dictionary<Point, int> riskMap)
        {
            // Disjktra algorithm

            var topLeft = new Point(0, 0);
            var bottomRight = new Point(riskMap.Keys.MaxBy(p => p.X).X, riskMap.Keys.MaxBy(p => p.Y).Y);

            // Visit points in order of cumulated risk
            // ⭐ .Net 6 finally has a PriorityQueue collection :)
            var q = new PriorityQueue<Point, int>();
            var totalRiskMap = new Dictionary<Point, int>();

            totalRiskMap[topLeft] = 0;
            q.Enqueue(topLeft, 0);

            // Go until we find the bottom right corner
            while (true)
            {
                var p = q.Dequeue();

                if (p.Equals(bottomRight))
                {
                    break;
                }

                foreach (var n in Neighbours(p))
                {
                    if (riskMap.ContainsKey(n))
                    {
                        var totalRiskThroughP = totalRiskMap[p] + riskMap[n];
                        if (totalRiskThroughP < totalRiskMap.GetValueOrDefault(n, int.MaxValue))
                        {
                            totalRiskMap[n] = totalRiskThroughP;
                            q.Enqueue(n, totalRiskThroughP);
                        }
                    }
                }
            }

            // return bottom right corner's total risk:
            return totalRiskMap[bottomRight];
        }

        // Create an 5x scaled up map, as described in part 2
        Dictionary<Point, int> ScaleUp(Dictionary<Point, int> map)
        {
            var (ccol, crow) = (map.Keys.MaxBy(p => p.X).X + 1, map.Keys.MaxBy(p => p.Y).Y + 1);

            var res = new Dictionary<Point, int>(
                from y in Enumerable.Range(0, crow * 5)
                from x in Enumerable.Range(0, ccol * 5)

                    // x, y and risk level in the original map:
                let tileY = y % crow
                let tileX = x % ccol
                let tileRiskLevel = map[new Point(tileX, tileY)]

                // risk level is increased by tile distance from origin:
                let tileDistance = (y / crow) + (x / ccol)

                // risk level wraps around from 9 to 1:
                let riskLevel = (tileRiskLevel + tileDistance - 1) % 9 + 1
                select new KeyValuePair<Point, int>(new Point(x, y), riskLevel)
            );

            return res;
        }


        // store the points in a dictionary so that we can iterate over them and 
        // to easily deal with points outside the area
        Dictionary<Point, int> GetRiskLevelMap(string[] input)
        {
            return new Dictionary<Point, int>(
                from y in Enumerable.Range(0, input.Length)
                from x in Enumerable.Range(0, input[0].Length)
                select new KeyValuePair<Point, int>(new Point(x, y), input[y][x] - '0')
            );
        }

        IEnumerable<Point> Neighbours(Point point) =>
            new[] {
                new Point(point.X, point.Y+1),
                new Point(point.X, point.Y-1),
                new Point(point.X+1, point.Y),
                new Point(point.X-1, point.Y)
            };
    }
}
