using System;

namespace AdventOfCode2021.Day04
{
    public class Board
    {
        public int[,] Data { get; set; } = new int[5,5];
        public bool[,] Marks { get; set; } = new bool[5,5];

        public Board(int[,] board)
        {
            Array.Copy(board, Data, 25);
        }

        public void MarkNumber(int num)
        {
            (int row, int col) = GetPositionFromNumber(num);
            if (row != -1)
            {
                Marks[row,col] = true;
            }
        }

        public (int, int) GetPositionFromNumber(int num)
        {
            for (int row = 0; row < Data.GetLength(0); row++)
                for (int col = 0; col < Data.GetLength(1); col++)
                    if (Data[row,col] == num) return (row, col);
            return (-1,-1);
        }

        public bool IsBingo()
        {
            for (int col = 0; col < Data.GetLength(1); col++)
                if (AreAllMarkedInCol(col)) return true;
            for (int row = 0; row < Data.GetLength(0); row++)
                if (AreAllMarkedInRol(row)) return true;
            return false;
        }

        private bool AreAllMarkedInRol(int row)
        {
            for (int col = 0; col < Data.GetLength(0); col++)
                if (!Marks[row,col]) return false;
            return true;
        }

        public bool AreAllMarkedInCol(int col)
        {
            for (int row = 0; row < Data.GetLength(0); row++)
                if (!Marks[row,col]) return false;
            return true;
        }

        public int GetSumOfUnmarkedSpaces()
        {
            int sum = 0;
            for (int row = 0; row < Data.GetLength(0); row++)
                for (int col = 0; col < Data.GetLength(1); col++)
                    if (! Marks[row,col]) sum += Data[row,col];
            return sum;
        }
    }
}