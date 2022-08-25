pub struct Solution1;

impl Solution1 {
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

pub struct Solution2;

impl Solution2 {
    pub fn can_construct(ransom_note: String, magazine: String) -> bool {
        // Best performance solution -> https://leetcode.com/problems/ransom-note/discuss/1952584/Rust-solution
        if ransom_note.len() > magazine.len() {
            return false;
        }

        let mut store = [0; 26]; // Declare and initialize an array of 26 positions with 0's.
        let mut flags = 0;
        // 'a' usize value is 97 so after subtracting 97 to any char value from 'a' to 'z', the resulting index
        // would fit the 0 to 25 range of the store array we just created. Basically it will work like a HashMap because we know
        // which values we are going to get -> index = key
        let get_index = |c: char| c as usize - 'a' as usize;

        ransom_note.chars().for_each(|c| {
            let i = get_index(c);
            store[i] += 1;
            // flags variable will serve us as a HashSet to add associated values only once thanks to the bitwise operation trick,
            // but it will allow us, compared to the HashSet approach, to access and remove values later on at O(1) time complexity instead
            // of having to iterate over the hypothetical HashSet to remove the element we wanted to.
            // We shift the 1 (one) i times to the left and if that binary position is 0 (false), we assign the 1 (true) thanks to the BitOrAssign operator.
            // flags = flags | 1 << i
            // refer to https://doc.rust-lang.org/book/appendix-02-operators.html
            flags |= 1 << i;
        });

        for c in magazine.chars() {
            let i = get_index(c);
            store[i] -= 1;

            if store[i] == 0 {
                // We remove the associated value we got from our get_index closure from flags
                // because if store[i] is 0, we already met the requirement for that char.
                // We shift the 1 (one) i times to the left and if that binary position in flags is 1 (which it should) as we are shifting a 1 as well,
                // the BitXorAssign operation will yield and assign a 0 to that position.
                // flags = flags ^ 1 << i
                // This is done in O(1) time complexity.
                flags ^= 1 << i;

                if flags == 0 {
                    // Also flags serve us as a control to check if all the requirements were met as we would've done with our <hash_set>.len()
                    return true;
                }
            }
        }

        false
    }
}

#[test]
fn test1() {
    assert_eq!(
        Solution1::can_construct("aab".to_owned(), "bbba".to_owned()),
        false
    );
}

#[test]
fn test2() {
    assert_eq!(
        Solution1::can_construct("aabs".to_owned(), "bbbacsa".to_owned()),
        true
    );
}

#[test]
fn test3() {
    assert_eq!(
        Solution1::can_construct("aabc".to_owned(), "bbba".to_owned()),
        false
    );
}

#[test]
fn test4() {
    assert_eq!(
        Solution1::can_construct("a".to_owned(), "b".to_owned()),
        false
    );
}

#[test]
fn test5() {
    assert_eq!(
        Solution2::can_construct("aaaaaa".to_owned(), "baaaaaa".to_owned()),
        true
    );
}
