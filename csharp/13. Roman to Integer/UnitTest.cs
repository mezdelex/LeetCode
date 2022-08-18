namespace _13._Roman_to_Integer;

public record UnitTest
{
    [Theory]
    [InlineData("IX", 9)]
    [InlineData("CCIX", 209)]
    [InlineData("CCCIX", 309)]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("DCXXI", 621)]
    public void Tests(string input, int expected)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.RomanToInt(input), expected);
    }
}