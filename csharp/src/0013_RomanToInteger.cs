public record struct RomanToIntegerSolution
{
    private static Dictionary<char, int> fromRomanValue = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

    private static void sumValues(Stack<char> stack, ref int sum)
    {
        while (stack.Count > 0)
            sum += fromRomanValue[stack.Pop()];
    }

    public int RomanToInt(string s)
    {
        int sum = 0;
        Stack<char> stack = new Stack<char>();

        Enumerable.Range(0, s.Length).ToList().ForEach(index =>
        {
            if (stack.Count == 0 || s[index].Equals(stack.Peek()) && stack.Count < 4)
                stack.Push(s[index]);
            else
            {
                if (stack.Count > 1)
                {
                    sumValues(stack, ref sum);
                    stack.Push(s[index]);
                }
                else
                {
                    if (fromRomanValue[s[index]] > fromRomanValue[stack.Peek()])
                        sum += fromRomanValue[s[index]] - fromRomanValue[stack.Pop()];
                    else
                    {
                        sum += fromRomanValue[stack.Pop()];
                        stack.Push(s[index]);
                    }
                }
            }
        });

        if (stack.Count > 0)
            sumValues(stack, ref sum);

        return sum;
    }
}

public class RomanToIntegerTests
{
    [Theory]
    [InlineData("IX", 9)]
    [InlineData("CCIX", 209)]
    [InlineData("CCCIX", 309)]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    [InlineData("DCXXI", 621)]
    public void Tests(string input, int expected)
    {
        RomanToIntegerSolution solution = new RomanToIntegerSolution();
        Assert.Equal(solution.RomanToInt(input), expected);
    }
}