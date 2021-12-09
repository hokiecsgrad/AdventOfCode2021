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

            long productOfBasinSizes = 0;
            Assert.Equal(1134, productOfBasinSizes);
        }


        public Day09Tests()
        {
            part1 = new Part1();
            data = SampleData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);    
            grid = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[row].Length; col++)
                    grid[row,col] = int.Parse(data[row][col].ToString());
        }
        
        private string[] data;
        private int[,] grid;
        private Part1 part1;

        private string SampleData = "2199943210\n3987894921\n9856789892\n8767896789\n9899965678";
    }
}