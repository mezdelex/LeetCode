public record struct LongestCommonPrefixSolution
{
    public string LongestCommonPrefix(string[] strs)
    {
        var prefix = "";
        var minLength = strs.Select(s => s.Length).Min();

        for (int i = 0; i < minLength; ++i)
        {
            var characters = strs.Select(s => s[i]).Distinct();

            if (characters.Count() > 1)
                break;

            prefix += characters.LastOrDefault();
        }

        return prefix;
    }
}

public class LongestCommonPrefixTests
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
        var solution = new LongestCommonPrefixSolution();

        Assert.Equal(expected, solution.LongestCommonPrefix(input));
    }
}
