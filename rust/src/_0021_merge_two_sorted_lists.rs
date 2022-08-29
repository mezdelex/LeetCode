// The compiler is capable of providing basic implementations for some traits via the #[derive] attribute.
// These traits can still be manually implemented if a more complex behavior is required.

// The following is a list of derivable traits:

// Comparison traits: Eq, PartialEq, Ord, PartialOrd.
// Clone, to create T from &T via a copy.
// Copy, to give a type 'copy semantics' instead of 'move semantics'.
// Hash, to compute a hash from &T.
// Default, to create an empty instance of a data type.
// Debug, to format a value using the {:?} formatter.

#[derive(PartialEq, Eq, Clone, Debug)] // [Compiler] Refer to above explanation
pub struct ListNode {
    pub val: i32,
    pub next: Option<Box<ListNode>>,
}

impl ListNode {
    #[inline] // [Compiler/Performance] This suggests that the function should be inlined, including across crate boundaries.
    pub fn new(val: i32) -> Self {
        ListNode { val, next: None }
    }
}

pub struct Solution;

impl Solution {
    pub fn merge_two_lists(
        // All values in Rust are stack allocated by default.
        // Values can be boxed (allocated on the heap) by creating a Box<T>.
        // A box is a smart pointer to a heap allocated value of type T.
        // When a box goes out of scope, its destructor is called, the inner object is destroyed, and the memory on the heap is freed.
        l1: Option<Box<ListNode>>,
        l2: Option<Box<ListNode>>,
    ) -> Option<Box<ListNode>> {
        match (l1, l2) {
            (Some(l1_list_node), Some(l2_list_node)) => {
                if l1_list_node.val <= l2_list_node.val {
                    Some(Box::new(ListNode {
                        val: l1_list_node.val,
                        next: Self::merge_two_lists(l1_list_node.next, Some(l2_list_node)), // .next is an Option<T> itself
                    }))
                } else {
                    Some(Box::new(ListNode {
                        val: l2_list_node.val,
                        next: Self::merge_two_lists(Some(l1_list_node), l2_list_node.next), // .next is an Option<T> itself
                    }))
                }
            }
            (Some(l1_list_node), None) => Some(l1_list_node),
            (None, Some(l2_list_node)) => Some(l2_list_node),
            (_, _) => None,
        }
    }
}

#[test]
fn test1() {
    let linked_list_1 = Some(Box::new(ListNode::new(1)));
    let linked_list_2 = Some(Box::new(ListNode::new(2)));
    let result_linked_list = Some(Box::new(ListNode {
        val: 1,
        next: Some(Box::new(ListNode::new(2))),
    }));

    assert_eq!(
        Solution::merge_two_lists(linked_list_1, linked_list_2),
        result_linked_list
    );
}

#[test]
fn test2() {
    let linked_list_1 = Some(Box::new(ListNode::new(1)));
    let result_linked_list = Some(Box::new(ListNode::new(1)));

    assert_eq!(
        Solution::merge_two_lists(linked_list_1, None),
        result_linked_list
    );
}

#[test]
fn big_ass_test() {
    let linked_list_1 = Some(Box::new(ListNode {
        val: 1,
        next: Some(Box::new(ListNode {
            val: 2,
            next: Some(Box::new(ListNode::new(4))),
        })),
    }));

    let linked_list_2 = Some(Box::new(ListNode {
        val: 1,
        next: Some(Box::new(ListNode {
            val: 3,
            next: Some(Box::new(ListNode::new(4))),
        })),
    }));

    let result_linked_list = Some(Box::new(ListNode {
        val: 1,
        next: Some(Box::new(ListNode {
            val: 1,
            next: Some(Box::new(ListNode {
                val: 2,
                next: Some(Box::new(ListNode {
                    val: 3,
                    next: Some(Box::new(ListNode {
                        val: 4,
                        next: Some(Box::new(ListNode::new(4))),
                    })),
                })),
            })),
        })),
    }));

    assert_eq!(
        Solution::merge_two_lists(linked_list_1, linked_list_2),
        result_linked_list
    );
}
