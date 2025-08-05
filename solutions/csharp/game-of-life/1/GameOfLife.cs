using System;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] next = new int[rows, cols];

        int CountLiveNeighbors(int r, int c) 
        {
            int count = 0;

            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue;

                    int nr = r + dr;
                    int nc = c + dc;

                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                    {
                        count += matrix[nr, nc];
                    }
                }
            }
            return count;
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int liveNeighbors = CountLiveNeighbors(r, c);
                int current = matrix[r, c];

                if (current == 1 && (liveNeighbors == 2 || liveNeighbors == 3))
                    next[r, c] = 1;
                else if (current == 0 && liveNeighbors == 3)
                    next[r, c] = 1;
                else
                    next[r, c] = 0;
            }
        }

        return next;
    }
}
