using System;

namespace AdventOfCode2021
{
    public class Part1
    {
        public void Run(string[] data)
        {
            int horizPos = 0;
            int depth = 0;
            foreach (var item in data)
            {
                string command = string.Empty;
                int value = 0;
                (command, value) = (item.Split(' ')[0], int.Parse(item.Split(' ')[1]));
                horizPos += command switch
                {
                    "forward" => value,
                    _ => 0,
                };
                depth += command switch
                {
                    "up" => value * -1,
                    "down" => value,
                    _ => 0,
                };
            }

            Console.WriteLine($"The product of horizontal position and depth is: {horizPos * depth}");
        }
    }
}