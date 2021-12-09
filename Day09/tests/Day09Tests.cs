using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day09;
using Xunit;

namespace AdventOfCode2021.Day09.Tests
{
    public class Day09Tests
    {
        [Fact]
        public void Part1_WithSampleData_ShouldReturn15()
        {
            List<Point> lowPoints = new();
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    if ( !part1.GetAdjacentNeighbors(row,col,grid).Where(pt => grid[pt.X, pt.Y] <= grid[row,col]).Any() )
                        lowPoints.Add(new Point(row, col));

            int riskLevel = lowPoints.Select(pt => grid[pt.X, pt.Y] + 1).Sum();

            Assert.Equal(15, riskLevel);
        }

        [Fact]
        public void GetAdjacentNeighbors_WithTopLeftCorner_ShouldReturn2Points()
        {
            List<Point> expected = new List<Point> { new Point(0,1), new Point(1,0) };
            Assert.Equal(expected, part1.GetAdjacentNeighbors(0,0,grid));
        }

        [Fact]
        public void GetAdjacentNeighbors_WithBottomRightCorner_ShouldReturn2Points()
        {
            List<Point> expected = new List<Point> { new Point(3,9), new Point(4,8) };
            Assert.Equal(expected, part1.GetAdjacentNeighbors(4,9,grid));
        }

        [Fact]
        public void GetAdjacentNeighbors_WithMiddlePoint_ShouldReturn4Points()
        {
            List<Point> expected = new List<Point> { new Point(1,4), new Point(2,5), new Point(3,4), new Point(2,3) };
            Assert.Equal(expected, part1.GetAdjacentNeighbors(2,4,grid));
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn1134()
        {
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
                        part2.FloodFillBasin(grid, new Point(row,col), basin);
                        basins.Add( basin );
                    }
                }

            long productOfBasinSizes = basins.OrderByDescending(x => x.Count()).Take(3).Aggregate(1, (prod, next) => prod *= next.Count());
            Assert.Equal(1134, productOfBasinSizes);
        }

        [Fact]
        public void FloodFill_WithExtraSmallGrid_ShouldReturn3PointsInBasin()
        {
            grid = new int[2,2] { { 2, 1 }, { 3, 9 } };
            List<Point> basin = new();
            part2.FloodFillBasin(grid, new Point(0,0), basin);
            Assert.Equal(3, basin.Count());
        }

        public Day09Tests()
        {
            part1 = new Part1();
            part2 = new Part2();
            data = SampleData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);    
            grid = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[row].Length; col++)
                    grid[row,col] = int.Parse(data[row][col].ToString());
        }
        
        private string[] data;
        private int[,] grid;
        private Part1 part1;
        private Part2 part2;

        private string SampleData = "2199943210\n3987894921\n9856789892\n8767896789\n9899965678";
    }
}