use md5;

fn main() {
    let mut found_part1 = false;
    let mut found_part2 = false;
    let mut i = 1;
    let input = "yzbqklnj";
    let mut num_zeros = 0;

    let part1: i32;
    let part2: i32;
    while found_part1 == false || found_part2 == false {
        let md = md5::compute(format!("{}{}", input, i));
        let md5_leading: String = format!("{:x}", md).chars().take(6).collect();

        //Check if first 2 bytes are 00 and 3rd byte has 0 in the first nibble
        if md[0] == 0 && md[1] == 0 && md[2] <= 15 {
            num_zeros = 5;
            if md[2] == 0 {
                num_zeros = 6;
            }
        }

        if num_zeros >= 5 && found_part1 == false {
            found_part1 = true;
            println!("Part 1 - {} ({:x})", i, md);
        }
        if num_zeros >= 6 && found_part2 == false {
            found_part2 = true;
            println!("Part 2 - {} ({:x})", i, md);
        }
        num_zeros = 0;
        i += 1;
    }
}
