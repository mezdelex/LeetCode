pub struct Solution;

impl Solution {
    pub fn can_construct(ransom_note: String, magazine: String) -> bool {
        if ransom_note.len() > magazine.len() {
            return false;
        }

        if ransom_note == magazine {
            return true;
        }

        // We don't check for empty strings because problem constraints state that the length will always be at least 1.
        let mut magazine_vec: Vec<char> = magazine.chars().collect();
        let mut found = false;

        for c in ransom_note.chars() {
            found = false;
            for i in 0..magazine_vec.len() {
                if magazine_vec[i] == c {
                    magazine_vec.remove(i);
                    found = true;
                    break;
                }
            }

            if !found {
                return false;
            }
        }

        found
    }
}

#[test]
fn test1() {
    assert_eq!(
        Solution::can_construct("aab".to_owned(), "bbba".to_owned()),
        false
    );
}

#[test]
fn test2() {
    assert_eq!(
        Solution::can_construct("aabs".to_owned(), "bbbacsa".to_owned()),
        true
    );
}

#[test]
fn test3() {
    assert_eq!(
        Solution::can_construct("aabc".to_owned(), "bbba".to_owned()),
        false
    );
}

#[test]
fn test4() {
    assert_eq!(
        Solution::can_construct("a".to_owned(), "b".to_owned()),
        false
    );
}
