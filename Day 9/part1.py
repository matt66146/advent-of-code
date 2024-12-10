
input = None
with open("input.txt") as input_file:
    input = input_file.read()


data = []
cur_id = 0
new_data = []

for i in range(0,len(input)):
    for j in range(0,int(input[i])):
        if i == 0 or i % 2 == 0:
            data.append(cur_id)
        else:
            data.append(".")
    if i == 0 or i % 2 == 0:
        cur_id += 1


#print(data)
while data.count(".") > 0:
    for j in range (len(data)-1,0,-1):
        found = False
        if data[j] != ".":
            free_space_found = False
            found = True
            for d in data:
                if d == "." and not free_space_found:
                    free_space_found = True
                    new_data.append(data[j])
                else:
                    new_data.append(d)
        else:
            del data[-1]  
        if found:
            del new_data[-1]
            #print(new_data)
            data = new_data.copy()
            new_data = []
            break
    #break

checksum = 0

for i in range(0, len(data)):
    #print("{} * {}".format(data[i],i))
    checksum += (data[i] * i)
    #print(checksum)


print(data)
print(checksum)