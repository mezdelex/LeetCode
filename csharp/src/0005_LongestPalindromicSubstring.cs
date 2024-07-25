public class LongestPalindromicSubstring
{
    private int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left].Equals(s[right]))
        {
            --left;
            ++right;
        }

        return right - left - 1;
    }

    public string LongestPalindrome(string s)
    {
        var start = 0;
        var end = 0;

        Enumerable
            .Range(0, s.Length)
            .ToList()
            .ForEach(i =>
            {
                var oddLength = ExpandAroundCenter(s, i, i);
                var evenLength = ExpandAroundCenter(s, i, i + 1);

                var maxLength = Math.Max(oddLength, evenLength);

                if (maxLength > end - start)
                {
                    start = i - (maxLength - 1) / 2;
                    end = i + maxLength / 2;
                }
            });

        return s.Substring(start, end - start + 1);
    }
}

public class LongestPalindromicSubstringTests
{
    [Theory]
    [InlineData("babad", "aba")]
    [InlineData("cbbd", "bb")]
    [InlineData("addffbffdfu", "dffbffd")]
    public void Tests(string input, string expected)
    {
        var solution = new LongestPalindromicSubstring();

        Assert.Equal(expected, solution.LongestPalindrome(input));
    }
}
