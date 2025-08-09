namespace csharp.src;

public record struct NumberOfStepsToReduceANumberToZeroSolution
{
    public static int NumberOfSteps(int num)
    {
        var steps = 0;

        while (num != 0)
        {
            num = num % 2 == 0 ? num / 2 : --num;
            ++steps;
        }

        return steps;
    }
}

public class NumberOfStepsToReduceANumberToZeroTests
{
    [Theory]
    [InlineData(14, 6)]
    [InlineData(8, 4)]
    [InlineData(123, 12)]
    public void Tests(int input, int expected)
    {
        Assert.Equal(expected, NumberOfStepsToReduceANumberToZeroSolution.NumberOfSteps(input));
    }
}
