namespace _20._Valid_Parentheses;

public record UnitTest
{
    [Theory]
    [InlineData("[[]]{}(())", true)]
    [InlineData("[)", false)]
    [InlineData("[]{{{}}}", true)]
    [InlineData(")()(", false)]
    [InlineData("{[]}", true)]
    public void Tests(string input, bool expected)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.IsValid(input), expected);
    }
}