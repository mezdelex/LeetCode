namespace csharp.src;

public record struct TwoSumSolution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; ++i)
        {
            if (i != 0 && dictionary.ContainsKey(target - nums[i]))
            {
                return [dictionary[target - nums[i]], i];
            }

            dictionary[nums[i]] = i;
        }

        return new int[2];
    }
}

public class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 4, 5, 1, 44, 666, 214214, 55, 4, 561 }, 5, new int[] { 0, 2 })]
    [InlineData(new int[] { 2, 7, 11, 15 }, 18, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void Tests(int[] testArray, int target, int[] expectedArray)
    {
        Assert.Equal(expectedArray, TwoSumSolution.TwoSum(testArray, target));
    }
}
