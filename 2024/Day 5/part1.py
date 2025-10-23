
rules: list[str] = []
data: list[str] = []
valid_lines: list[str] = []

total = 0

with open("input.txt") as input_file:
    for line in input_file.readlines():
        if "|" in line:
            rules.append(line)
        if "," in line:
            data.append(line)

for line in data:
    valid = True
    for rule in rules:
        rule = rule.split("|")
        index0 = line.find(rule[0])
        index1 = line.find(rule[1].replace("\n",""))

        if index0 != -1 and index1 != -1:
            if index0 - index1 > 0:
                valid = False
                break
    if valid:
        valid_lines.append(line)

for line in valid_lines:
    line = line.split(',')
    total += int(line[len(line)//2])

print(total)