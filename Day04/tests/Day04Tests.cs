using System;
using AdventOfCode2021.Day04;
using Xunit;

namespace AdventOfCode2021.Day04.Tests
{
    public class Day04Tests
    {
        string[] Data;
        Parser parser;

        public Day04Tests()
        {
            Data = SampleData.Split('\n');
            parser = new Parser(Data);
        }

        [Fact]
        public void ParseNumbers_WithSampleData_ShouldReturnArrayOfInts()
        {
            int[] randomNumbers = parser.ReadNumbers();

            Assert.Equal(27, randomNumbers.Length);
            Assert.Equal(17, randomNumbers[5]);
            Assert.Equal(1, randomNumbers[randomNumbers.Length-1]);
        }

        [Fact]
        public void BoardCtor_WithSampleData_ShouldReturnValidBoard()
        {
            Board board = new Board( new int[,] { {22,13,17,11,0}, {8,2,23,4,24}, {21,9,14,16,7}, {6,10,3,18,5}, {1,12,20,15,19} } );
            Assert.Equal(17, board.Data[0,2]);
            Assert.Equal(24, board.Data[1,4]);
            Assert.Equal(12, board.Data[4,1]);
        }

        [Fact]
        public void ParseBoards_WithSampleData_ShouldReturnArrayOfBingoBoards()
        {
            Board[] boards = parser.ReadBoards();

            Assert.Equal(3, boards.Length);
            Assert.Equal(13, boards[0].Data[0,1]);
            Assert.Equal(14, boards[0].Data[2,2]);
            Assert.Equal(7, boards[1].Data[2,2]);
            Assert.Equal(23, boards[2].Data[2,2]);
            Assert.Equal(3, boards[2].Data[4,3]);
        }

        [Fact]
        public void IsBingo_WithSampleData_ShouldReturnFalseUntil24IsDrawn()
        {
            int[] randomNumbers = new int[] {7,4,9,5,11,17,23,2,0,14,21,24};
            Board board = new Board(new int[,] { {14,21,17,24,4}, {10,16,15,9,19}, {18,8,23,26,20}, {22,11,13,6,5}, {2,0,12,3,7} });

            for (int rand = 0; rand < randomNumbers.Length; rand++)
                board.MarkNumber(randomNumbers[rand]);

            Assert.True(board.IsBingo());
        }

        [Fact]
        public void SumOfUnmarked_WithSampleDataAndThirdBoard_ShouldReturn188()
        {
            int[] randomNumbers = new int[] {7,4,9,5,11,17,23,2,0,14,21,24};
            Board board = new Board(new int[,] { {14,21,17,24,4}, {10,16,15,9,19}, {18,8,23,26,20}, {22,11,13,6,5}, {2,0,12,3,7} });

            for (int rand = 0; rand < randomNumbers.Length; rand++)
                board.MarkNumber(randomNumbers[rand]);

            Assert.Equal(188, board.GetSumOfUnmarkedSpaces());
        }

        [Fact]
        public void Part1_WithSampleData_ShouldReturn4512()
        {
            int[] randomNumbers = parser.ReadNumbers();
            Board[] boards = parser.ReadBoards();

            int randIndex = 0;
            int boardIndex = 0;
            int sumOfUnmarked = 0;
            for (randIndex = 0; randIndex < randomNumbers.Length; randIndex++)
            {
                bool breakLoops = false;
                for (boardIndex = 0; boardIndex < boards.Length; boardIndex++)
                {
                    boards[boardIndex].MarkNumber(randomNumbers[randIndex]);
                    if (boards[boardIndex].IsBingo()) 
                    {
                        sumOfUnmarked = boards[boardIndex].GetSumOfUnmarkedSpaces();
                        breakLoops = true; 
                        break; 
                    }
                }
                if (breakLoops) break;
            }

            Assert.Equal(2, boardIndex);
            Assert.Equal(11, randIndex);
            Assert.Equal(24, randomNumbers[randIndex]);
            Assert.Equal(188, sumOfUnmarked);
            Assert.Equal(4512, sumOfUnmarked * randomNumbers[randIndex]);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn1924()
        {
            int[] randomNumbers = parser.ReadNumbers();
            Board[] boards = parser.ReadBoards();

            int randIndex = 0;
            int boardIndex = 0;
            int lastBoardToWin = 0;
            bool breakLoops = false;
            for (randIndex = 0; randIndex < randomNumbers.Length; randIndex++)
            {
                for (boardIndex = 0; boardIndex < boards.Length; boardIndex++)
                {
                    boards[boardIndex].MarkNumber(randomNumbers[randIndex]);
                    if (boards[boardIndex].IsBingo() && HaveAllBoardsWon(boards)) 
                    {
                        lastBoardToWin = boardIndex;
                        breakLoops = true;
                        break;
                    }
                }
                if (breakLoops) break;
            }

            Assert.Equal(1, lastBoardToWin);
            Assert.Equal(13, randomNumbers[randIndex]);
            Assert.Equal(148, boards[lastBoardToWin].GetSumOfUnmarkedSpaces());
            Assert.Equal(1924, randomNumbers[randIndex] * boards[lastBoardToWin].GetSumOfUnmarkedSpaces());
        }

        private bool HaveAllBoardsWon(Board[] boards)
        {
            for (int i = 0; i < boards.Length; i++)
                if (!boards[i].IsBingo()) return false;
            return true;
        }

        private string SampleData = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";
     }
}