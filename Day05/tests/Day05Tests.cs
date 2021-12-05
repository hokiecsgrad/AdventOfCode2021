using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day05;
using Xunit;

namespace AdventOfCode2021.Day05.Tests
{
    public class Day05Tests
    {
        [Fact]
        public void ParsePointsIntoLine_WithSampleData_ShouldReturnFirstTwoPoints()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Parser parser = new Parser(data);
            Line firstLine = parser.ReadLines().First();

            Assert.Equal(new Point(0,9), firstLine.Start);
            Assert.Equal(new Point(5,9), firstLine.End);
        }

        [Fact]
        public void LineIsStraight_WithSampleData_ShouldReturnTrueForFirstLine()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Parser parser = new Parser(data);
            Line firstLine = parser.ReadLines().First();

            Assert.False(firstLine.IsVertical());
            Assert.True(firstLine.IsStraight());
            Assert.True(firstLine.IsHorizontal());
        }

        [Fact]
        public void GetStraightLines_WithSampleData_ShouldReturnSixLines()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Parser parser = new Parser(data);
            List<Line> straightLines = parser.ReadLines().Where(x => x.IsStraight()).ToList();

            Assert.Equal(6, straightLines.Count);
        }

        [Fact]
        public void GetAllPointsOnLine_WithSampleData_ShouldReturnSixPoints()
        {
            Line line = new Line(new Point(0,9), new Point(5,9));
            List<Point> points = line.GetAllPointsOnLine();

            Assert.Equal(6, points.Count);
            Assert.Equal(new Point(3,9), points[3]);
            Assert.Equal(new Point(5,9), points[5]);
        }

        [Fact]
        public void Part1_WithSampleData_ShouldReturn5()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Parser parser = new Parser(data);
            List<Line> straightLines = parser.ReadLines().Where(x => x.IsStraight()).ToList();

            List<Point> allPoints = new();
            foreach (Line line in straightLines)
                allPoints.AddRange(line.GetAllPointsOnLine());
            var duplicatePoints = allPoints.OrderBy(x => x).GroupBy(x => x).Where(x => x.Count() > 1);

            Assert.Equal(5, duplicatePoints.Count());
        }

        [Fact]
        public void GetAllPointsOnLine_WithLeftToRightDiagonalLines_ShouldWork()
        {
            string[] data = new string[] {"0,0 -> 2,2", "0,2 -> 2,0"};
            Parser parser = new Parser(data);
            List<Line> allLines = parser.ReadLines();

            List<Point> allPoints = new();
            foreach (Line line in allLines)
                allPoints.AddRange(line.GetAllPointsOnLine());

            List<Point> expected = new List<Point> { new Point(0,0), new Point(1,1), new Point(2,2), new Point(0,2), new Point(1,1), new Point(2,0) };
            
            Assert.Equal(6, allPoints.Count());
            Assert.Equal(expected, allPoints);
        }

        [Fact]
        public void GetAllPointsOnLine_WithRightToLeftDiagonalLines_ShouldWork()
        {
            string[] data = new string[] {"2,2 -> 0,0", "2,0 -> 0,2"};
            Parser parser = new Parser(data);
            List<Line> allLines = parser.ReadLines();

            List<Point> allPoints = new();
            foreach (Line line in allLines)
                allPoints.AddRange(line.GetAllPointsOnLine());

            List<Point> expected = new List<Point> { new Point(2,2), new Point(1,1), new Point(0,0), new Point(2,0), new Point(1,1), new Point(0,2) };
            
            Assert.Equal(6, allPoints.Count());
            Assert.Equal(expected, allPoints);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn12()
        {
            string[] data = SampleData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            Parser parser = new Parser(data);
            List<Line> allLines = parser.ReadLines();

            List<Point> allPoints = new();
            foreach (Line line in allLines)
                allPoints.AddRange(line.GetAllPointsOnLine());
            var duplicatePoints = allPoints.OrderBy(x => x).GroupBy(x => x).Where(x => x.Count() > 1);

            Assert.Equal(12, duplicatePoints.Count());
        }

        private string SampleData = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

    }
}