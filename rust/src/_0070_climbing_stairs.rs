pub struct Solution;

impl Solution {
    pub fn climb_stairs(n: i32) -> i32 {
        (1..n) // The range start..end contains all values with start <= x < end. It is empty if start >= end.
            .into_iter() // Creates an iterator based in the range values.
            // We cannot use reduce because the initial value has to be always (1, 1) to fit Fibonacci secuence; it cannot be taken from the range itself.
            // fold method is used to define that initial value.
            .fold((1, 1), |(previous, next), _| (next, previous + next))
            .1 // We return the second position -next- from the tuple.
    }
}

#[test]
fn test1() {
    let n1 = 2;
    let expected1 = 2;
    assert_eq!(Solution::climb_stairs(n1), expected1);
}

#[test]
fn test2() {
    let n2 = 3;
    let expected2 = 3;
    assert_eq!(Solution::climb_stairs(n2), expected2);
}

#[test]
fn test3() {
    let n3 = 4;
    let expected3 = 5;
    assert_eq!(Solution::climb_stairs(n3), expected3);
}
