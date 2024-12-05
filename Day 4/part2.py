import re

total = 0


with open("input.txt") as input_file:
    width =  len(re.sub(r'[^a-zA-Z0-9]', '', input_file.readline()))
    input_file.seek(0)

    data = re.sub(r'[^a-zA-Z0-9]', '', input_file.read())

    for i in range(0,len(data)):
        if (data[i] == "A"):
            if (i % width >= 1) and (i % width < width-1) and (i // width >= 1) and (i // width < (len(data)//width)-1):
                left = False
                right = False

                #top-left
                if (data[i - width - 1] == "M" and data[i + width + 1] == "S"):
                    left = True
                elif (data[i - width - 1] == "S" and data[i + width + 1] == "M"):
                        left = True
                #bottom-left
                if left:
                    if (data[i + width - 1] == "M" and data[i - width + 1] == "S"):
                        right = True
                    elif (data[i + width - 1] == "S" and data[i - width + 1] == "M"):
                            right = True
                if right and left:
                    total += 1



                     
          



print(total)
