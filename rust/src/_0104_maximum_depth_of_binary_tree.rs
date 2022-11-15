#[derive(Debug, PartialEq, Eq)]
pub struct TreeNode {
    pub val: i32,
    pub left: Option<Rc<RefCell<TreeNode>>>,
    pub right: Option<Rc<RefCell<TreeNode>>>,
}

impl TreeNode {
    #[inline]
    pub fn new(val: i32) -> Self {
        TreeNode {
            val,
            left: None,
            right: None,
        }
    }
}

use std::cell::RefCell;
use std::rc::Rc;

pub struct Solution;

impl Solution {
    pub fn max_depth(root: Option<Rc<RefCell<TreeNode>>>) -> i32 {
        let mut max_depth = 0;
        let mut stack = vec![(root, 0)];

        loop {
            match stack.pop() {
                Some((node, mut depth)) => match node {
                    Some(node) => {
                        depth += 1;
                        max_depth = max_depth.max(depth);

                        let borrowed_node = node.borrow();
                        stack.push((borrowed_node.left.to_owned(), depth));
                        stack.push((borrowed_node.right.to_owned(), depth));
                    }
                    _ => {}
                },
                _ => break,
            }
        }

        max_depth
    }
}

#[test]
fn test1() {
    let root1 = Some(Rc::new(RefCell::new(TreeNode {
        val: 3,
        left: Some(Rc::new(RefCell::new(TreeNode::new(9)))),
        right: Some(Rc::new(RefCell::new(TreeNode {
            val: 20,
            left: Some(Rc::new(RefCell::new(TreeNode::new(15)))),
            right: Some(Rc::new(RefCell::new(TreeNode::new(7)))),
        }))),
    })));
    let expected1 = 3;

    assert_eq!(Solution::max_depth(root1), expected1);
}

#[test]
fn test2() {
    let root2 = Some(Rc::new(RefCell::new(TreeNode {
        val: 3,
        left: Some(Rc::new(RefCell::new(TreeNode {
            val: 4,
            left: None,
            right: Some(Rc::new(RefCell::new(TreeNode {
                val: 1,
                left: None,
                right: Some(Rc::new(RefCell::new(TreeNode::new(6)))),
            }))),
        }))),
        right: Some(Rc::new(RefCell::new(TreeNode {
            val: 20,
            left: Some(Rc::new(RefCell::new(TreeNode::new(15)))),
            right: Some(Rc::new(RefCell::new(TreeNode::new(7)))),
        }))),
    })));
    let expected2 = 4;

    assert_eq!(Solution::max_depth(root2), expected2);
}

#[test]
fn test3() {
    let root3 = Some(Rc::new(RefCell::new(TreeNode::new(1))));
    let expected3 = 1;

    assert_eq!(Solution::max_depth(root3), expected3);
}

#[test]
fn test4() {
    let root4 = Some(Rc::new(RefCell::new(TreeNode::new(2))));
    let expected4 = 1;

    assert_eq!(Solution::max_depth(root4), expected4);
}
