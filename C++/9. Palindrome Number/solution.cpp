#include <iostream>
#include <vector>
#include <tuple>

using namespace std;

class Solution
{
public:
    bool isPalindrome(int x)
    {
        if (x < 0 || x % 10 == 0 && x != 0)
            return false;

        uint64_t reversed = 0;
        int input, digit;
        input = x;

        do
        {
            digit = x % 10;
            x = x / 10;
            reversed = reversed * 10 + digit;
        } while (x != 0);

        return input == reversed;
    }

    void runTests()
    {
        vector<tuple<int, bool>> tests{
            {12344321, true},
            {-1221, false},
            {0, true}};

        for (int i = 0; i < tests.size(); ++i)
            isPalindrome(get<0>(tests[i]) == get<1>(tests[i]))
                ? cout << "Test" << i << ": OK" << endl
                : cout << "Test" << i << ": Failed" << endl;
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
