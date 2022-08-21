pub struct Solution;

use std::collections::HashMap;

impl Solution {
    pub fn roman_to_int(s: String) -> i32 {
        let map: HashMap<char, i32> = HashMap::from([
            ('I', 1),
            ('V', 5),
            ('X', 10),
            ('L', 50),
            ('C', 100),
            ('D', 500),
            ('M', 1000),
        ]);

        let mut sum = 0;
        let mut last = 0;

        s.chars().for_each(|c| match map.get(&c) {
            Some(&value) => {
                if value > last {
                    sum += value - last - last;
                } else {
                    sum += value;
                }

                last = value;
            }
            _ => {}
        });

        sum
    }
}

#[test]
fn test1() {
    assert_eq!(Solution::roman_to_int(String::from("MCD")), 1400);
}

#[test]
fn test2() {
    assert_eq!(Solution::roman_to_int(String::from("IV")), 4);
}

#[test]
fn test3() {
    assert_eq!(Solution::roman_to_int(String::from("CCIX")), 209);
}
