using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode2021.Day05
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public List<Point> GetAllPointsOnLine()
        {
            List<Point> points = new();

            int x1 = Start.X, x2 = End.X;
            int y1 = Start.Y, y2 = End.Y;
            int dx = x2 - x1;
            int dy = y2 - y1;

            if ( dx == 0 )
                for (int y = Math.Min(y1,y2); y <= Math.Max(y1,y2); y++)
                    points.Add( new Point(x1, y) );
            else if ( dy == 0 )
                for (int x = Math.Min(x1,x2); x <= Math.Max(x1,x2); x++)
                    points.Add( new Point(x,y1) );
            else 
            {
                int slope = dx/dy;
                int b = y1 - (slope * x1);
                int x = x1;
                points.Add( new Point(x1,y1) );
                do
                {
                    x += (x1 < x2) ? 1 : -1;
                    int y = slope * x + b;
                    points.Add( new Point(x, y) );
                } while (x != x2);
            }

            return points;
        }

        public bool IsStraight()
            => IsHorizontal() || IsVertical();

        public bool IsHorizontal()
            => Start.Y == End.Y;

        public bool IsVertical()
            => Start.X == End.X;
    }
}