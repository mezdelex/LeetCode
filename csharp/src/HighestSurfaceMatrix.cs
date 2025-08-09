namespace csharp.src;

public record struct HighestSquareSurfaceMatrix
{
    public static int HighestSquareSurface(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);

        if (rows == 0 || cols == 0)
        {
            return 0;
        }

        int[] dp = new int[cols];
        var maxSide = 0;

        for (var i = 0; i < rows; ++i)
        {
            var previousRowPreviousColValue = 0;
            for (var j = 0; j < cols; ++j)
            {
                var temp = dp[j];

                if (matrix[i, j] == 1)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[j] = 1;
                    }
                    else
                    {
                        dp[j] =
                            1 + Math.Min(dp[j], Math.Min(dp[j - 1], previousRowPreviousColValue));
                    }
                    maxSide = Math.Max(maxSide, dp[j]);
                }
                else
                {
                    dp[j] = 0;
                }

                previousRowPreviousColValue = temp;
            }
        }

        return maxSide * maxSide;
    }

    public class HighestSquareSurfaceMatrixTests()
    {
        public static TheoryData<int[,], int> HighestSquareSurfaceMatrixTestData =>
            new()
            {
                {
                    new[,]
                    {
                        { 1, 1, 0, 0 },
                        { 1, 1, 1, 1 },
                        { 0, 1, 1, 1 },
                        { 0, 1, 1, 1 },
                    },
                    9
                },
                {
                    new[,]
                    {
                        { 1, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                    },
                    16
                },
                {
                    new[,]
                    {
                        { 0, 1, 1, 1 },
                        { 1, 0, 1, 1 },
                        { 1, 1, 1, 1 },
                        { 1, 1, 1, 1 },
                    },
                    4
                },
            };

        [Theory]
        [MemberData(nameof(HighestSquareSurfaceMatrixTestData))]
        public void Tests(int[,] input, int expected)
        {
            Assert.Equal(expected, HighestSquareSurface(input));
        }
    }
}
