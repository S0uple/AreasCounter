namespace AreasCounter;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please enter a matrix in the following format: 1,0,1;0,1,0.");

        var str = Console.ReadLine();
        if (string.IsNullOrEmpty(str))
        {
            return;
        }

        if (!MatrixParser.TryParseMartix(str, out var matrix))
        {
            Console.WriteLine("Invalid matrix. Please try again.");
            return;
        }

        var areas = AreasCounter.CountAreas(matrix);
        Console.WriteLine($"Number of areas - {areas}");
    }
}