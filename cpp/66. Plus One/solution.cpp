#include <vector>
#include <iostream>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    vector<int> plusOne(vector<int> &digits)
    {
        for (int i = digits.size() - 1; i >= 0; --i)
        {
            if (digits[i] != 9)
            {
                ++digits[i];
                break;
            }
            else
            {
                digits[i] = 0;
            }
        }

        if (digits[0] == 0)
        {
            vector<int> head{1};
            move(digits.begin(), digits.end(), back_inserter(head));
            return head;
        }

        return digits;
    }

    void runTests()
    {
        vector<tuple<vector<int>, vector<int>>> tests{
            {{1, 2, 9}, {1, 3, 0}},
            {{1, 1, 1}, {1, 1, 2}},
            {{0}, {1}},
            {{9}, {1, 0}}};

        for (int i = 0; i < tests.size(); ++i)
            assert(plusOne(get<0>(tests[i])) == get<1>(tests[i]));
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
