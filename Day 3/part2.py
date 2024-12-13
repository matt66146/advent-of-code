import re

total = 0
string_list = []

with open("input.txt") as input_file:
    data = input_file.read()
    start = 0
    end = 0
    end_of_file = False
    while not end_of_file:
        end = data.find("don't()",start)
        if (end == -1):
            string_list.append(data[start:])
            end_of_file = True
        else:
            string_list.append(data[start:end])

        start = data.find("do()",end)

        
for string in string_list:
    regex = r"mul\(\d{1,3},\d{1,3}\)"
    matches = re.findall(regex,string)
    for match in matches:
       regex = r"\d{1,3},\d{1,3}"
       numbers = re.findall(regex,match)
       for num in numbers:
           num = num.split(",")
           total += (int(num[0]) * int(num[1]))

print(total)
