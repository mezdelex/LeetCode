public record struct PalindromeNumberSolution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0 || x % 10 == 0 && x != 0)
            return false;

        var digit = 0;
        var input = x;
        var reversed = 0;

        do
        {
            digit = x % 10;
            x = x / 10;
            reversed = reversed * 10 + digit;
        } while (x != 0);

        return input == reversed;
    }
}

public class PalindromeNumberTests
{
    [Theory]
    [InlineData(12344321, true)]
    [InlineData(111, true)]
    [InlineData(-1221, false)]
    [InlineData(0, true)]
    public void Tests(int testNumer, bool expected)
    {
        var solution = new PalindromeNumberSolution();
        Assert.Equal(expected, solution.IsPalindrome(testNumer));
    }
}
