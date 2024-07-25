public record struct ValidParenthesesSolution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        var dictionary = new Dictionary<char, char>
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' }
        };

        foreach (var character in s)
        {
            if (stack.Count != 0 && dictionary[stack.Peek()] == character)
                stack.Pop();
            else if (!dictionary.ContainsKey(character))
                return false;
            else
                stack.Push(character);
        }

        return stack.Count == 0;
    }
}

public class ValidParenthesesTests
{
    [Theory]
    [InlineData("[[]]{}(())", true)]
    [InlineData("[)", false)]
    [InlineData("[]{{{}}}", true)]
    [InlineData(")()(", false)]
    [InlineData("{[]}", true)]
    public void Tests(string input, bool expected)
    {
        var solution = new ValidParenthesesSolution();

        Assert.Equal(expected, solution.IsValid(input));
    }
}
