using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day11;
using Xunit;

namespace AdventOfCode2021.Day11.Tests
{
    public class Day11Tests
    {
        [Fact]
        public void Part1_WithSampleData_ShouldReturn1656()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Board board = new Board(data);

            int totalFlashes = board.Run(100);

            int[,] expectedAfter100 = new int[,]
            {
                {0,3,9,7,6,6,6,8,6,6},
                {0,7,4,9,7,6,6,9,1,8},
                {0,0,5,3,9,7,6,9,3,3},
                {0,0,0,4,2,9,7,8,2,2},
                {0,0,0,4,2,2,9,8,9,2},
                {0,0,5,3,2,2,2,8,7,7},
                {0,5,3,2,2,2,2,9,6,6},
                {9,3,2,2,2,2,8,9,6,6},
                {7,9,2,2,2,8,6,8,6,6},
                {6,7,8,9,9,9,8,7,6,6}
            };

            Assert.Equal(expectedAfter100, board._board);
            Assert.Equal(1656, totalFlashes);
        }

        [Fact]
        public void Tick_WithExampleData_ShouldRunTwoStepsAndSucceed()
        {
            string[] data = "11111\n19991\n19191\n19991\n11111".Split('\n');
            Board board = new Board(data);

            int numFlashes;
            numFlashes = board.Run(1);
            int[,] step1 = new int[5, 5] { { 3, 4, 5, 4, 3 }, { 4, 0, 0, 0, 4 }, { 5, 0, 0, 0, 5 }, { 4, 0, 0, 0, 4 }, { 3, 4, 5, 4, 3 } };
            Assert.Equal(step1, board._board);
            Assert.Equal(9, numFlashes);

            numFlashes = board.Run(1);
            int[,] step2 = new int[5, 5] { { 4, 5, 6, 5, 4 }, { 5, 1, 1, 1, 5 }, { 6, 1, 1, 1, 6 }, { 5, 1, 1, 1, 5 }, { 4, 5, 6, 5, 4 } };
            Assert.Equal(step2, board._board);
            Assert.Equal(0, numFlashes);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn195()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Board board = new Board(data);

            int numFlashes = 0;
            int step = 0;
            while (numFlashes < board.GetNumSquares())
            {
                numFlashes = board.Run(1);
                step++;
            }

            Assert.Equal(195, step);
        }

        private string SampleData = "5483143223\n2745854711\n5264556173\n6141336146\n6357385478\n4167524645\n2176841721\n6882881134\n4846848554\n5283751526";
    }
}