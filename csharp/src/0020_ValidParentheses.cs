public record struct ValidParenthesesSolution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new();
        Dictionary<char, char> dictionary = new() {
            {'{', '}'},
            {'[', ']'},
            {'(', ')'}
        };

        foreach (char character in s)
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
        ValidParenthesesSolution solution = new ValidParenthesesSolution();
        Assert.Equal(solution.IsValid(input), expected);
    }
}