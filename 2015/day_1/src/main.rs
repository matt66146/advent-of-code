use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let part = 2; //Change to 1 to run part 1

    let mut floor = 0;
    let input_file = BufReader::new(File::open("./src/input").expect("Error opening file"));
    let mut pos = 0;
    for line in input_file.lines() {
        for c in line.unwrap().chars() {
            pos += 1;
            if c == '(' {
                floor += 1;
            } else if c == ')' {
                floor -= 1;
            } else {
                println!("Warning! This should never happen!");
            }

            if part == 2 {
                //Part 2
                if floor == -1 {
                    println!("Position {}", pos);
                    return;
                }
            }
        }
    }
    println!("Ending Floor {}", floor);
}
