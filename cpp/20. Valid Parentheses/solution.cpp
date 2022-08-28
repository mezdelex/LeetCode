#include <stack>
#include <iostream>
#include <string>
#include <unordered_map>
#include <vector>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    bool isValid(string s)
    {
        stack<char> stack;
        unordered_map<char, char> map{
            {'[', ']'},
            {'{', '}'},
            {'(', ')'},
        };

        for (int i = 0; i < s.size(); ++i)
            if (!stack.empty() && map[stack.top()] == s[i])
                stack.pop();
            else if (!map[s[i]])
                return false;
            else
                stack.push(s[i]);

        return stack.empty();
    }

    void runTests()
    {
        vector<tuple<string, bool>> tests{
            {"[[]]{}(())", true},
            {"[)", false},
            {"[]{{{}}}", true},
            {")()(", false},
            {"{[]}", true}};

        for (int i = 0; i < tests.size(); ++i)
            assert(isValid(get<0>(tests[i])) == get<1>(tests[i]));
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
