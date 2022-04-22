#include <string>
#include <vector>
#include <tuple>
#include <iostream>

using namespace std;

class Solution
{
public:
    int strStr(string haystack, string needle)
    {
        if (needle.empty())
            return 0;

        return haystack.find(needle) != string::npos ? haystack.find(needle) : -1;
    }

    void runTests()
    {
        vector<tuple<string, string, int>> tests{
            {"Hello", "ll", 2},
            {"", "", 0},
            {"Random", "zu", -1},
            {"Something", "me", 2}};

        for (int i = 0; i < tests.size(); ++i)
        {
            strStr(get<0>(tests[i]), get<1>(tests[i])) == get<2>(tests[i])
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
