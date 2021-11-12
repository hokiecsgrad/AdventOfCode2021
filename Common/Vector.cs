namespace AdventOfCode.Common
{
    public struct Vector
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a, Vector b)
            => new Vector(
                        a.X + b.X,
                        a.Y + b.Y
                    );

        public static Point operator +(Vector a, Point b)
            => new Point(
                        a.X + b.X,
                        a.Y + b.Y
                    );
    }
}