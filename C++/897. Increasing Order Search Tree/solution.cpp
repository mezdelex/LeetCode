#include <stack>
#include <iostream>

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
            {
                newRoot = root;
                previous = newRoot;
            }
            else
            {
                previous->right = root;
                previous = previous->right;
            }

            root = root->right;
            previous->left = nullptr;
        }

        return newRoot;
    }
};

int main(int argc, char const *argv[])
{
    Solution solution;
    TreeNode *testTreeRoot = new TreeNode(5, new TreeNode(3, new TreeNode(2), new TreeNode(4)), new TreeNode(6));
    TreeNode *resultTreeRoot = solution.increasingBST(testTreeRoot);

    while (resultTreeRoot)
    {
        cout << resultTreeRoot->val << " ";
        resultTreeRoot = resultTreeRoot->right;
    }

    return 0;
};
