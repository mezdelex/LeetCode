public record struct Solution
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