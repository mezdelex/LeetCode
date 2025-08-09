namespace csharp.src;

public readonly record struct RomanToIntegerSolution
{
    private static readonly Dictionary<char, int> _fromRomanValues = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 },
    };

    private static void SumValues(Stack<char> stack, ref int sum)
    {
        while (stack.Count > 0)
        {
            sum += _fromRomanValues[stack.Pop()];
        }
    }

    public static int RomanToInt(string input)
    {
        var sum = 0;
        var stack = new Stack<char>();

        Enumerable
            .Range(0, input.Length)
            .ToList()
            .ForEach(index =>
            {
                if (stack.Count == 0 || input[index].Equals(stack.Peek()) && stack.Count < 4)
                {
                    stack.Push(input[index]);
                }
                else
                {
                    if (stack.Count > 1)
                    {
                        SumValues(stack, ref sum);
                        stack.Push(input[index]);
                    }
                    else
                    {
                        if (_fromRomanValues[input[index]] > _fromRomanValues[stack.Peek()])
                        {
                            sum += _fromRomanValues[input[index]] - _fromRomanValues[stack.Pop()];
                        }
                        else
                        {
                            sum += _fromRomanValues[stack.Pop()];
                            stack.Push(input[index]);
                        }
                    }
                }
            });

        if (stack.Count > 0)
        {
            SumValues(stack, ref sum);
        }

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
        Assert.Equal(expected, RomanToIntegerSolution.RomanToInt(input));
    }
}
