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
        public void CreateGraph_WithSampleData_ShouldReturnFullyFormedGraph()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            Graph g = new Graph(data);

            Assert.Equal(1, g._rootNode.Value);
        }

        [Fact]
        public void ShortestPath_WithSampleData_ShouldReturn40()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            Graph g = new Graph(data);

            Dictionary<string, int> path = g.FindShortestPath();

            Assert.Equal(40, path.Last().Value);
        }

        private string SampleData = "1163751742\n1381373672\n2136511328\n3694931569\n7463417111\n1319128137\n1359912421\n3125421639\n1293138521\n2311944581";
    }
}