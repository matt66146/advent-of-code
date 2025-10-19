use core::num;
use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let input_file = File::open("./src/input").expect("Error Opening File");
    let input_file = BufReader::new(input_file);
    let mut num_good = 0;
    let mut num_good_part2 = 0;
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
                println!("Check: {}", line);
            }
        } else {
            {
                //println!("Repeat: {}", line);
            }
        }
    }
    println!("Part 1 : {}", num_good);
    println!("Part 2 : {}", num_good_part2);
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

    while c < string.len() - 1 {
        if string[c + 2..string.len()].contains(&string[c..c + 2].to_string()) {
            return true;
        }

        c += 1;
    }
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
