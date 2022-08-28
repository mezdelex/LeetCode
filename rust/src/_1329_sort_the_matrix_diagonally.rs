use std::cmp;

pub struct Solution;

impl Solution {
    fn execute_diagonal_sort(row: usize, col: usize, mat: &mut Vec<Vec<i32>>) {
        let max_length = cmp::min(mat.len() - row, mat[0].len() - col);
        // We allocate temp_vec's values with <max_length> capacity (but 0 length) in the heap to which we refer to in the stored vector block at the stack (pointer, length, capacity).
        // As long as we don't exceed that capacity in the runtime, the heap won't reallocate, resulting in a performance improvement compared to ::new().
        let mut temp_vec = Vec::with_capacity(max_length);

        for i in 0..max_length {
            temp_vec.push(mat[row + i][col + i]); // We push only the current diagonal values to the temp_vec.
        }

        temp_vec.sort_unstable(); // We sort them.

        for i in 0..max_length {
            mat[row + i][col + i] = temp_vec[i]; // We put them back in the borrowed mutable matrix reference (&mut).
        }
    }

    pub fn diagonal_sort(mut mat: Vec<Vec<i32>>) -> Vec<Vec<i32>> {
        for row in 0..mat.len() {
            Self::execute_diagonal_sort(row, 0, &mut mat);
        }

        // We can use the matrix again because it was borrowed (&), not moved. If it wasn't borrowed but moved, we would have needed to move it back (return).
        // Also if mutable, only 1 mutable reference could be borrowed.
        for col in 1..mat[0].len() {
            Self::execute_diagonal_sort(0, col, &mut mat);
        }

        mat
    }
}

#[test]
fn test1() {
    assert_eq!(
        Solution::diagonal_sort(Vec::from([Vec::from([1]), Vec::from([2]), Vec::from([2])])),
        vec![[1], [2], [2]]
    )
}

#[test]
fn test2() {
    assert_eq!(
        Solution::diagonal_sort(Vec::from([
            Vec::from([3, 3, 1, 1]),
            Vec::from([2, 2, 1, 2]),
            Vec::from([1, 1, 1, 2])
        ])),
        vec![[1, 1, 1, 1], [1, 2, 2, 2], [1, 2, 3, 3]]
    )
}

#[test]
fn test3() {
    assert_eq!(
        Solution::diagonal_sort(Vec::from([
            Vec::from([1, 1, 1, 1]),
            Vec::from([2, 2, 1, 2]),
            Vec::from([5, 3, 1, 2])
        ])),
        vec![[1, 1, 1, 1], [2, 1, 1, 2], [5, 3, 2, 2]]
    )
}
