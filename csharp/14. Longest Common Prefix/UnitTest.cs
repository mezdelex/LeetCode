namespace _14._Longest_Common_Prefix;

public record UnitTest
{
    [Theory]
    [InlineData(new string[] { "paco", "pac", "paaaa" }, "pa")]
    [InlineData(new string[] { "p" }, "p")]
    [InlineData(new string[] { "algo", "distinto" }, "")]
    [InlineData(new string[] { "cir", "car" }, "c")]
    [InlineData(new string[] { "abab", "aba", "" }, "")]
    [InlineData(new string[] { "ac", "ac", "a", "a" }, "a")]
    [InlineData(new string[] { "baab", "bacb", "b", "cbc" }, "")]
    [InlineData(new string[] { "a" }, "a")]
    [InlineData(new string[] { "ab", "a" }, "a")]
    [InlineData(new string[] { "flower", "flower", "flower", "flower" }, "flower")]
    public void Tests(string[] input, string expected)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.LongestCommonPrefix(input), expected);
    }
}