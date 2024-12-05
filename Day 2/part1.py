

total_safe = 0




with open("input.txt") as input_file:
    for line in input_file:
        safe = True
        increasing = False
        decreasing = False
        list = line.split(" ")
        if (increasing and decreasing):
            safe = False
        if (safe):
            for i in range(1,len(list)):
                result = int(list[i]) - int(list[i-1])
                if (result < -3 or result > 3 or result == 0):
                    safe = False
                    break
                if (result < 0):
                    decreasing = True
                if (result > 0):
                    increasing = True
        
        if (increasing and decreasing):
            safe = False
        if (safe):
            total_safe += 1

print(total_safe)




    
