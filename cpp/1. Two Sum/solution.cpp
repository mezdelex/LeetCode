#include <vector>
#include <iostream>
#include <unordered_map>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    vector<int> twoSum(vector<int> &nums, int target)
    {
        unordered_map<int, int> map;

        for (int i = 0; i < nums.size(); ++i)
        {
            if (i != 0 && map.find(target - nums[i]) != map.end())
                return {map[target - nums[i]], i};

            map[nums[i]] = i;
        }

        return {};
    }

    void runTests()
    {
        vector<tuple<vector<int>, int, vector<int>>> tests{
            {{4, 5, 1, 44, 666, 214214, 55, 4, 561}, 5, {0, 2}},
            {{2, 7, 11, 15}, 9, {0, 1}},
            {{3, 3}, 6, {0, 1}}};

        for (int i = 0; i < tests.size(); ++i)
            assert(twoSum(get<0>(tests[i]), get<1>(tests[i])) == get<2>(tests[i]));
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
