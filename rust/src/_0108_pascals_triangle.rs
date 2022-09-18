pub struct Solution;

impl Solution {
    pub fn generate(num_rows: i32) -> Vec<Vec<i32>> {
        let mut triangle = vec![];

        (0..num_rows as usize).into_iter().for_each(|i| {
            triangle.push(vec![1; i + 1]);

            (1..i as usize).into_iter().for_each(|j| {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            })
        });

        triangle
    }
}

#[test]
fn test1() {
    let num_rows1 = 5;
    let expected1 = vec![
        vec![1],
        vec![1, 1],
        vec![1, 2, 1],
        vec![1, 3, 3, 1],
        vec![1, 4, 6, 4, 1],
    ];
    assert_eq!(Solution::generate(num_rows1), expected1);
}

#[test]
fn test2() {
    let num_rows2 = 2;
    let expected2 = vec![vec![1], vec![1, 1]];
    assert_eq!(Solution::generate(num_rows2), expected2);
}

#[test]
fn test3() {
    let num_rows3 = 3;
    let expected3 = vec![vec![1], vec![1, 1], vec![1, 2, 1]];
    assert_eq!(Solution::generate(num_rows3), expected3);
}
