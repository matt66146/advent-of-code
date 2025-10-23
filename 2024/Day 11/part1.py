

start = None

with open("input.txt") as input_file:
    start = input_file.read().split(" ")

for i in range(0,len(start)):
    start[i] = int(start[i])
print(start)

num_stones = len(start)


def CalculateBlinks(num,current_blink,goal_blinks):
    global num_stones
    if current_blink < goal_blinks:
        if num == 0:
            CalculateBlinks(1,current_blink+1,goal_blinks)
        elif len(str(num)) % 2 == 0:
            temp = str(num)
            num_stones += 1
            CalculateBlinks(int(temp[:len(temp)//2]),current_blink+1,goal_blinks)
            CalculateBlinks(int(temp[len(temp)//2:]),current_blink+1,goal_blinks)
        else:
            CalculateBlinks(num*2024,current_blink+1,goal_blinks)
    





for num in start:
    CalculateBlinks(num,0,25)


print(num_stones)