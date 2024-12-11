
input = None
with open("input.txt") as input_file:
    input = input_file.read()


data = []
cur_id = 0


for i in range(0,len(input)):
    for j in range(0,int(input[i])):
        if i == 0 or i % 2 == 0:
            data.append(cur_id)
        else:
            data.append(-1)
    if i == 0 or i % 2 == 0:
        cur_id += 1


print(data)


countera = 0
counterb = 0


num_to_swap = None
swap_size = 0
for i in range (len(data)-1,0,-1):
    countera += 1
    found = True
    if data[i] != -1:
        if num_to_swap == None:
            num_to_swap = data[i]
    if data[i] != num_to_swap:
        empty_size = 0
        for j in range(0,i+1):
            counterb += 1
            if data[j] == -1:
                empty_size += 1
                if empty_size == swap_size:
                    #data[i+1] through data[i+swap_size] = .
                    #data[j] through data[j-(swap_size+1)]
                    for k in range(0,swap_size):
                        data[i+1+k] = -1
                    for k in range(0,swap_size):
                        data[j - k] = num_to_swap
                    if data[i] == -1:
                        num_to_swap = None
                        swap_size = 0
                    else:
                        num_to_swap = data[i]
                        swap_size = 1
                    empty_size = 0  
                    break
            else:
                empty_size = 0

        if data[i] == -1:
            num_to_swap = None
            swap_size = 0
        else:
            num_to_swap = data[i]
            swap_size = 1
        empty_size = 0  
                  
    else:
        swap_size += 1

       
    #print(data)
            
                
    #break

checksum = 0

for i in range(0, len(data)):
    #print("{} * {}".format(data[i],i))
    if (data[i] != -1):
        checksum += (data[i] * i)
    #print(checksum)


print(data)
print(checksum)
print(countera)
print(counterb)