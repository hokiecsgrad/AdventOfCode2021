using System;

namespace AdventOfCode2021.Day04
{
    public class Part1
    {
        public void Run(string[] data)
        {
            Parser parser = new Parser(data);
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

            System.Console.WriteLine($"The score of the Bingo game is: {sumOfUnmarked * randomNumbers[randIndex]}");
        }
    }
}
