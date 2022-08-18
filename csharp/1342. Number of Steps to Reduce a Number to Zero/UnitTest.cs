namespace _1342._Number_of_Steps_to_Reduce_a_Number_to_Zero;

public record UnitTest
{
    [Theory]
    [InlineData(14, 6)]
    [InlineData(8, 4)]
    [InlineData(123, 12)]
    public void Tests(int input, int expected)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.NumberOfSteps(input), expected);
    }
}