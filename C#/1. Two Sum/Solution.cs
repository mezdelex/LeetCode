using System;
using System.Collections.Generic;
using System.Linq;
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (i != 0 && dictionary.ContainsKey(target - nums[i]))
            {
                return new int[2] { dictionary[target - nums[i]], i };
            }

            dictionary[nums[i]] = i;
        }

        return new int[2];
    }

    private void RunTests()
    {
        List<(int[], int, int[])> tests = new List<(int[], int, int[])>
        {
            (new int[]{4, 5, 1, 44, 666, 214214, 55, 4, 561}, 5, new int[]{0,2}),
            (new int[]{2, 7, 11, 15}, 9, new int[]{0, 1}),
            (new int[]{3, 3}, 6, new int[]{0, 1})
        };

        for (int i = 0; i < tests.Count; ++i)
            Console.WriteLine(TwoSum(tests[i].Item1, tests[i].Item2).SequenceEqual(tests[i].Item3) ? $"Test{i}: OK" : $"Test{i}: Failed");
    }

    public static void Main()
    {
        Solution solution = new Solution();
        solution.RunTests();
    }
}