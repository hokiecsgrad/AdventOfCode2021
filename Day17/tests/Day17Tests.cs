using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode2021.Day17;
using Xunit;

namespace AdventOfCode2021.Day17.Tests
{
    public class Day17Tests
    {
        [Fact]
        public void ParseInput_WithExampleData_ShouldReturnData()
        {
            // target area: x=20..30, y=-10..-5
            string[] data = SampleData.Split('\n', StringSplitOptions.TrimEntries);
            int x1, x2, y1, y2;
            Regex targetCoords = new Regex(@"x=([-\d]+..[-\d]+), y=([-\d]+..[-\d]+)");
            MatchCollection matches = targetCoords.Matches(data[0]);
            x1 = int.Parse(matches[0].Groups[1].Value.Split("..")[0]);
            x2 = int.Parse(matches[0].Groups[1].Value.Split("..")[1]);
            y1 = int.Parse(matches[0].Groups[2].Value.Split("..")[0]);
            y2 = int.Parse(matches[0].Groups[2].Value.Split("..")[1]);
            Point topLeft = new Point(Math.Min(x1, x2), Math.Max(y1, y2));
            Point bottomRight = new Point(Math.Max(x1, x2), Math.Min(y1, y2));
            Rectangle target = new Rectangle(topLeft, bottomRight);

            Assert.Equal(20, target.TopLeft.X);
            Assert.Equal(-5, target.TopLeft.Y);
            Assert.Equal(30, target.BottomRight.X);
            Assert.Equal(-10, target.BottomRight.Y);
        }

        [Fact]
        public void Fire_WithExampleData_ShouldReturnX6Y9()
        {
            Point topLeft = new Point(20, -5);
            Point bottomRight = new Point(30, -10);
            Rectangle target = new Rectangle(topLeft, bottomRight);

            Point projectile = new Point(0, 0);
            int maxHeight = int.MinValue;
            Vector bestInitialVelocity = new Vector(0, 0);

            for (int initX = 1; initX < 20; initX++)
                for (int initY = 1; initY < 20; initY++)
                {
                    int localMax = maxHeight;

                    projectile = new Point(0, 0);
                    Vector initialVelocity = new Vector(initX, initY);
                    Vector dragForce = new Vector(-1, 0);
                    Vector gravity = new Vector(0, -1);

                    Vector currVelocity = initialVelocity;
                    while (projectile.Y > target.BottomRight.Y && !target.HitBy(projectile))
                    {
                        projectile += currVelocity;
                        if (projectile.Y > localMax)
                            localMax = projectile.Y;
                        if (currVelocity.X != 0)
                            currVelocity += dragForce;
                        currVelocity += gravity;
                    }

                    if (target.HitBy(projectile) && localMax > maxHeight)
                    {
                        maxHeight = localMax;
                        bestInitialVelocity = initialVelocity;
                    }
                }

            Assert.Equal(new Vector(6, 9), bestInitialVelocity);
        }

        [Fact]
        public void Part2_WithSampleData_ShouldReturn112()
        {
            Point topLeft = new Point(20, -5);
            Point bottomRight = new Point(30, -10);
            Rectangle target = new Rectangle(topLeft, bottomRight);

            Point projectile = new Point(0, 0);
            int maxHeight = int.MinValue;
            Vector bestInitialVelocity = new Vector(0, 0);
            int numVelocitiesThatHitTarget = 0;

            for (int initX = 1; initX < 50; initX++)
                for (int initY = 50; initY > -50; initY--)
                {
                    int localMax = maxHeight;

                    projectile = new Point(0, 0);
                    Vector initialVelocity = new Vector(initX, initY);
                    Vector dragForce = new Vector(-1, 0);
                    Vector gravity = new Vector(0, -1);

                    Vector currVelocity = initialVelocity;
                    while (projectile.Y > target.BottomRight.Y && !target.HitBy(projectile))
                    {
                        projectile += currVelocity;
                        if (projectile.Y > localMax)
                            localMax = projectile.Y;
                        if (currVelocity.X != 0)
                            currVelocity += dragForce;
                        currVelocity += gravity;
                    }

                    if (target.HitBy(projectile))
                        numVelocitiesThatHitTarget++;

                    if (target.HitBy(projectile) && localMax > maxHeight)
                    {
                        maxHeight = localMax;
                        bestInitialVelocity = initialVelocity;
                    }
                }

            Assert.Equal(112, numVelocitiesThatHitTarget);
        }

        public string SampleData = "target area: x=20..30, y=-10..-5";
    }
}