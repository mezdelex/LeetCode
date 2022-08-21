pub struct Solution;

impl Solution {
    pub fn longest_common_prefix(strs: Vec<String>) -> String {
        if strs.is_empty() {
            return "".to_string();
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
        Solution::longest_common_prefix(vec![
            "paco".to_string(),
            "pac".to_string(),
            "pa".to_string()
        ]),
        "pa"
    )
}

#[test]
fn test2() {
    assert_eq!(
        Solution::longest_common_prefix(vec![
            "LOOL".to_string(),
            "LOOL".to_string(),
            "LUL".to_string()
        ]),
        "L"
    )
}

#[test]
fn test3() {
    assert_eq!(
        Solution::longest_common_prefix(vec![
            "some string".to_string(),
            "some".to_string(),
            "so".to_string()
        ]),
        "so"
    )
}
