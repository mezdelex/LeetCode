public record struct LongestSubstringWithoutRepeatingCharactersSolution
{
    public int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        var firstIndex = 0;
        var charIndexMap = new Dictionary<char, int>();

        Enumerable.Range(0, s.Length).ToList().ForEach(i =>
        {
            if (charIndexMap.ContainsKey(s[i]) && charIndexMap[s[i]] >= firstIndex)
                firstIndex = charIndexMap[s[i]] + 1;

            charIndexMap[s[i]] = i;

            maxLength = Math.Max(maxLength, i - firstIndex + 1);
        });

        return maxLength;
    }
}

public class LongestSubstringWithoutRepeatingCharactersSolutionTests
{
    [Theory]
    [InlineData("dvdf", 3)]
    [InlineData("aasdss", 3)]
    [InlineData("pwwkew", 3)]
    [InlineData("bbaarradusdnasd", 5)]
    public void Tests(string input, int expected)
    {
        var solution = new LongestSubstringWithoutRepeatingCharactersSolution();

        Assert.Equal(expected, solution.LengthOfLongestSubstring(input));
    }
}
