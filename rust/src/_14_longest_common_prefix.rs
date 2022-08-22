pub struct Solution;

impl Solution {
    pub fn longest_common_prefix(strs: Vec<String>) -> String {
        if strs.is_empty() {
            return "".to_owned();
        }

        let max = strs.iter().map(|str| str.len()).min().unwrap();
        let vec_of_vec_of_chars: Vec<Vec<char>> =
            strs.iter().map(|str| str.chars().collect()).collect();
        let mut prefix: Vec<char> = vec![];

        for i in 0..max {
            if vec_of_vec_of_chars
                .iter()
                .all(|vec_of_chars| vec_of_chars[i] == vec_of_vec_of_chars[0][i])
            {
                prefix.push(vec_of_vec_of_chars[0][i]);
            } else {
                break;
            }
        }

        prefix.iter().collect()
    }
}

#[test]
fn test1() {
    assert_eq!(
        Solution::longest_common_prefix(vec!["paco".to_owned(), "pac".to_owned(), "pa".to_owned()]),
        "pa"
    )
}

#[test]
fn test2() {
    assert_eq!(
        Solution::longest_common_prefix(vec![
            "LOOL".to_owned(),
            "LOOL".to_owned(),
            "LUL".to_owned()
        ]),
        "L"
    )
}

#[test]
fn test3() {
    assert_eq!(
        Solution::longest_common_prefix(vec![
            "some string".to_owned(),
            "some".to_owned(),
            "so".to_owned()
        ]),
        "so"
    )
}
