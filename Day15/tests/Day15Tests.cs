using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day15;
using Xunit;

namespace AdventOfCode2021.Day15.Tests
{
    public class Day15Tests
    {
        [Fact]
        public void CreateGrid_WithSampleData_ShouldReturnTwoDimArray()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            int[,] grid = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[0].Length; col++)
                    grid[row, col] = int.Parse(data[row][col].ToString());
            grid[0, 0] = 0;

            Assert.Equal(10, grid.GetLength(0));
            Assert.Equal(10, grid.GetLength(1));
        }

        private string SampleData = "1163751742\n1381373672\n2136511328\n3694931569\n7463417111\n1319128137\n1359912421\n3125421639\n1293138521\n2311944581";
    }
}