use std::collections::HashMap;

pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut hash_map: HashMap<i32, i32> = HashMap::new();

        for (i, &num) in nums.iter().enumerate() {
            if let Some(&j) = hash_map.get(&(target - num)) {
                return vec![j, i as i32];
            } else {
                hash_map.insert(num, i as i32);
            }
        }

        vec![]
    }
}

#[test]
fn test1() {
    let nums = vec![2, 7, 11, 15];
    let target = 9;
    assert_eq!(Solution::two_sum(nums, target), vec![0, 1]);
}
#[test]
fn test2() {
    let nums = vec![2, 0, 11, 15];
    let target = 26;
    assert_eq!(Solution::two_sum(nums, target), vec![2, 3]);
}
#[test]
fn test3() {
    let nums = vec![0, 7, 11, 15];
    let target = 18;
    assert_eq!(Solution::two_sum(nums, target), vec![1, 2]);
}
