use std::fs::File;
use std::io::{BufRead, BufReader};

fn main() {
    let input_file = BufReader::new(File::open("./src/input").expect("Error opening file"));
    let mut total_area = 0;
    let mut total_ribbon = 0;
    for line in input_file.lines() {
        let line = line.expect("Error reading line");
        let dimensions: Vec<&str> = line.split('x').collect();
        let length: i32 = dimensions[0]
            .parse()
            .expect("Error converting length to int");
        let width: i32 = dimensions[1]
            .parse()
            .expect("Error converting width to int");
        let height: i32 = dimensions[2]
            .parse()
            .expect("Error converting height to int");

        let mut area = (2 * length * width) + (2 * width * height) + (2 * height * length);

        let mut nums = vec![length, width, height];
        nums.sort();
        area += nums[0] * nums[1];

        total_area += area;

        let mut ribbon = (nums[0] * 2) + (nums[1] * 2) + (length * width * height);
        total_ribbon += ribbon;
    }
    println!("Part 1 - Total Area: {}", total_area);
    println!("Part 2 - Total Ribbon Length: {}", total_ribbon);
}
