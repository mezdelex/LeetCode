#include <stack>
#include <iostream>
#include <vector>

using namespace std;

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode() : val(0), left(nullptr), right(nullptr) {}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

class Solution
{
public:
    TreeNode *increasingBST(TreeNode *root)
    {
        TreeNode *newRoot = nullptr;
        TreeNode *previous = nullptr;
        stack<TreeNode *> stack;

        while (root || !stack.empty())
        {
            while (root)
            {
                stack.push(root);
                root = root->left;
            }

            root = stack.top();
            stack.pop();

            if (!newRoot)
                newRoot = root;

            if (previous)
                previous->right = root;

            previous = root;
            root = root->right;
        }

        return newRoot;
    }

    void runTests()
    {
        vector<TreeNode *> tests{
            new TreeNode(5, new TreeNode(3, new TreeNode(2), new TreeNode(4)), new TreeNode(6)),
            new TreeNode(9, new TreeNode(7, new TreeNode(2), new TreeNode(8)), nullptr)};

        for (int i = 0; i < tests.size(); ++i)
        {
            int temp = INT_MIN;
            TreeNode *testRoot = increasingBST(tests[i]);

            while (testRoot)
            {
                if (testRoot->val < temp)
                    break;

                cout << testRoot->val << "\n";

                temp = testRoot->val;
                testRoot = testRoot->right;
            }

            testRoot ? cout << "Test" << i << ": Failed" << endl : cout << "Test" << i << ": OK" << endl;

            delete testRoot;
        }
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    solution.runTests();
    return 0;
};
