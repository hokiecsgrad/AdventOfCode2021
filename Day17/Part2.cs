using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day17
{
    public class Part2
    {
        public void Run(string[] data)
        {
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

            Point projectile = new Point(0, 0);
            int maxHeight = int.MinValue;
            Vector bestInitialVelocity = new Vector(0, 0);
            List<Vector> allVelocitiesThatHitTarget = new();

            for (int initX = 1; initX < 200; initX++)
                for (int initY = 200; initY > -200; initY--)
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
                        allVelocitiesThatHitTarget.Add(initialVelocity);

                    if (target.HitBy(projectile) && localMax > maxHeight)
                    {
                        maxHeight = localMax;
                        bestInitialVelocity = initialVelocity;
                    }
                }

            System.Console.WriteLine($"The number of initial velocities that hit the target is: {allVelocitiesThatHitTarget.Count()}");
        }
    }
}
