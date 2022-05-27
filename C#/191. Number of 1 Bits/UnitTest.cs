namespace _191._Number_of_1_Bits;

public record UnitTest
{
    [Theory]
    [InlineData("00000000000000000000000000001011", 3)]
    [InlineData("00000000000000000000000000000001", 1)]
    [InlineData("11111111111111111111111111111101", 31)]
    public void Tests(string input, int expected)
    {
        uint temp = Convert.ToUInt32(input, 2);

        Solution solution = new Solution();
        Assert.Equal(solution.HammingWeight(temp), expected);
        Assert.Equal(solution.HammingWeightLinQ(temp), expected);
        Assert.Equal(solution.HammingWeightSystemLibrary(temp), expected);
    }
}