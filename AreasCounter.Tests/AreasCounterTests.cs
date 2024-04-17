namespace AreasCounter.Tests;

public class AreasCounterTests
{
    [Theory]
    [MemberData(nameof(TestCases))]
    public void GivenMatrix_WhenCountAreas_ReturnsCorrectNumber(int expectedCount, bool[,] matrix)
    {
        // Arrange + Act
        var count = AreasCounter.CountAreas(matrix);

        // Assert
        Assert.Equal(expectedCount, count);
    }

    public static readonly IEnumerable<object[]> TestCases = new List<object[]>
    {
        new object[]
        {
            0,
            new bool[0,0]
        },
        new object[]
        {
            0,
            new bool[,] { { false } }
        },
        new object[]
        {
            1,
            new bool[,] { { true } }
        },
        new object[]
        {
            1,
            new bool[,] { { true, true } }
        },
        new object[]
        {
            2,
            new bool[,] { { true, false, true } }
        },
        new object[]
        {
            2,
            new bool[,]
            {
                { true, false, true },
                { true, false, true }
            }
        },
        new object[]
        {
            1,
            new bool[,]
            {
                { true, false, true },
                { true, true, true }
            }
        },
        new object[]
        {
            1,
            new bool[,]
            {
                { true, false, true },
                { true, true, true }
            }
        },
        new object[]
        {
            10,
            new bool[,]
            {
                { true, false, false, false, false, true, false, true, true, false, false, false },
                { false, true, true, false, true, false, false, false, true, true, false, true },
                { true, true, false, true, false, false, true, false, false, true, false, true },
                { true, true, false, true, false, false, true, false, true, false, true, false }
            }
        }
    };
}