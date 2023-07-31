public record struct RomanToIntegerSolution
{
    private static Dictionary<char, int> fromRomanValues = new()
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
            sum += fromRomanValues[stack.Pop()];
    }

    public int RomanToInt(string input)
    {
        var sum = 0;
        var stack = new Stack<char>();

        Enumerable.Range(0, input.Length).ToList().ForEach(index =>
        {
            if (stack.Count == 0 || input[index].Equals(stack.Peek()) && stack.Count < 4)
                stack.Push(input[index]);
            else
            {
                if (stack.Count > 1)
                {
                    sumValues(stack, ref sum);
                    stack.Push(input[index]);
                }
                else
                {
                    if (fromRomanValues[input[index]] > fromRomanValues[stack.Peek()])
                        sum += fromRomanValues[input[index]] - fromRomanValues[stack.Pop()];
                    else
                    {
                        sum += fromRomanValues[stack.Pop()];
                        stack.Push(input[index]);
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
        var solution = new RomanToIntegerSolution();

        Assert.Equal(expected, solution.RomanToInt(input));
    }
}
