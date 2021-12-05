using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;


namespace AdventOfCode2021.Day05
{
    public class Parser
    {
        private string[] Data;

        public Parser(string[] data)
        {
            Data = new string[data.Length];
            Array.Copy(data, Data, data.Length);
        }

        public List<Line> ReadLines()
        {
            List<Line> lines = new();
            for (int i = 0; i < Data.Length; i++)
            {
                Point start, end;
                (start, end) = ( new Point(Data[i].Split(" -> ")[0]), new Point(Data[i].Split(" -> ")[1]));
                lines.Add( new Line(start, end) );
            }
            return lines;
        }
    }
}