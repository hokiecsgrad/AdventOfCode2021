using System;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day17
{
    public class Rectangle
    {
        public Point TopLeft { get; private set; }
        public Point BottomRight { get; private set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public bool HitBy(Point projectile)
        {
            if (
                projectile.X >= TopLeft.X &&
                projectile.X <= BottomRight.X &&
                projectile.Y <= TopLeft.Y &&
                projectile.Y >= BottomRight.Y 
            )
                return true;

            return false;
        }
    }
}