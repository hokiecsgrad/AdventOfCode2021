using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day04
{
    public class Parser
    {
        private string[] rawData;

        public Parser(string[] data)
        {
            rawData = new string[data.Length];
            Array.Copy(data, rawData, data.Length);
        }

        public int[] ReadNumbers()
        {
            return rawData[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        public Board[] ReadBoards()
        {
            Board[] boards = new Board[(rawData.Length - 1) / 6];
            int currBoard = 0;

            int[,] rows = new int[5,5];
            int currRow = 0;
            for (int i = 2; i < rawData.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(rawData[i]))
                {
                    boards[currBoard++] = new Board(rows);
                    rows = new int[5,5];
                    currRow = 0;
                    continue;
                }

                int[] temp = rawData[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int k = 0; k < 5; k++)
                    rows[currRow,k] = temp[k];
                currRow++;
            }
            boards[currBoard] = new Board(rows);

            return boards;
        }
    }
}