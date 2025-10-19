use std::collections::HashSet;
use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let input_file = BufReader::new(File::open("./src/input").expect("Error opening file"));
    let mut pos: (i32, i32) = (0, 0);
    let mut santa_pos: (i32, i32) = (0, 0);
    let mut robo_pos: (i32, i32) = (0, 0);
    let mut visted_houses: HashSet<(i32, i32)> = HashSet::new();
    visted_houses.insert(pos);

    let mut part2_visted_houses: HashSet<(i32, i32)> = HashSet::new();
    part2_visted_houses.insert(pos);

    let mut i = 0;

    for line in input_file.lines() {
        for c in line.unwrap().chars() {
            i += 1;
            if c == '^' {
                pos.1 += 1;

                if i % 2 == 0 {
                    robo_pos.1 += 1;
                } else {
                    santa_pos.1 += 1;
                }
            } else if c == '>' {
                pos.0 += 1;
                if i % 2 == 0 {
                    robo_pos.0 += 1;
                } else {
                    santa_pos.0 += 1;
                }
            } else if c == '<' {
                pos.0 -= 1;
                if i % 2 == 0 {
                    robo_pos.0 -= 1;
                } else {
                    santa_pos.0 -= 1;
                }
            } else if c == 'v' {
                pos.1 -= 1;
                if i % 2 == 0 {
                    robo_pos.1 -= 1;
                } else {
                    santa_pos.1 -= 1;
                }
            }

            visted_houses.insert(pos);
            part2_visted_houses.insert(robo_pos);
            part2_visted_houses.insert(santa_pos);
        }
    }

    println!("Part 1 - Unique Houses: {}", visted_houses.len());
    println!("Part 2 - Unique Houses: {}", part2_visted_houses.len());
}
