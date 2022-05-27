public record struct Solution
{
    public int NumberOfSteps(int num)
    {
        int steps = 0;

        while (num != 0)
        {
            num = num % 2 == 0 ? num / 2 : --num;
            ++steps;
        }

        return steps;
    }
}
