pub struct Solution;

impl Solution {
    pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
        // This is not needed since the constraints of the problem already state that the length is at least 1.
        // Without this control it's 100% faster than the rest of the submissions.
        if nums.len() == 0 {
            return 0;
        }

        let mut i = 0;

        for j in 1..nums.len() {
            if nums[i] != nums[j] {
                i += 1;
                nums[i] = nums[j]
            }
        }

        i as i32 + 1
    }
}

#[test]
fn test1() {
    let mut nums = Vec::from([1, 2, 2, 3, 4, 4, 5]);
    assert_eq!(Solution::remove_duplicates(&mut nums), 5)
}

#[test]
fn test2() {
    let mut nums = Vec::from([1, 2, 3, 3, 3, 3, 3]);
    assert_eq!(Solution::remove_duplicates(&mut nums), 3)
}

#[test]
fn test3() {
    let mut nums = Vec::from([1, 2, 3, 4, 5, 6, 7]);
    assert_eq!(Solution::remove_duplicates(&mut nums), 7)
}

#[test]
fn test4() {
    let mut nums = Vec::from([]);
    assert_eq!(Solution::remove_duplicates(&mut nums), 0)
}
