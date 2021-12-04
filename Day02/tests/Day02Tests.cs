using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2021.Tests
{
    public class Day02Tests
    {
        [Fact]
        public void CalculatePosition_WithSampleInput_ShouldReturn150()
        {
            string data = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            List<string> input = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            int horizPos = 0;
            int depth = 0;
            foreach (var item in input)
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

            Assert.Equal(15, horizPos);
            Assert.Equal(10, depth);
            Assert.Equal(150, horizPos * depth);
        }

        [Fact]
        public void CalculatePositionWithAim_WithSampleInput_ShouldReturn900()
        {
            string data = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            List<string> input = data.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
            double aim = 0;
            double horizPos = 0;
            double depth = 0;

            foreach (var item in input)
            {
                string command = string.Empty;
                int value = 0;
                (command, value) = (item.Split(' ')[0], int.Parse(item.Split(' ')[1]));
                aim += command switch
                {
                    "up" => value * -1,
                    "down" => value,
                    _ => 0,
                };
                if (command == "forward")
                {
                    horizPos += value;
                    depth += aim * value;
                }
            }

            Assert.Equal(15, horizPos);
            Assert.Equal(60, depth);
            Assert.Equal(900, horizPos * depth);
        }
    }
}