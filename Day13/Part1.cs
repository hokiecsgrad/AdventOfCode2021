using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day13
{
    public class Part1
    {
        public void Run(string[] data)
        {
            List<Point> points = data.Where(s => new Regex(@"^[\d]+,[\d]+$").IsMatch(s))
                                     .Select(p => new Point(int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
                                     .ToList();
            int cols = points.Select(p => p.X).Max() + 1;
            int rows = points.Select(p => p.Y).Max() + 1;

            List<string> folds = data.Where(s => new Regex(@"[xy]=[\d]+$").IsMatch(s)).ToList();

            char[,] grid = new char[rows, cols];
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    if (points.Contains(new Point(col, row))) grid[row, col] = '#';
                    else grid[row, col] = '.';

            grid = Fold(grid, folds[0].Split('=')[0].Last(), int.Parse(folds[0].Split('=')[1]));

            int numDots = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    if (grid[row, col] == '#') numDots++;

            System.Console.WriteLine($"The number of dots visible is: {numDots}");
        }

        private char[,] Fold(char[,] grid, char dimension, int position)
        {
            char[,] newGrid;
            if (dimension == 'x')
            {
                int fold = grid.GetLength(1) - position;
                newGrid = new char[grid.GetLength(0), grid.GetLength(1) - fold];
                for (int row = 0; row < grid.GetLength(0); row++)
                    for (int col = newGrid.GetLength(1) - (fold - 1); col < newGrid.GetLength(1); col++)
                        newGrid[row, col] = (grid[row, col] == '#' || grid[row, grid.GetLength(1) - 1 - col] == '#') ? '#' : '.';
            }
            else
            {
                int fold = grid.GetLength(0) - position;
                newGrid = new char[grid.GetLength(0) - fold, grid.GetLength(1)];
                for (int row = newGrid.GetLength(0) - (fold - 1); row < newGrid.GetLength(0); row++)
                    for (int col = 0; col < newGrid.GetLength(1); col++)
                        newGrid[row, col] = (grid[row, col] == '#' || grid[grid.GetLength(0) - 1 - row, col] == '#') ? '#' : '.';
            }
            return newGrid;
        }
    }
}
