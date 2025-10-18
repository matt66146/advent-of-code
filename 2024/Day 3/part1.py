import re

total = 0

with open("input.txt") as input_file:
    regex = "mul\(\d{1,3},\d{1,3}\)"
    matches = re.findall(regex,input_file.read())
    for match in matches:
       regex = "\d{1,3},\d{1,3}"
       numbers = re.findall(regex,match)
       for num in numbers:
           num = num.split(",")
           total += (int(num[0]) * int(num[1]))

print(total)