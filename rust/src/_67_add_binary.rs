pub struct Solution;

impl Solution {
    pub fn add_binary(a: String, b: String) -> String {
        // from_str_radix -> Converts a string slice in a given base to an integer.
        // unwrap_or -> Returns the value of the Option<T> or the defined default.
        let a_to_int = i128::from_str_radix(&a, 2).unwrap_or(0);
        let b_to_int = i128::from_str_radix(&b, 2).unwrap_or(0);

        format!("{:b}", a_to_int + b_to_int)
    }
}

#[test]
fn test1() {
    assert_eq!(
        Solution::add_binary("1010".to_string(), "1011".to_string()),
        "10101".to_string()
    );
}

#[test]
fn test2() {
    assert_eq!(
        Solution::add_binary("1000".to_string(), "1011".to_string()),
        "10011".to_string()
    );
}

#[test]
fn test3() {
    assert_eq!(
        Solution::add_binary("000".to_string(), "111".to_string()),
        "111".to_string()
    );
}
