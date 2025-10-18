import math
num_cols = None
num_rows = None
data = []

coords = []


data_array = []

mb = []

total = 0

class Lines:
    def __init__(self,mb,coord_pair):
        self.mb = mb
        self.potential_locations = []
        self.coord_pair = coord_pair



with open("input.txt") as input_file:
    lines = input_file.readlines()
    num_cols = len(lines)
    
    for line in lines:
        data.append(line.replace("\n",""))
    num_rows = len(data[0])

for line in data:
    for char in line:
        data_array.append(char)
'''
print(data)
print(num_cols)
print(num_rows)
'''


for i in range(0, len(data)):
    for j in range(0,len(data[i])):
        if data[i][j].isalnum():
            #print("{} ({},{})".format(data[i][j],i,j))
            coords.append((i,j))

for c1 in coords:
    for c2 in coords:
        #find each pair of unique coords with same value
        if c1 != c2 and data[c1[0]][c1[1]] == data[c2[0]][c2[1]]:
           
            #m = (y2-y1) / (x2-x1)
            m = (c2[1]-c1[1]) / (c2[0] - c1[0])

            #b = y - mx
            b = (c1[1] - (m*c1[0]))
            #print("y = {}x + {}".format(m,b))
            mb.append(Lines((m,b),(c1,c2)))

                
                

for line in mb:
    #print("y = {}x + {}".format(line.mb[0],line.mb[1]))
    for x in range(0, len(data)):
        for y in range(0,len(data[x])):
            if y == round(((line.mb[0]*x) + line.mb[1]),4):
                if data_array[(num_cols*x) + y] == ".":
                    data_array[(num_cols*x) + y] = "*"
                line.potential_locations.append((x,y))




for line in mb:
    print("y = {}x + {}".format(line.mb[0],line.mb[1]))
    #print(line.coord_pair)
    for potential_location in line.potential_locations:
        x = potential_location[0]
        y = potential_location[1]
        p1 = line.coord_pair[0]
        p2 = line.coord_pair[1]
        #print(x,y)
        distance1 = math.sqrt( ((x-p1[0])**2) +  ((y-p1[1])**2)  )
        distance2 = math.sqrt( ((x-p2[0])**2) +  ((y-p2[1])**2)  )
        #print("D1: {}  D2: {}".format(distance1,distance2))
        #print(distance1 == (distance2*2) or distance1 == (distance2/2))
        if(distance1 == (distance2*2) or distance1 == (distance2/2)):
            data_array[(num_cols*x) + y] = "#"

with open('out.txt', 'w') as f:
    for i in range(0,len(data_array)):
        f.write(data_array[i])
        if (i+1) % num_cols == 0 and (i+1) != len(data_array):
            f.write("\n")

print(data_array.count("#"))


