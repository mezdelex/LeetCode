#include <vector>
#include <iostream>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    int removeElement(vector<int> &nums, int val)
    {
        int i = 0;
        int j = nums.size() - 1;

        while (i <= j)
            if (nums[i] == val)
                nums[i] = nums[j--];
            else
                ++i;

        return i;
    }

    void runTests()
    {
        vector<tuple<vector<int>, vector<int>, int, int>> tests{
            {vector<int>{1, 2, 3, 3}, vector<int>{1, 2, 3, 3}, 3, 2},
            {vector<int>{1, 0, 3, 5}, vector<int>{5, 0, 3, 1}, 1, 3},
            {vector<int>{1}, vector<int>{1}, 1, 0},
            {vector<int>{1}, vector<int>{1}, 0, 1},
            {vector<int>{}, vector<int>{}, 0, 0},
            {vector<int>{3, 2, 2, 3}, vector<int>{2, 2, 3, 3}, 3, 2},
            {vector<int>{0, 1, 2, 2, 3, 0, 4, 2}, vector<int>{0, 1, 4, 0, 3, 2, 2, 2}, 2, 5}};

        for (int i = 0; i < tests.size(); ++i)
        {
            assert(removeElement(get<0>(tests[i]), get<2>(tests[i])) == get<3>(tests[i]));

            int j = 0;
            for (; j < get<3>(tests[i]); ++j)
            {
                assert(get<0>(tests[i])[j] != get<2>(tests[i]));
                assert(get<0>(tests[i])[j] == get<1>(tests[i])[j]);
            }

            assert(j == get<3>(tests[i]));
        }
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
