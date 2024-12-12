import time

input = None
with open("input.txt") as input_file:
    input = input_file.read()


data = []
cur_id = 0


start = time.time()


for i in range(0,len(input)):
    for j in range(0,int(input[i])):
        if i == 0 or i % 2 == 0:
            data.append(cur_id)
        else:
            data.append(-1)
    if i == 0 or i % 2 == 0:
        cur_id += 1


#print(data)


countera = 0
counterb = 0

for i in range (len(data)-1,0,-1):
    countera += 1
    found = True
    if data[i] != -1:
        found = False
        for j in range(0,i):
            counterb += 1
            if data[j] == -1:
                data[j] = data[i]
                data[i] = -1
                found = True
                break
    if not found:
        break
    #print(data)
            
                
    #break

checksum = 0

for i in range(0, len(data)):
    #print("{} * {}".format(data[i],i))
    if (data[i] != -1):
        checksum += (data[i] * i)
    #print(checksum)

end = time.time()

print(data)
print(checksum)
print(countera)
print(counterb)
print(end-start)