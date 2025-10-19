use std::fs::File;
use std::io::{BufRead, BufReader};
use std::time::Instant;

fn main() {
    let input_file = File::open("./src/input").expect("Error Opening File");
    let input_file = BufReader::new(input_file);
    let mut num_good = 0;
    let mut num_good_part2 = 0;
    let now = Instant::now();
    for l in input_file.lines() {
        let line = l.unwrap();
        //part 1
        if check_vowels(&line) >= 3 {
            if check_substrings(&line) == false {
                for c in 1..line.len() - 1 {
                    if line.chars().nth(c) == line.chars().nth(c - 1)
                        || line.chars().nth(c) == line.chars().nth(c + 1)
                    {
                        num_good += 1;
                        break;
                    }
                }
            }
        }
        //part 2
        if repeat_letter(&line) {
            if check_pairs(&line) {
                num_good_part2 += 1;
                //println!("Good: {}", line);
            } else {
                //println!("Check: {}", line);
            }
        } else {
            {
                //println!("Repeat: {}", line);
            }
        }
    }
    println!("Part 1 : {}", num_good);
    println!("Part 2 : {}", num_good_part2);
    println!("Elapsed: {:.2?}", now.elapsed());
}

fn repeat_letter(string: &String) -> bool {
    let mut c = 0;
    while c < string.len() - 2 {
        if string.chars().nth(c) == string.chars().nth(c + 2) {
            return true;
        }
        c += 1;
    }
    return false;
}

fn check_pairs(string: &String) -> bool {
    let mut pairs: Vec<String> = vec![];
    let mut c = 0;
    let mut prev: String = "".to_string();

    while c < string.len() - 1 {
        if prev != string[c..c + 2].to_string() {
            if pairs.contains(&string[c..c + 2].to_string()) {
                return true;
            }
            pairs.push(string[c..c + 2].to_string());
            prev = string[c..c + 2].to_string();
        } else {
            {
                prev = "".to_string(); // If a back to back entry is found -- reset prev to allow for back to back to back edge cases
                // EX: cccc
                //The back to back cc should fail (to not reuse the middle c), but the next cc that doesnt reuse the original entry added to the list
                // should succeed rather than fail as a duplicate
            }
        }

        c += 1;
    }

    //println!("{}", pairs.join(","));
    return false;
}

fn check_vowels(string: &String) -> i32 {
    let mut num_vowels: i32 = 0;
    for c in string.chars() {
        if c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' {
            num_vowels += 1;
        }
    }
    return num_vowels;
}

fn check_substrings(string: &String) -> bool {
    if string.contains("ab")
        || string.contains("cd")
        || string.contains("pq")
        || string.contains("xy")
    {
        return true;
    }

    return false;
}
