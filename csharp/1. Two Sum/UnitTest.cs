using Xunit;

namespace _1._Two_Sum;

public class UnitTest
{
    [Theory]
    [InlineData(new int[] { 4, 5, 1, 44, 666, 214214, 55, 4, 561 }, 5, new int[] { 0, 2 })]
    [InlineData(new int[] { 2, 7, 11, 15 }, 18, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void Tests(int[] testArray, int target, int[] expectedArray)
    {
        Solution solution = new Solution();
        Assert.Equal(solution.TwoSum(testArray, target), expectedArray);
    }
}