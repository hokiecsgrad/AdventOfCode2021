using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day11
{
    public class Part1
    {
        public void Run(string[] data)
        {
            int numSteps = 100;
            Board board = new Board(data);
            int totalFlashes = board.Run(numSteps);
            System.Console.WriteLine($"After {numSteps} steps, the number of flashes were: {totalFlashes}");
        }
    }
}
