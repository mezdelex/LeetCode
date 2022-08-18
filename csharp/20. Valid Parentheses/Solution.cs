public record struct Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> dictionary = new Dictionary<char, char>(){
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