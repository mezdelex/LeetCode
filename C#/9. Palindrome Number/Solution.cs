public record struct Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0 || x % 10 == 0 && x != 0)
            return false;

        long reversed = 0;
        int input, digit;
        input = x;

        do
        {
            digit = x % 10;
            x = x / 10;
            reversed = reversed * 10 + digit;
        } while (x != 0);

        return input == reversed;
    }
}
