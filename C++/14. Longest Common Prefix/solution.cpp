#include <string>
#include <iostream>
#include <vector>
#include <sstream>
#include <tuple>

using namespace std;

class Solution
{
public:
    string longestCommonPrefix(vector<string> &strs)
    {
        // Fixed an acceptance bug, the return should have been "".
        if (strs.size() < 2)
            return strs[0];

        stringstream ss;
        for (int i = 0; i < strs[0].size(); ++i)
        {
            if (strs[0][i] != strs[1][i])
                break;

            ss << strs[0][i];
        }

        if (ss.str().size() == 0)
            return "";

        if (strs.size() > 2)
        {
            for (int i = 0; i < ss.str().size(); ++i)
            {
                for (int j = 2; j < strs.size(); ++j)
                {
                    if (!strs[j][i])
                        if (i == 0)
                            return "";
                        else
                            ss << ss.str().substr(0, i - 1);

                    if (ss.str()[i] != strs[j][i])
                        return ss.str().substr(0, i);
                }
            }
        }

        return ss.str();
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
            {{"baab", "bacb", "b", "cbc"}, ""}};

        for (int i = 0; i < tests.size(); ++i)
        {
            longestCommonPrefix(get<0>(tests[i])) == get<1>(tests[i])
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
