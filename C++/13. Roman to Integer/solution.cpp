#include <string>
#include <iostream>
#include <queue>

using namespace std;

class Solution
{
public:
    int fromRomanValue(char c)
    {
        switch (c)
        {
        case 'I':
            return 1;
        case 'V':
            return 5;
        case 'X':
            return 10;
        case 'L':
            return 50;
        case 'C':
            return 100;
        case 'D':
            return 500;
        case 'M':
            return 1000;
        default:
            return 0;
        }
    }

    void sumValues(queue<char> &queue, int &sum)
    {
        while (queue.size() != 0)
        {
            sum += fromRomanValue(queue.back());
            queue.pop();
        }
    }

    int romanToInt(string s)
    {
        int sum = 0;
        queue<char> queue;

        for (int i = 0; i < s.size(); ++i)
        {
            if (queue.empty() || s[i] == queue.back() && queue.size() < 4)
            {
                queue.push(s[i]);
            }
            else
            {
                if (queue.size() > 1)
                {
                    sumValues(queue, sum);
                    queue.push(s[i]);
                }
                else
                {
                    if (fromRomanValue(s[i]) > fromRomanValue(queue.back()))
                    {
                        sum += (fromRomanValue(s[i]) - fromRomanValue(queue.back()));
                        queue.pop();
                    }
                    else
                    {
                        sum += fromRomanValue(queue.back());
                        queue.pop();
                        queue.push(s[i]);
                    }
                }
            }
        }

        if (!queue.empty())
            sumValues(queue, sum);

        return sum;
    }

    void runTests()
    {
        string testOne = "IX";
        int expectedOne = 9;
        cout << (romanToInt(testOne) == expectedOne ? "TestOne: OK" : "TestOne: Failed") << endl;

        string testTwo = "CCIX";
        int expectedTwo = 209;
        cout << (romanToInt(testTwo) == expectedTwo ? "TestTwo: OK" : "TestTwo: Failed") << endl;

        string testThree = "CCCIX";
        int expectedThree = 309;
        cout << (romanToInt(testThree) == expectedThree ? "TestThree: OK" : "TestThree: Failed") << endl;

        string testFour = "CCCXCIV";
        int expectedFour = 394;
        cout << (romanToInt(testFour) == expectedFour ? "TestFour: OK" : "TestFour: Failed") << endl;

        string testFive = "III";
        int expectedFive = 3;
        cout << (romanToInt(testFive) == expectedFive ? "TestFive: OK" : "TestFive: Failed") << endl;

        string testSix = "LVIII";
        int expectedSix = 58;
        cout << (romanToInt(testSix) == expectedSix ? "TestSix: OK" : "TestSix: Failed") << endl;

        string testSeven = "MCMXCIV";
        int expectedSeven = 1994;
        cout << (romanToInt(testSeven) == expectedSeven ? "TestSeven: OK" : "TestSeven: Failed") << endl;

        string testEight = "DCXXI";
        int expectedEight = 621;
        cout << (romanToInt(testEight) == expectedEight ? "TestEight: OK" : "TestEight: Failed") << endl;
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
