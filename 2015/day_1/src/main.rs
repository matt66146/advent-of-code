use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let mut floor = 0;
    let mut found_floor = false;
    let input_file = BufReader::new(File::open("./src/input").expect("Error opening file"));
    let mut pos = 0;
    for line in input_file.lines() {
        for c in line.unwrap().chars() {
            if !found_floor {
                pos += 1;
            }
            if c == '(' {
                floor += 1;
            } else if c == ')' {
                floor -= 1;
            } else {
                println!("Warning! This should never happen!");
            }

            if floor == -1 && found_floor == false {
                found_floor = true;
            }
        }
    }
    println!("Part 1 - Ending Floor {}", floor);
    println!("Part 2 - Position {}", pos);
}
