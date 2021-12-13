using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day12;
using Xunit;

namespace AdventOfCode2021.Day12.Tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part1_WithSampleData_ShouldReturn226Paths()
        {
            string[] data = "fs-end\nhe - DX\nfs - he\nstart - DX\npj - DX\nend - zg\nzg - sl\nzg - pj\npj - he\nRW - he\nfs - DX\npj - RW\nzg - RW\nstart - pj\nhe - WI\nzg - he\npj - fs\nstart - RW".Split('\n');
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPaths();

            Assert.Equal(226, paths.Count());
        }

        [Fact]
        public void Part1_WithExampleData_ShouldReturn10Paths()
        {
            string[] data = "start-A\nstart-b\nA-c\nA-b\nb-d\nA-end\nb-end".Split('\n');
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPaths();

            Assert.Equal(10, paths.Count());
        }

        [Fact]
        public void CreateGraph_WithExampleData_ShouldCreate6NodeGraph()
        {
            string[] data = "start-A\nstart-b\nA-c\nA-b\nb-d\nA-end\nb-end".Split('\n');
            Graph g = new Graph(data);

            Assert.NotNull(g.GetRootNode());
        }

        [Fact]
        public void FindPaths_WithOnePath_ShouldReturnThatOnePath()
        {
            string[] data = "start-A\nA-end".Split('\n');
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPaths();

            Assert.Equal("start,A,end", paths.First());
        }

        [Fact]
        public void FindPaths_WithOneLargeCaveAndOneSmallCave_ShouldReturnFivePaths()
        {
            string[] data = "start-A\nstart-b\nA-b\nA-end\nb-end".Split('\n');
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPaths();

            Assert.Equal(5, paths.Count());
        }

        [Fact]
        public void Part2_WithExampleData_ShouldReturn36Paths()
        {
            string[] data = "start-A\nstart-b\nA-c\nA-b\nb-d\nA-end\nb-end".Split('\n');
            Graph g = new Graph(data);

            List<string> paths = new List<string>();
            paths = g.FindPathsWithOneSmallCaveVisitedTwice();
            paths = paths.Distinct().ToList();

            Assert.Equal(36, paths.Count());
        }
    }
}