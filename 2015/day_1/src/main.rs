use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let mut floor = 0;
    let input_file = BufReader::new(File::open("./src/input").expect("Error opening file"));

    for line in input_file.lines() {
        for c in line.unwrap().chars() {
            if c == '(' {
                floor += 1;
            } else if c == ')' {
                floor -= 1;
            } else {
                println!("Warning! This should never happen!");
            }
        }
    }
    println!("Ending Floor {}", floor);
}
