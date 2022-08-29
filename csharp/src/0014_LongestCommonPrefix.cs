public record struct LongestCommonPrefixSolution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string prefix = "";

        int minLength = strs.Select(str => str.Length).Min();

        for (int i = 0; i < minLength; ++i)
        {
            IEnumerable<char> characters = strs.Select(str => str[i]).Distinct();

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
        LongestCommonPrefixSolution solution = new LongestCommonPrefixSolution();
        Assert.Equal(solution.LongestCommonPrefix(input), expected);
    }
}