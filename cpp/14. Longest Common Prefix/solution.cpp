#include <string>
#include <iostream>
#include <vector>
#include <sstream>
#include <tuple>
#include <cassert>

using namespace std;

class Solution
{
public:
    string longestCommonPrefix(vector<string> &strs)
    {
        for (int i = 0; i < strs[i].size(); ++i)
            for (int j = 1; j < strs.size(); ++j)
                if (strs[j][i] != strs[0][i])
                    return strs[0].substr(0, i);

        return strs[0];
    }

    void runTests()
    {
        vector<tuple<vector<string>, string>> tests{
            {{"paco", "pac", "paaaa"}, "pa"},
            {{"p"}, "p"},
            {{"algo", "distinto"}, ""},
            {{"cir", "car"}, "c"},
            {{"abab", "aba", ""}, ""},
            {{"ac", "ac", "a", "a"}, "a"},
            {{"baab", "bacb", "b", "cbc"}, ""},
            {{"a"}, "a"}};

        for (int i = 0; i < tests.size(); ++i)
            assert(longestCommonPrefix(get<0>(tests[i])) == get<1>(tests[i]));
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
