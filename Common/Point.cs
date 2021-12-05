using System;

namespace AdventOfCode.Common
{
    public struct Point : IComparable<Point>, IEquatable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string xy)
        {
            (X, Y) = (int.Parse(xy.Split(',')[0]), int.Parse(xy.Split(',')[1]));
        }

        public static Point operator +(Point a, Vector b)
            => new Point(
                    a.X + b.X,
                    a.Y + b.Y
                    );

        public override int GetHashCode() => (X, Y).GetHashCode();

        public int CompareTo(Point other)
        {
            if (Equals(other)) return 0;

            if (X == other.X)
                if (Y > other.Y) return 1;
                else return -1;
            
            else if (X > other.X) return 1;
            
            else return -1;
        }

        public bool Equals(Point other)
        {
            return GetHashCode() == other.GetHashCode();
        }
    }
}