use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn is_valid(s: String) -> bool {
        let mut stack: Vec<char> = vec![]; // Rust's Vec implements methods typically used by Stack structures in other languages (LinkedList could also be used, refer to https://stackoverflow.com/questions/40848918/are-there-queue-and-stack-collections-in-rust)
        let map: HashMap<char, char> = HashMap::from([('(', ')'), ('[', ']'), ('{', '}')]);

        for c in s.chars() {
            if map.contains_key(&c) {
                stack.push(c);
            } else {
                match stack.pop() {
                    Some(popped_char) => match map.get(&popped_char) {
                        Some(value) => {
                            if value != &c {
                                return false;
                            }
                        }
                        _ => return false,
                    },
                    _ => return false,
                }
            }
        }

        stack.is_empty()
    }
}

#[test]
fn test1() {
    assert_eq!(Solution::is_valid(String::from("()")), true);
}
#[test]
fn test2() {
    assert_eq!(Solution::is_valid(String::from("()[]{}")), true);
}
#[test]
fn test3() {
    assert_eq!(Solution::is_valid(String::from("([)]")), false);
}
