public record struct NumberOf1BitsSolution
{
    public int HammingWeight(uint n)
    {
        uint counter = 0;

        while (n > 0)
        {
            counter += n % 2;
            n /= 2;
        }

        return (int)counter;
    }

    public int HammingWeightLinQ(uint n) => Convert.ToString(n, 2).Count(bit => bit == '1');

    public int HammingWeightSystemLibrary(uint n) => System.Numerics.BitOperations.PopCount(n);
}

public class NumberOf1BitsTests
{
    [Theory]
    [InlineData("00000000000000000000000000001011", 3)]
    [InlineData("00000000000000000000000000000001", 1)]
    [InlineData("11111111111111111111111111111101", 31)]
    public void Tests(string input, int expected)
    {
        var temp = Convert.ToUInt32(input, 2);
        var solution = new NumberOf1BitsSolution();

        Assert.Equal(expected, solution.HammingWeight(temp));
        Assert.Equal(expected, solution.HammingWeightLinQ(temp));
        Assert.Equal(expected, solution.HammingWeightSystemLibrary(temp));
    }
}
