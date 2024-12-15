

data = []

with open("test.txt") as input_file:
    for line in input_file:
        width = len(line)
        for point in line.strip():
            data.append(point)
    height = len(data)//width

print(width)
print(height)
print(len(data))