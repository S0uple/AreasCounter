namespace AreasCounter;

public static class AreasCounter
{
    /// <summary>
    /// Algorithm to count areas in a matrix.
    /// Time complexity - O(n) where n is the number of cells in the matrix.
    /// Memory complexity - O(n) where n is the number of cells in the matrix.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static int CountAreas(bool[,] matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }
        if (matrix.Length == 0)
        {
            return 0;
        }

        int count = 0;
        bool[,] skipMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (!matrix[i, j] || skipMatrix[i, j])
                {
                    continue;
                }

                MarkArea(matrix, skipMatrix, i, j);
                count++;
            }
        }

        return count;
    }

    private static void MarkArea(bool[,] matrix, bool[,] skipMatrix, int i, int j)
    {
        var cellsToCheck = new Stack<(int, int)>();
        cellsToCheck.Push((i, j));
        while (cellsToCheck.Count != 0)
        {
            var (x, y) = cellsToCheck.Pop();
            if (skipMatrix[x, y])
            {
                continue;
            }

            skipMatrix[x, y] = true;

            if (!matrix[x, y])
            {
                continue;
            }

            PushIfInBounds(matrix, x, y + 1, cellsToCheck);
            PushIfInBounds(matrix, x + 1, y, cellsToCheck);
            PushIfInBounds(matrix, x, y - 1, cellsToCheck);
            PushIfInBounds(matrix, x - 1, y, cellsToCheck);
        }
    }

    private static void PushIfInBounds(bool[,] matrix, int i, int j, Stack<(int, int)> stack)
    {
        if (i >= 0 && j >= 0 && i < matrix.GetLength(0) && j < matrix.GetLength(1))
        {
            stack.Push((i, j));
        }
    }
}
