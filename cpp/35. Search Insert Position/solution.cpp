#include <vector>
#include <tuple>
#include <iostream>
#include <cassert>

using namespace std;

class Solution
{
public:
    int searchInsert(vector<int> &nums, int target)
    {
        int min = 0, max = nums.size() - 1;

        while (min <= max)
        {
            const int MID = min + (max - min) / 2;

            if (nums[MID] == target)
                return MID;

            nums[MID] < target ? min = MID + 1 : max = MID - 1;
        }

        return min;
    }

    void runTests()
    {
        vector<tuple<vector<int>, int, int>> tests{
            {{1, 3, 5, 6}, 7, 4},
            {{1, 3}, 4, 2},
            {{1, 2, 3, 4}, 3, 2},
            {{1, 2, 3, 4}, 1, 0},
            {{1, 2, 3, 4}, 4, 3},
            {{1}, 3, 1},
            {{1}, 1, 0}};

        for (int i = 0; i < tests.size(); ++i)
            assert(searchInsert(get<0>(tests[i]), get<1>(tests[i])) == get<2>(tests[i]));
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
