#include <string>
#include <iostream>
#include <stack>
#include <vector>
#include <tuple>

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

    void sumValues(stack<char> &stack, int &sum)
    {
        while (stack.size() != 0)
        {
            sum += fromRomanValue(stack.top());
            stack.pop();
        }
    }

    int romanToInt(string s)
    {
        int sum = 0;
        stack<char> stack;

        for (int i = 0; i < s.size(); ++i)
        {
            if (stack.empty() || s[i] == stack.top() && stack.size() < 4)
            {
                stack.push(s[i]);
            }
            else
            {
                if (stack.size() > 1)
                {
                    sumValues(stack, sum);
                    stack.push(s[i]);
                }
                else
                {
                    if (fromRomanValue(s[i]) > fromRomanValue(stack.top()))
                    {
                        sum += (fromRomanValue(s[i]) - fromRomanValue(stack.top()));
                        stack.pop();
                    }
                    else
                    {
                        sum += fromRomanValue(stack.top());
                        stack.pop();
                        stack.push(s[i]);
                    }
                }
            }
        }

        if (!stack.empty())
            sumValues(stack, sum);

        return sum;
    }

    void runTests()
    {
        vector<tuple<string, int>> tests{
            {"IX", 9},
            {"CCIX", 209},
            {"CCCIX", 309},
            {"III", 3},
            {"LVIII", 58},
            {"MCMXCIV", 1994},
            {"DCXXI", 621}};

        for (int i = 0; i < tests.size(); ++i)
        {
            romanToInt(get<0>(tests[i])) == get<1>(tests[i])
                ? cout << "Test" << i << ": OK" << endl
                : cout << "Test" << i << ": Failed" << endl;
        }
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
