namespace AreasCounter;

public static class MatrixParser
{
    public static bool[,] ParseMartix(string str)
    {
        var rows = str.Split(';');
        var matrix = new bool[rows.Length, rows[0].Split(',').Length];

        for (int i = 0; i < rows.Length; i++)
        {
            var cols = rows[i].Split(',');
            for (int j = 0; j < cols.Length; j++)
            {
                matrix[i, j] = cols[j] == "1";
            }
        }
        return matrix;
    }

    public static bool TryParseMartix(string str, out bool[,] matrix)
    {
        try
        {
            matrix = ParseMartix(str);
            return true;
        }
        catch
        {
            matrix = new bool[0, 0];
            return false;
        }
    }
}
