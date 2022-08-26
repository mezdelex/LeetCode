pub struct Solution;

impl Solution {
    fn sorted_str(n: i32) -> String {
        // If the digits can be rearranged in any way, we don't care about the value itself as long as it's equal to
        // an already known possible value sorted by the same system; this function that is.
        let mut char_vec: Vec<char> = n.to_string().chars().collect();
        char_vec.sort_unstable();
        let str: String = char_vec.iter().collect();

        str
    }

    pub fn reordered_power_of2(n: i32) -> bool {
        let reference_str = Self::sorted_str(n);

        // 2^30 contains max possible input -> 1 <= n <= 10^9 Constraint
        for i in 0..30 {
            let temp_str = Self::sorted_str(1 << i);

            if reference_str == temp_str {
                return true;
            }
        }

        return false;
    }
}

#[test]
fn test1() {
    assert_eq!(Solution::reordered_power_of2(1), true);
}

#[test]
fn test2() {
    assert_eq!(Solution::reordered_power_of2(10), false);
}

#[test]
fn test3() {
    assert_eq!(Solution::reordered_power_of2(0001), true);
}

#[test]
fn test4() {
    assert_eq!(Solution::reordered_power_of2(032), true);
}

#[test]
fn test5() {
    assert_eq!(Solution::reordered_power_of2(679213508), true);
}
