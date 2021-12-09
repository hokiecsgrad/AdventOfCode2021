using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day09
{
    public class Part2
    {
        public void Run(string[] data)
        {
            int[,] grid = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[row].Length; col++)
                    grid[row,col] = int.Parse(data[row][col].ToString());

            List<List<Point>> basins = new();
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row,col] == 9) continue;
                    bool pointInBasin = false;
                    foreach (var item in basins)
                    {
                        pointInBasin = item.Contains(new Point(row,col));
                        if (pointInBasin) break;
                    }
                    if ( !pointInBasin )
                    {
                        List<Point> basin = new();
                        FloodFillBasin(grid, new Point(row,col), basin);
                        basins.Add( basin );
                    }
                }

            long productOfBasinSizes = basins.OrderByDescending(x => x.Count()).Take(3).Aggregate(1, (prod, next) => prod *= next.Count());

            System.Console.WriteLine($"The product of the size of the largest 3 basis is: {productOfBasinSizes}");
        }

        public void FloodFillBasin(int[,] grid, Point curr, List<Point> basin)
        {
            if (grid[curr.X, curr.Y] == 9) return;
            if (basin.Contains(curr)) return;

            basin.Add(curr);

            if ( curr.X - 1 >=0 ) FloodFillBasin(grid, new Point(curr.X-1, curr.Y), basin);
            if ( curr.Y + 1 < grid.GetLength(1) ) FloodFillBasin(grid, new Point(curr.X, curr.Y+1), basin);
            if ( curr.X + 1 < grid.GetLength(0) ) FloodFillBasin(grid, new Point(curr.X + 1, curr.Y), basin);
            if ( curr.Y - 1 >= 0 ) FloodFillBasin(grid, new Point(curr.X, curr.Y-1), basin);
        }

    }
}