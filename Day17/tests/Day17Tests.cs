using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using AdventOfCode2021.Day17;
using Xunit;

namespace AdventOfCode2021.Day17.Tests
{
    public class Day17Tests
    {
        [Fact]
        public void Fire_WithExampleData_ShouldReturnTrue()
        {
            Point topLeft = new Point(20, -5);
            Point bottomRight = new Point(30, -10);
            Rectangle target = new Rectangle(topLeft, bottomRight);

            Point projectile = new Point(0,0);
            int maxHeight = int.MinValue;
            Vector bestInitialVelocity = new Vector(0,0);

            for (int initX = 1; initX < 20; initX++)
                for (int initY = 1; initY < 20; initY++)
                {
                    int localMax = maxHeight;

                    projectile = new Point(0,0);
                    Vector initialVelocity = new Vector(initX,initY);
                    Vector dragForce = new Vector(-1, 0);
                    Vector gravity = new Vector(0,-1);

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

            Assert.Equal(new Vector(6,9), bestInitialVelocity);
        }

        public string SampleData = "target area: x=20..30, y=-10..-5";
    }
}