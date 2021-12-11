using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day11
{
    public class Part2
    {
        public void Run(string[] data)
        {
            Board board = new Board(data);

            int numFlashes = 0;
            int step = 0;
            while (numFlashes < board.GetNumSquares())
            {
                numFlashes = board.Run(1);
                step++;
            }

            System.Console.WriteLine($"All octopi flash simultaneously after step: {step}");
        }
    }
}
