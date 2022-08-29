#include <iostream>
#include <string>
#include <vector>
#include <tuple>
#include <cassert>

using namespace std;

class LenghOfLastWordSolution
{
public:
    int lengthOfLastWord(string s)
    {
        int accumulator = 0;

        for (int i = s.size() - 1; i >= 0; --i)
        {
            if (s[i] == ' ' && accumulator != 0)
                break;

            if (s[i] != ' ')
                ++accumulator;
        }

        return accumulator;
    }

    void runTests()
    {
        vector<tuple<string, int>> tests{
            {"some test  comes here   ", 4},
            {"   ", 0},
            {" lul   ", 3}};

        for (int i = 0; i < tests.size(); ++i)
            assert(lengthOfLastWord(get<0>(tests[i])) == get<1>(tests[i]));
    }
};