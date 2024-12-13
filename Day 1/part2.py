

left = []
right = []
score = 0

with open("input.txt") as input_file:
    for line in input_file:
        left.append(int(line.splitlines()[0].split("   ")[0]))
        right.append(int(line.splitlines()[0].split("   ")[1]))


left.sort()
right.sort()

if len(left) == len(right):
    for left_number in left:
        times_appear = 0
        for right_number in right:
            if (left_number == right_number):
                times_appear += 1
        score += (times_appear * left_number)

        


print(score)