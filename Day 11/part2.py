import functools

start = None

with open("input.txt") as input_file:
    start = input_file.read().split(" ")

for i in range(0,len(start)):
    start[i] = int(start[i])
print(start)


cache = {}

@functools.cache
def CalculateBlinks(num,current_blink,goal_blinks):
    if current_blink < goal_blinks:
        if num == 0:
            return CalculateBlinks(1,current_blink+1,goal_blinks)
        elif len(str(num)) % 2 == 0:
            temp = str(num)
            return CalculateBlinks(int(temp[:len(temp)//2]),current_blink+1,goal_blinks) + CalculateBlinks(int(temp[len(temp)//2:]),current_blink+1,goal_blinks)
        else:
            return CalculateBlinks(num*2024,current_blink+1,goal_blinks)
    return 1


def CalculateBlinksCustomCache(num,current_blink,goal_blinks):
    if current_blink < goal_blinks:
        if num == 0:
            cache[(num,current_blink)] = CalculateBlinks(1,current_blink+1,goal_blinks)
        elif len(str(num)) % 2 == 0:
            temp = str(num)
            cache[(num,current_blink)] = CalculateBlinks(int(temp[:len(temp)//2]),current_blink+1,goal_blinks) + CalculateBlinks(int(temp[len(temp)//2:]),current_blink+1,goal_blinks)
        else:
            cache[(num,current_blink)] = CalculateBlinks(num*2024,current_blink+1,goal_blinks)
    return cache[(num,current_blink)] 


result = 0
for num in start:
    result += CalculateBlinksCustomCache(num,0,75)

print(result)
