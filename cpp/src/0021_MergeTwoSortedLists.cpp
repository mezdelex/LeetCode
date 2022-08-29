#include <iostream>
#include <tuple>
#include <vector>
#include <cassert>

using namespace std;

struct ListNode
{
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode *next) : val(x), next(next) {}
};

class MergeTwoSortedListsSolution
{
public:
    ListNode *mergeTwoLists(ListNode *list1, ListNode *list2)
    {
        ListNode *head = new ListNode();
        ListNode *iterator = head;

        while (list1 && list2)
        {
            if (list1->val < list2->val)
            {
                iterator->next = list1;
                list1 = list1->next;
            }
            else
            {
                iterator->next = list2;
                list2 = list2->next;
            }

            iterator = iterator->next;
        }

        iterator->next = list1 ? list1 : list2;

        return head->next;
    }

    void runTests()
    {
        vector<tuple<ListNode *, ListNode *, ListNode *>> tests{
            {new ListNode(1, new ListNode(2, new ListNode(4))),
             new ListNode(1, new ListNode(3, new ListNode(4))),
             new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))))},
            {nullptr,
             new ListNode(),
             new ListNode()},
            {new ListNode(-6, new ListNode(-5, new ListNode(6, new ListNode(6, new ListNode(7))))),
             new ListNode(),
             new ListNode(-6, new ListNode(-5, new ListNode(0, new ListNode(6, new ListNode(6, new ListNode(7))))))}};

        for (int i = 0; i < tests.size(); ++i)
        {
            ListNode *temp = mergeTwoLists(get<0>(tests[i]), get<1>(tests[i]));

            while (temp && get<2>(tests[i]))
            {
                assert(temp->val == get<2>(tests[i])->val);
                temp = temp->next;
                get<2>(tests[i]) = get<2>(tests[i])->next;
            }
        }
    }
};