import time
import functools


def load_data(file_string):
    patterns = []
    with open(file_string) as file_name:
        lines = file_name.readlines()
        towels = lines[0].strip().split(", ")

        for line in lines[2:]:
            patterns.append(line.strip())
    return towels, patterns


@functools.cache
def check_pattern(towels, pattern):
    if len(pattern) == 0:
        return 1
    else:
        num_combos = 0
        for towel in towels:
            if towel in pattern[:len(towel)]:
                num_combos += check_pattern(towels, pattern[len(towel):])
    return num_combos


if __name__ == "__main__":
    def main():
        start = time.time()
        towels, patterns = load_data("input.txt")
        towels = tuple(towels)
        num_possible = 0
        for pattern in patterns:
            pattern_possible = check_pattern(towels, pattern)
            num_possible += pattern_possible
            print(f"{pattern} has {pattern_possible} possibilities.")

        print(f"Total number of possible patterns: {num_possible}")
        end = time.time()
        print(f"Total time elapsed: {end - start} seconds.")


    main()
