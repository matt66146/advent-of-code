import time

start = time.time()

rules: list[int] = []
data: list[int] = []
invalid_lines: list[int] = []

total = 0

def CheckRules():
    return_val = False
    for rule in rules:
        rule = list(map(int,rule.split("|")))
        
        index0 = -1
        index1 = -1

        if rule[0] in line:
            index0 = line.index(rule[0])
        if rule[1] in line:
            index1 = line.index(rule[1])

        if index0 != -1 and index1 != -1:
            if index0 - index1 > 0:
                tmp = line[index0]
                line[index0] = line[index1]
                line[index1] = tmp
                return_val = True
    return return_val

with open("input.txt") as input_file:
    for line in input_file.readlines():
        if "|" in line:
            rules.append(line)
        if "," in line:
            data.append(line)

for line in data:
    valid = True
    line = list(map(int,line.split(",")))

    swapped = CheckRules()

    if swapped:
        valid = False

    while swapped:
        swapped = CheckRules()
    
    if not valid:
        invalid_lines.append(line)             


for line in invalid_lines:
    total += line[len(line)//2]

end = time.time()


print(total)
print(end-start)