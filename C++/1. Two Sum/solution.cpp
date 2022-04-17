#include <vector>
#include <iostream>
#include <unordered_map>

using namespace std;

class Solution
{
public:
    vector<int> twoSum(vector<int> &nums, int target)
    {
        unordered_map<int, int> storage;
        for (int i = 0; i < nums.size(); ++i)
        {
            if (i != 0 && storage.find(target - nums[i]) != storage.end())
            {
                return {storage[target - nums[i]], i};
            }
            storage[nums[i]] = i;
        }
        return {};
    }

    void runTests()
    {
        vector<int> testCase1{4, 5, 1, 44, 666, 214214, 55, 4, 561};
        int target1 = 5;
        vector<int> solution1{0, 2};
        cout << (twoSum(testCase1, target1) == solution1 ? "Test1: OK" : "Test1: Failed") << endl;

        vector<int> testCase2{2, 7, 11, 15};
        int target2 = 9;
        vector<int> solution2{0, 1};
        cout << (twoSum(testCase2, target2) == solution2 ? "Test2: OK" : "Test2: Failed") << endl;

        vector<int> testCase3{3, 3};
        int target3 = 6;
        vector<int> solution3{0, 1};
        cout << (twoSum(testCase3, target3) == solution3 ? "Test3: OK" : "Test3: Failed") << endl;
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
}
