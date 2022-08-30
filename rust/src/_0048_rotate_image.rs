// |1|2|3|    |7|4|1|
// |4|5|6| => |8|5|2|
// |7|8|9|    |9|6|3|
pub struct Solution;

impl Solution {
    pub fn rotate(matrix: &mut Vec<Vec<i32>>) {
        let length = matrix.len();
        matrix.reverse();

        for row in 0..length {
            for column in row..length {
                let temp = matrix[row][column];
                matrix[row][column] = matrix[column][row];
                matrix[column][row] = temp;
            }
        }
    }
}

#[test]
fn test1() {
    let mut input1: Vec<Vec<i32>> = Vec::from([
        Vec::from([1, 2, 3]),
        Vec::from([4, 5, 6]),
        Vec::from([7, 8, 9]),
    ]);
    let expected1: Vec<Vec<i32>> = vec![vec![7, 4, 1], vec![8, 5, 2], vec![9, 6, 3]];
    Solution::rotate(&mut input1);
    assert_eq!(input1, expected1);
}

#[test]
fn test2() {
    let mut input2: Vec<Vec<i32>> = Vec::from([
        Vec::from([4, 2, 1]),
        Vec::from([4, 5, 6]),
        Vec::from([7, 8, 6]),
    ]);
    let expected2: Vec<Vec<i32>> = vec![vec![7, 4, 4], vec![8, 5, 2], vec![6, 6, 1]];
    Solution::rotate(&mut input2);
    assert_eq!(input2, expected2);
}

#[test]
fn test3() {
    let mut input3: Vec<Vec<i32>> = Vec::from([
        Vec::from([1, 1, 1]),
        Vec::from([2, 3, 4]),
        Vec::from([5, 5, 5]),
    ]);
    let expected3: Vec<Vec<i32>> = vec![vec![5, 2, 1], vec![5, 3, 1], vec![5, 4, 1]];
    Solution::rotate(&mut input3);
    assert_eq!(input3, expected3);
}
