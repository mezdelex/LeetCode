pub struct Solution;

impl Solution {
    pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        let mut min: i32 = 0;
        let mut max: i32 = nums.len() as i32 - 1;

        while min <= max {
            let mid = min + (max - min) / 2;

            if nums[mid as usize] == target {
                return mid as i32;
            }

            if nums[mid as usize] < target {
                min = mid + 1
            } else {
                max = mid - 1;
            }
        }

        return min as i32;
    }
}

pub struct Solution2;

impl Solution2 {
    pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        for (i, &value) in nums.iter().enumerate() {
            if target <= value {
                return i as i32;
            }
        }

        nums.len() as i32
    }
}

#[test]
fn test1() {
    let nums1 = Vec::from([1, 3, 5, 6]);
    let target1 = 7;
    let expected1 = 4;
    assert_eq!(Solution::search_insert(nums1, target1), expected1);
}

#[test]
fn test2() {
    let nums2 = Vec::from([1, 2, 3, 4]);
    let target2 = 2;
    let expected2 = 1;
    assert_eq!(Solution::search_insert(nums2, target2), expected2);
}

#[test]
fn test3() {
    let nums3 = Vec::from([1]);
    let target3 = 3;
    let expected3 = 1;
    assert_eq!(Solution::search_insert(nums3, target3), expected3);
}

#[test]
fn test4() {
    let nums4 = Vec::from([1, 3, 5, 6]);
    let target4 = 0;
    let expected4 = 0;
    assert_eq!(Solution::search_insert(nums4, target4), expected4);
}

#[test]
fn test5() {
    let nums5 = Vec::from([1, 3, 5, 6]);
    let target5 = 0;
    let expected5 = 0;
    assert_eq!(Solution2::search_insert(nums5, target5), expected5);
}

#[test]
fn test6() {
    let nums6 = Vec::from([1, 2, 3, 4]);
    let target6 = 2;
    let expected6 = 1;
    assert_eq!(Solution2::search_insert(nums6, target6), expected6);
}
