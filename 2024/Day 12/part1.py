from termcolor import colored



color_index = 0
colors = "black","red","green","yellow","blue","magenta","cyan","white"

class Region:
    def __init__(self, name, color):
        self.name = name
        self.color = color
        self.plants = []


num_cols = None
regions:list[Region] = []
plants = None


def GenerateRegion(index):
    global color_index
    global colors
    global num_cols
    global regions
    global plants

    found = False
    for region in regions:
        if index in region.plants:
            found = True
            break
    if not found:
        region = Region(plants[index],colors[color_index])
        region.plants.append(index)
        color_index +=1
        if color_index == len(colors):
            color_index = 0
        regions.append(region)
        AddPlants(index,region)



def AddPlants(index,region:Region):
    #up
    if index-num_cols >= 0:
        if plants[index-num_cols] == plants[index]:
            if index-num_cols not in region.plants:
                region.plants.append(index-num_cols)
                AddPlants(index-num_cols,region)
    #down
    if index+num_cols < len(plants):
        if plants[index+num_cols] == plants[index]:
            if index+num_cols not in region.plants:
                region.plants.append(index+num_cols)
                AddPlants(index+num_cols,region)
    #left
    if (index%num_cols) - 1 >= 0:
        if plants[index - 1] == plants[index]:
            if index - 1 not in region.plants:
                region.plants.append(index - 1)
                AddPlants(index - 1,region)
    #right
    if (index%num_cols) + 1 < num_cols:
        if plants[index + 1] == plants[index]:
            if index + 1 not in region.plants:
                region.plants.append(index + 1)
                AddPlants(index + 1,region)




with open("test1.txt") as input_file:
    num_cols = len(input_file.readline().replace("\n",""))

with open("test1.txt") as input_file:
    plants = input_file.read().replace("\n","")





for i in range(0,len(plants)):
    GenerateRegion(i)


total_price = 0

for region in regions:
    perimeter = 0 
    price = 0
    
    for i in range(0,len(region.plants)):
        #print(f"index: {i}")
        #left
        if region.plants[i]-1 not in region.plants:
                #print("left")
                perimeter += 1
        #right
        if region.plants[i]+1 not in region.plants:
                #print("right")
                perimeter += 1
        #up
        if region.plants[i]-num_cols not in region.plants:
                #print("up")
                perimeter += 1
        #down
        if region.plants[i]+num_cols not in region.plants:
                #print("down")
                perimeter += 1
        #print(f"P: {perimeter}")
    price = perimeter*len(region.plants)
    print("Region: {}".format(region.name))
    print("Num Plants: {}".format(len(region.plants)))
    print("Perimeter: {}".format(perimeter))
    print("Price: {}".format(price))
    print("")
    total_price += price
    




# Print output
output = []
for i in range(0,len(plants)):
    output.append("")

for region in regions:
    print(colored(str(region.plants),region.color))
    for plant in region.plants:
        output[plant] = colored(region.name,region.color)

print("Num Regions: {}".format(len(regions)))
print_str = ""
index = 0
for plant in output:
    if index < num_cols:
        print_str+= plant
        index += 1
    else:
        print(print_str)
        index = 1
        print_str = plant
print(print_str)


print(total_price)