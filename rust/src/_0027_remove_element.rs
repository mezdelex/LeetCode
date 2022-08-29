pub struct Solution;

impl Solution {
    pub fn remove_element(nums: &mut Vec<i32>, val: i32) -> i32 {
        nums.retain(|&x| x != val);

        nums.len() as i32
    }
}

#[test]
fn test1() {
    let mut nums1 = Vec::from([1, 2, 3, 3]);
    let val1: i32 = 3;
    let expected_val1 = 2;
    assert_eq!(Solution::remove_element(&mut nums1, val1), expected_val1);
}

#[test]
fn test2() {
    let mut nums2 = Vec::from([3, 2, 2, 3]);
    let val2: i32 = 3;
    let expected_val2 = 2;
    assert_eq!(Solution::remove_element(&mut nums2, val2), expected_val2);
}

#[test]
fn test3() {
    let mut nums3 = Vec::from([1, 0, 3, 5]);
    let val3: i32 = 1;
    let expected_val3 = 3;
    assert_eq!(Solution::remove_element(&mut nums3, val3), expected_val3);
}

#[test]
fn test4() {
    let mut nums4 = Vec::from([]);
    let val4: i32 = 0;
    let expected_val4 = 0;
    assert_eq!(Solution::remove_element(&mut nums4, val4), expected_val4);
}

#[test]
fn test5() {
    let mut nums5 = Vec::from([1]);
    let val5: i32 = 1;
    let expected_val5 = 0;
    assert_eq!(Solution::remove_element(&mut nums5, val5), expected_val5);
}
