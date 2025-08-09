namespace csharp.src;

public record struct LongestSubstringWithoutRepeatingCharactersSolution
{
    public static int LengthOfLongestSubstring(string s)
    {
        var maxLength = 0;
        var firstIndex = 0;
        var charIndexMap = new Dictionary<char, int>();

        Enumerable
            .Range(0, s.Length)
            .ToList()
            .ForEach(i =>
            {
                if (charIndexMap.TryGetValue(s[i], out int value) && value >= firstIndex)
                {
                    firstIndex = value + 1;
                }

                charIndexMap[s[i]] = i;

                maxLength = Math.Max(maxLength, i - firstIndex + 1);
            });

        return maxLength;
    }
}

public class LongestSubstringWithoutRepeatingCharactersSolutionTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("a", 1)]
    [InlineData("dvdf", 3)]
    [InlineData("aasdss", 3)]
    [InlineData("pwwkew", 3)]
    [InlineData("bbaarradusdnasd", 5)]
    public void Tests(string input, int expected)
    {
        Assert.Equal(
            expected,
            LongestSubstringWithoutRepeatingCharactersSolution.LengthOfLongestSubstring(input)
        );
    }
}
