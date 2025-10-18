

left = []
right = []
total_distance = 0

with open("input.txt") as input_file:
    for line in input_file:
        left.append(int(line.splitlines()[0].split("   ")[0]))
        right.append(int(line.splitlines()[0].split("   ")[1]))


left.sort()
right.sort()

if len(left) == len(right):
    for i in range (0,len(left)):
        total_distance += abs(left[i] - right[i])


print(total_distance)