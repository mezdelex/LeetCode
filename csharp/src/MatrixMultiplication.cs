namespace csharp.src;

public readonly record struct MatrixMultiplication
{
    private static readonly string _message =
        "Matrices cannot be multiplied. Number of columns in the first matrix must equal number of rows in the second matrix.";

    public static int[,] MultiplyMatrices(int[,] a, int[,] b)
    {
        var rowsA = a.GetLength(0);
        var colsA = a.GetLength(1);
        var rowsB = b.GetLength(0);
        var colsB = b.GetLength(1);

        if (colsA != rowsB)
        {
            throw new ArgumentException(_message);
        }

        var result = new int[rowsA, colsB];

        for (var i = 0; i < rowsA; ++i)
        {
            for (var j = 0; j < colsB; ++j)
            {
                for (var k = 0; k < colsA; ++k)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    public static int[,] MultiplyMatricesVector(int[,] a, int[,] b)
    {
        var rowsA = a.GetLength(0);
        var colsA = a.GetLength(1);
        var rowsB = b.GetLength(0);
        var colsB = b.GetLength(1);

        if (colsA != rowsB)
        {
            throw new ArgumentException(_message);
        }

        var result = new int[rowsA, colsB];

        if (!Vector.IsHardwareAccelerated)
        {
            return MultiplyMatrices(a, b);
        }

        var vectorSize = Vector<int>.Count;

        Span<int> tempColumnVectorData = stackalloc int[vectorSize];
        for (var i = 0; i < rowsA; ++i)
        {
            for (var j = 0; j < colsB; ++j)
            {
                var sumVector = Vector<int>.Zero;
                var k = 0;

                for (; k <= colsA - vectorSize; k += vectorSize)
                {
                    var vectorA = new Vector<int>(
                        MemoryMarshal.CreateReadOnlySpan(ref a[i, k], vectorSize)
                    );
                    for (int x = 0; x < vectorSize; ++x)
                    {
                        tempColumnVectorData[x] = b[k + x, j];
                    }
                    var vectorB = new Vector<int>(tempColumnVectorData);

                    sumVector += vectorA * vectorB;
                }

                for (var v = 0; v < vectorSize; ++v)
                {
                    result[i, j] += sumVector[v];
                }

                for (; k < colsA; ++k)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return result;
    }

    public class MatrixMultiplicationTests()
    {
        public static TheoryData<int[,], int[,], int[,]> MatrixTestData =>
            new()
            {
                {
                    new int[,]
                    {
                        { 1, 2 },
                        { 3, 4 },
                    },
                    new int[,]
                    {
                        { 5, 6 },
                        { 7, 8 },
                    },
                    new int[,]
                    {
                        { 19, 22 },
                        { 43, 50 },
                    }
                },
                {
                    new int[,]
                    {
                        { 1, 0 },
                        { 0, 1 },
                    },
                    new int[,]
                    {
                        { 5, 5 },
                        { 5, 5 },
                    },
                    new int[,]
                    {
                        { 5, 5 },
                        { 5, 5 },
                    }
                },
                {
                    new int[,]
                    {
                        { 1, 2, 3 },
                        { 4, 5, 6 },
                    },
                    new int[,]
                    {
                        { 7, 8 },
                        { 9, 1 },
                        { 2, 3 },
                    },
                    new int[,]
                    {
                        { 31, 19 },
                        { 85, 55 },
                    }
                },
                {
                    new int[,]
                    {
                        { 1, 2, 3, 4 },
                        { 5, 6, 7, 8 },
                        { 9, 10, 11, 12 },
                        { 13, 14, 15, 16 },
                    },
                    new int[,]
                    {
                        { 16, 15, 14, 13 },
                        { 12, 11, 10, 9 },
                        { 8, 7, 6, 5 },
                        { 4, 3, 2, 1 },
                    },
                    new int[,]
                    {
                        { 80, 70, 60, 50 },
                        { 240, 214, 188, 162 },
                        { 400, 358, 316, 274 },
                        { 560, 502, 444, 386 },
                    }
                },
            };

        [Theory]
        [MemberData(nameof(MatrixTestData))]
        public void Tests(int[,] inputA, int[,] inputB, int[,] expected)
        {
            Assert.Equal(expected, MultiplyMatrices(inputA, inputB));
            Assert.Equal(expected, MultiplyMatricesVector(inputA, inputB));
        }
    }
}
