#include <vector>
#include <tuple>
#include <iostream>

using namespace std;

class Solution
{
public:
    int removeDuplicates(vector<int> &nums)
    {
        if (nums.size() == 0)
            return 0;

        int i = 0;
        for (int j = 1; j < nums.size(); ++j)
            if (nums[i] != nums[j])
                nums[++i] = nums[j];

        return i + 1;
    }

    void runTests()
    {
        vector<tuple<vector<int>, vector<int>, int>> tests{
            {{1, 1, 2, 2, 3, 4}, {1, 2, 3, 4, 0, 0}, 4},
            {{1, 2, 3}, {1, 2, 3}, 3},
            {{1}, {1}, 1},
            {{1, 1, 2}, {1, 2, 0}, 2},
            {{0, 0, 1, 1, 1, 2, 2, 3, 3, 4}, {0, 1, 2, 3, 4, 0, 0, 0, 0, 0}, 5}};

        for (int i = 0; i < tests.size(); ++i)
        {
            if (removeDuplicates(get<0>(tests[i])) == get<2>(tests[i]))
            {
                int j = 0;
                for (; j < get<2>(tests[i]) - 1; ++j)
                {
                    if (get<1>(tests[i])[j] >= get<1>(tests[i])[j + 1])
                    {
                        break;
                    }
                }

                j == get<2>(tests[i]) - 1
                    ? cout << "Test" << i << ": OK" << endl
                    : cout << "Test" << i << ": Failed" << endl;
            }
        }
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
