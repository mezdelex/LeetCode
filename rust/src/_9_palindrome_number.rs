pub struct Solution;

impl Solution {
    pub fn is_palindrome(x: i32) -> bool {
        if x < 0 {
            return false;
        }

        let mut reversed_input = 0;
        let mut input = x;

        while input > 0 {
            reversed_input = reversed_input * 10 + input % 10;
            input /= 10;
        }

        x == reversed_input
    }
}

pub struct Solution2;

impl Solution2 {
    pub fn is_palindrome(x: i32) -> bool {
        if x < 0 {
            return false;
        }

        let x_to_str = x.abs().to_string();

        x_to_str == x_to_str.chars().rev().collect::<String>()
    }
}

#[test]
fn test1() {
    let x = -1212;
    let expected = false;
    assert_eq!(Solution::is_palindrome(x), expected);
}

#[test]
fn test2() {
    let x = 12321;
    let expected = true;
    assert_eq!(Solution::is_palindrome(x), expected);
}

#[test]
fn test3() {
    let x = 112233;
    let expected = false;
    assert_eq!(Solution::is_palindrome(x), expected);
}

#[test]
fn test4() {
    let x = -1212;
    let expected = false;
    assert_eq!(Solution2::is_palindrome(x), expected);
}

#[test]
fn test5() {
    let x = 12321;
    let expected = true;
    assert_eq!(Solution2::is_palindrome(x), expected);
}

#[test]
fn test6() {
    let x = 112233;
    let expected = false;
    assert_eq!(Solution2::is_palindrome(x), expected);
}
