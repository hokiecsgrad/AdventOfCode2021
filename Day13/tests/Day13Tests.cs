using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode2021.Day13;
using Xunit;

namespace AdventOfCode2021.Day13.Tests
{
    public class Day13Tests
    {
        [Fact]
        public void CreateGrid_WithSampleData_ShouldReturnMaxX11AndMaxY15()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            List<Point> points = data.Where(s => new Regex(@"^[\d]+,[\d]+$").IsMatch(s))
                                     .Select(p => new Point(int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
                                     .ToList();
            int cols = points.Select(p => p.X).Max() + 1;
            int rows = points.Select(p => p.Y).Max() + 1;

            char[,] grid = new char[rows, cols];
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    grid[row, col] = '.';

            Assert.Equal(15, rows);
            Assert.Equal(11, cols);
        }

        [Fact]
        public void PopulateGrid_WithSampleData_ShouldReturnFilledInGrid()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            List<Point> points = data.Where(s => new Regex(@"^[\d]+,[\d]+$").IsMatch(s))
                                     .Select(p => new Point(int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
                                     .ToList();
            int cols = points.Select(p => p.X).Max() + 1;
            int rows = points.Select(p => p.Y).Max() + 1;

            char[,] grid = new char[rows, cols];
            for (int row = 0; row < rows; row++)
                for (int col = 0; col < cols; col++)
                    if (points.Contains(new Point(col, row))) grid[row, col] = '#';
                    else grid[row, col] = '.';

            char[,] expected = new char[,] {
                {'.','.','.','#','.','.','#','.','.','#','.'},
                {'.','.','.','.','#','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'#','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','#','.','.','.','.','#','.','#'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','#','.','.','.','.','#','.','#','#','.'},
                {'.','.','.','.','#','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','#','.','.','.','#'},
                {'#','.','.','.','.','.','.','.','.','.','.'},
                {'#','.','#','.','.','.','.','.','.','.','.'},
            };

            Assert.Equal(expected, grid);
        }

        [Fact]
        public void DisplayGrid_WithSampleDataAfter2Folds_ShouldShowSmallerGrid()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
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
            char[,] expected = new char[,] {
                {'#','.','#','#','.','.','#','.','.','#','.'},
                {'#','.','.','.','#','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','#','.','.','.','#'},
                {'#','.','.','.','#','.','.','.','.','.','.'},
                {'.','#','.','#','.','.','#','.','#','#','#'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.','.','.'},
            };
            Assert.Equal(expected, grid);

            grid = Fold(grid, folds[1].Split('=')[0].Last(), int.Parse(folds[1].Split('=')[1]));
            expected = new char[,] {
                {'#','#','#','#','#'},
                {'#','.','.','.','#'},
                {'#','.','.','.','#'},
                {'#','.','.','.','#'},
                {'#','#','#','#','#'},
                {'.','.','.','.','.'},
                {'.','.','.','.','.'},
            };
            Assert.Equal(expected, grid);
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

        private string SampleData = "6,10\n0,14\n9,10\n0,3\n10,4\n4,11\n6,0\n6,12\n4,1\n0,13\n10,12\n3,4\n3,0\n8,4\n1,10\n2,14\n8,10\n9,0\n\nfold along y=7\nfold along x=5";
    }
}