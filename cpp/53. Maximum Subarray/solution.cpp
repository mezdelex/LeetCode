#include <vector>
#include <iostream>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    int maxSubArray(vector<int> &nums)
    {
        int max = INT_MIN;
        int sum = 0;

        for (int i = 0; i < nums.size(); ++i)
        {
            sum += nums[i];

            if (sum > max)
                max = sum;

            if (sum < 0)
                sum = 0;
        }

        return max;
    }

    int maxSubArrayKadane(vector<int> &nums)
    {
        int max_sum = nums[0];
        int cur_sum = nums[0];

        for (int i = 1; i < nums.size(); ++i)
        {
            cur_sum = max(nums[i], cur_sum + nums[i]);
            max_sum = max(max_sum, cur_sum);
        }

        return max_sum;
    }

    void runTests()
    {
        vector<tuple<vector<int>, int>> tests{
            {{-2, 1, -3, 4, -1, 2, 1, -5, 4}, 6},
            {{1, 2, 3, 4, 5, 6, -1, 2, 3}, 25},
            {{0, 0, 0, 1}, 1},
            {{-1, 0, -1, 0}, 0},
            {{1, 0}, 1},
            {{-4, 5, 7, -6, 10, -15, 3}, 16}};

        for (int i = 0; i < tests.size(); ++i)
        {
            assert(maxSubArray(get<0>(tests[i])) == get<1>(tests[i]));
            assert(maxSubArrayKadane(get<0>(tests[i])) == get<1>(tests[i]));
        }
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
