import re

total = 0


def Check(index, direction):
    if data[index + direction] == "M":
        if data[index + (direction*2)] == "A":
            if data[index + (direction*3)] == "S":
                return True
    return False


with open("input.txt") as input_file:
    width =  len(re.sub(r'[^a-zA-Z0-9]', '', input_file.readline()))
    input_file.seek(0)

    data = re.sub(r'[^a-zA-Z0-9]', '', input_file.read())

    for i in range(0,len(data)):
        if (data[i] == "X"):
            #left
            if (i % width >= 3):
                if Check(i,-1):
                    total += 1
            #right
            if (i % width < width-3):
                if Check(i,1):
                    total += 1
            #up
            if (i // width >= 3):
                if Check(i,-width):
                    total += 1
            #down
            if (i // width < (len(data)//width)-3):
                if Check(i,width):
                    total += 1
            #up-left
            if (i % width >= 3):
                if (i // width >= 3):
                    if Check(i,-width-1):
                        total += 1
            #up-right
            if (i % width < width-3):
                if (i // width >= 3):
                     if Check(i,-width+1):
                        total += 1
            #down-left
            if (i % width >= 3):
                if (i // width < (len(data)//width)-3):
                     if Check(i,width-1):
                        total += 1
            #down-right
            if (i % width < width-3):
                if (i // width < (len(data)//width)-3):
                    if Check(i,width+1):
                        total += 1
            



print(total)
