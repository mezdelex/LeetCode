public class MedianOfTwoSortedArrays
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var orderedSecuence = nums1.Concat(nums2).Order().ToList();

        if (orderedSecuence.Count % 2 != 0)
            return orderedSecuence[orderedSecuence.Count / 2];

        return (float)(orderedSecuence[orderedSecuence.Count / 2 - 1] + orderedSecuence[orderedSecuence.Count / 2]) / 2;
    }
}

public class MedianOfTwoSortedArraysTests
{
    [Theory]
    [InlineData(new int[] { 4, 5, 2 }, new int[] { 5, 1 }, 4)]
    [InlineData(new int[] { 4 }, new int[] { 5 }, 4.5)]
    [InlineData(new int[] { 4, 2 }, new int[] { 5 }, 4)]
    [InlineData(new int[] { 4, 5 }, new int[] { 5, 1 }, 4.5)]
    public void Tests(int[] nums1, int[] nums2, double median)
    {
        var solution = new MedianOfTwoSortedArrays();

        Assert.Equal(median, solution.FindMedianSortedArrays(nums1, nums2));
    }
}
