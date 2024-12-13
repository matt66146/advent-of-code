

total_safe = 0


def CheckList(skip_index: int, original_list: list):
    list = original_list.copy()
    safe = True
    increasing = False
    decreasing = False

    if (skip_index != -1):
        list.pop(skip_index)

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
    return safe



with open("input.txt") as input_file:
    for line in input_file:

        list = line.split(" ")
        num_checked = 0
        safe = CheckList(-1, list)
        
        

        if (safe):
            total_safe += 1
        else:
            while num_checked < len(list):
                safe = CheckList(num_checked, list)
                num_checked += 1
                if (safe):
                    total_safe += 1
                    break
                
                


print(total_safe)




    
