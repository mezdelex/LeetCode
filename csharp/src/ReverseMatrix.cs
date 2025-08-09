namespace csharp.src;

public record struct ReverseMatrix
{
    public static int[,] Reverse(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        var reversed = new int[cols, rows];

        for (var i = 0; i < rows; ++i)
        {
            for (var j = 0; j < cols; ++j)
            {
                reversed[rows - 1 - i, cols - 1 - j] = matrix[i, j];
            }
        }

        return reversed;
    }

    public class ReverseMatrixTests()
    {
        public static TheoryData<int[,], int[,]> MatrixTestData =>
            new()
            {
                {
                    new[,]
                    {
                        { 1, 2, 3 },
                        { 4, 5, 6 },
                        { 7, 8, 9 },
                    },
                    new[,]
                    {
                        { 9, 8, 7 },
                        { 6, 5, 4 },
                        { 3, 2, 1 },
                    }
                },
            };

        [Theory]
        [MemberData(nameof(MatrixTestData))]
        public void Tests(int[,] input, int[,] expected)
        {
            Assert.Equal(expected, Reverse(input));
        }
    }
}
