namespace AdventOfCode2021.Day11
{
    public class Board
    {
        public int[,] _board;

        public Board(string[] data)
        {
            _board = new int[data.Length, data[0].Length];
            for (int row = 0; row < data.Length; row++)
                for (int col = 0; col < data[0].Length; col++)
                    _board[row, col] = int.Parse(data[row][col].ToString());
        }

        public int Run(int numSteps = 100)
        {
            int totalFlashes = 0;
            for (int i = 0; i < numSteps; i++)
            {
                (_board, int numFlashes) = Tick(_board);
                totalFlashes += numFlashes;
            }
            return totalFlashes;
        }

        public int GetNumSquares()
            => _board.GetLength(0) * _board.GetLength(1);

        private (int[,], int) Tick(int[,] grid)
        {
            grid = IncrementEachSquare(grid);

            bool[,] flashMap = new bool[grid.GetLength(0), grid.GetLength(1)];
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    flashMap[row, col] = false;

            (grid, flashMap) = TriggerFlashes(grid, flashMap);
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    if (flashMap[row, col]) grid[row, col] = 0;

            int numFlashes = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    if (flashMap[row, col]) numFlashes++;

            return (grid, numFlashes);
        }

        public (int[,], bool[,]) TriggerFlashes(int[,] grid, bool[,] flashMap)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] > 9 && !flashMap[row, col])
                    {
                        flashMap[row, col] = true;
                        grid = IncrementNeighbors(row, col, grid);
                        (grid, flashMap) = TriggerFlashes(grid, flashMap);
                    }
                }
            return (grid, flashMap);
        }

        public int[,] IncrementNeighbors(int row, int col, int[,] grid)
        {
            for (int nRow = -1; nRow <= 1; nRow++)
                for (int nCol = -1; nCol <= 1; nCol++)
                    if (
                        (row + nRow >= 0 && row + nRow < grid.GetLength(0)) &&
                        (col + nCol >= 0 && col + nCol < grid.GetLength(1)) &&
                        !(nRow == 0 && nCol == 0)
                    )
                        grid[row + nRow, col + nCol] += 1;
            return grid;
        }

        public int[,] IncrementEachSquare(int[,] grid)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
                for (int col = 0; col < grid.GetLength(1); col++)
                    grid[row, col] += 1;
            return grid;
        }
    }
}