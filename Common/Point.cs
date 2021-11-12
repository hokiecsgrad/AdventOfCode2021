namespace AdventOfCode.Common
{
    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point a, Vector b)
            => new Point(
                    a.X + b.X,
                    a.Y + b.Y
                    );
    }
}