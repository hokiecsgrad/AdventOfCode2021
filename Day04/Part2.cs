using System;

namespace AdventOfCode2021.Day04
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Parser parser = new Parser(data);
            int[] randomNumbers = parser.ReadNumbers();
            Board[] boards = parser.ReadBoards();

            int randIndex = 0;
            int boardIndex = 0;
            bool breakLoops = false;
            for (randIndex = 0; randIndex < randomNumbers.Length; randIndex++)
            {
                for (boardIndex = 0; boardIndex < boards.Length; boardIndex++)
                {
                    boards[boardIndex].MarkNumber(randomNumbers[randIndex]);
                    if (boards[boardIndex].IsBingo() && HaveAllBoardsWon(boards)) 
                    {
                        breakLoops = true;
                        break;
                    }
                }
                if (breakLoops) break;
            }

            System.Console.WriteLine($"The score of the Bingo game is: {randomNumbers[randIndex] * boards[boardIndex].GetSumOfUnmarkedSpaces()}");
        }

        private bool HaveAllBoardsWon(Board[] boards)
        {
            for (int i = 0; i < boards.Length; i++)
                if (!boards[i].IsBingo()) return false;
            return true;
        }

    }
}
