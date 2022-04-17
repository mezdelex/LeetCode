#include <iostream>

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
        int testOne = 12344321;
        bool solutionOne = true;
        cout << (isPalindrome(testOne) == solutionOne ? "TestOne: OK" : "TestOne: Failed") << endl;

        int testTwo = -1221;
        bool solutionTwo = false;
        cout << (isPalindrome(testTwo) == solutionTwo ? "TestTwo: OK" : "TestTwo: Failed") << endl;

        int TestThree = 0;
        bool solutionThree = true;
        cout << (isPalindrome(TestThree) == solutionThree ? "TestThree: OK" : "TestThree: Failed") << endl;
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
