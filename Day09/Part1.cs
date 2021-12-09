using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day09
{
    public class Part1
    {
        public void Run(string[] data)
        {
            int[,] grid = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[row].Length; col++)
                    grid[row,col] = int.Parse(data[row][col].ToString());

            List<Point> lowPoints = new();
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    if ( !GetAdjacentNeighbors(row,col,grid).Where(pt => grid[pt.X, pt.Y] <= grid[row,col]).Any() )
                        lowPoints.Add(new Point(row, col));

            int riskLevel = lowPoints.Select(pt => grid[pt.X, pt.Y] + 1).Sum();

            System.Console.WriteLine($"The risk level is: {riskLevel}");
        }

        public List<Point> GetAdjacentNeighbors(int row, int col, int[,] grid)
        {
            List<Point> neighbors = new();
            if ( row - 1 >=0 ) neighbors.Add(new Point(row-1, col));
            if ( col + 1 < grid.GetLength(1) ) neighbors.Add(new Point(row, col+1));
            if ( row + 1 < grid.GetLength(0) ) neighbors.Add(new Point(row + 1, col));
            if ( col - 1 >= 0 ) neighbors.Add(new Point(row, col-1));
            return neighbors;
        }
    }
}
