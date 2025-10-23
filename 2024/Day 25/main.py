import time
from termcolor import colored


if __name__ == "__main__":
    def main():
        width = -1
        height = -1
        with open("input.txt") as input_file:
            locks = []
            keys = []
            first_line = True
            line_type = None
            lock = [0, 0, 0, 0, 0]
            key = [0, 0, 0, 0, 0]
            start_j = -1
            for j, line in enumerate(input_file):
                width = len(line.strip())
                if line.strip() == "":
                    if line_type == "lock":
                        locks.append(lock)
                    else:
                        keys.append(key)

                    first_line = True
                    lock = [0, 0, 0, 0, 0]
                    key = [0, 0, 0, 0, 0]
                else:
                    if first_line:
                        if "#" in line:
                            line_type = "lock"
                            first_line = False
                            start_j = j
                        else:
                            line_type = "key"
                            first_line = False
                            start_j = j
                    if j-start_j > 0 and j-start_j < 6:
                        if line_type == "lock":
                            for i, char in enumerate(line.strip()):
                                if char == "#":
                                    lock[i] += 1
                        else:
                            for i, char in enumerate(line.strip()):
                                if char == "#":
                                    key[i] += 1
            if line_type == "lock":
                locks.append(lock)
            else:
                keys.append(key)

        pairs = 0
        for lock in locks:
            for key in keys:
                fit = True
                for i in range(0, 5):
                    if lock[i] + key[i] > 5:
                        fit = False
                if fit:
                    pairs += 1
        print(pairs)
    main()
