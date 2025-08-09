namespace csharp.src;

public record struct NumberOf1BitsSolution
{
    public static int HammingWeight(uint n)
    {
        uint counter = 0;

        while (n > 0)
        {
            counter += n % 2;
            n /= 2;
        }

        return (int)counter;
    }

    public static int HammingWeightLinQ(uint n) =>
        Convert.ToString(n, 2).Count(bit => bit.Equals('1'));

    public static int HammingWeightSystemLibrary(uint n) => BitOperations.PopCount(n);
}

public class NumberOf1BitsTests
{
    [Theory]
    [InlineData("00000000000000000000000000001011", 3)]
    [InlineData("00000000000000000000000000000001", 1)]
    [InlineData("11111111111111111111111111111101", 31)]
    public void Tests(string input, int expected)
    {
        var uintInput = Convert.ToUInt32(input, 2);

        Assert.Equal(expected, NumberOf1BitsSolution.HammingWeight(uintInput));
        Assert.Equal(expected, NumberOf1BitsSolution.HammingWeightLinQ(uintInput));
        Assert.Equal(expected, NumberOf1BitsSolution.HammingWeightSystemLibrary(uintInput));
    }
}
