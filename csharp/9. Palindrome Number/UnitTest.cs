using Xunit;

namespace _9._Palindrome_Number;

public record UnitTest
{
    [Theory]
    [InlineData(12344321, true)]
    [InlineData(-1221, false)]
    [InlineData(0, true)]
    public void Tests(int testNumer, bool expected)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.IsPalindrome(testNumer), expected);
    }
}