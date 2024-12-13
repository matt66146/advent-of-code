
from termcolor import colored
import time

start = time.time()

color_index = 0
colors = "red","green","yellow","blue","magenta","cyan","white"

class Region:
    def __init__(self, name, color):
        self.name = name
        self.color = color
        self.plants = []

class Walls:
    def __init__(self,plant_index):
        self.plant_index = plant_index
        self.left = False
        self.right = False
        self.up = False
        self.down = False

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




with open("input.txt") as input_file:
    num_cols = len(input_file.readline().replace("\n",""))

with open("input.txt") as input_file:
    plants = input_file.read().replace("\n","")





for i in range(0,len(plants)):
    GenerateRegion(i)


total_price = 0

#Calculate Walls
for region in regions:
    region.plants.sort()
    region_walls:list[Walls] = []
    for i in range(0,len(region.plants)):
        region_walls.append(Walls(region.plants[i]))
    perimeter = 0 
    price = 0
    for i in range(0,len(region.plants)):
        #print(f"index: {region.plants[i]}")
        #left
        if region.plants[i]-1 not in region.plants and region_walls[i].left == False:
                region_walls[i].left = True
                perimeter += 1
                #print("left")

                index = 1
                while (True):
                    #check up
                    if region.plants[i]-(index*num_cols) in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]-(index*num_cols))
                        wall.left = True
                        if region.plants[i]-(index*num_cols)-1 in region.plants:
                            break
                        index +=1
                    else:
                        break  
                index = 1
                while (True):
                    #check down
                    if region.plants[i]+(index*num_cols) in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]+(index*num_cols))
                        wall.left = True
                        if region.plants[i]+(index*num_cols)-1 in region.plants:
                            break
                        index +=1
                    else:
                        break
        else:
            region_walls[i].left = True
        #right
        if region.plants[i]+1 not in region.plants and region_walls[i].right == False:
                #print("right")
                region_walls[i].right = True
                perimeter += 1

                index = 1
                while (True):
                    #check up
                    if region.plants[i]-(index*num_cols) in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]-(index*num_cols))
                        wall.right = True
                        if region.plants[i]-(index*num_cols)+1 in region.plants:
                            break
                        index +=1
                    else:
                        break

                index = 1
                while (True):
                    #check down
                    if region.plants[i]+index*(num_cols) in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]+(index*num_cols))
                        wall.right = True
                        if region.plants[i]+(index*num_cols)+1 in region.plants:
                            break
                        index +=1
                    else:
                        break
        else:
            region_walls[i].right = True
        #up
        if region.plants[i]-num_cols not in region.plants and region_walls[i].up == False:
                #print("up")
                region_walls[i].up = True
                perimeter += 1

                index = 1
                while (True):
                    #check left
                    if region.plants[i]-index in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]-index)
                        wall.up = True
                        if region.plants[i]-index-num_cols in region.plants:
                            break
                        index +=1
                    else:
                        break

                index = 1
                while (True):
                    #check right
                    if region.plants[i]+index in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]+index)
                        wall.up = True
                        if region.plants[i]+index-num_cols in region.plants:
                            break
                        index += 1
                    else:
                        break
        else:
            region_walls[i].up = True
                    
        #down
        if region.plants[i]+num_cols not in region.plants and region_walls[i].down == False:
                #print("down")
                region_walls[i].down = True
                perimeter += 1

                index = 1
                while (True):
                    #check left
                    if region.plants[i]-index in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]-index)
                        wall.down = True
                        if region.plants[i]-index+num_cols in region.plants:
                            break
                        index += 1
                    else:
                        break
                index = 1
                while (True):
                    #check right
                    if region.plants[i]+index in region.plants:
                        wall = next(x for x in region_walls if x.plant_index == region.plants[i]+index)
                        wall.down = True
                        if region.plants[i]+index+num_cols in region.plants:
                            break
                        index +=1
                    else:
                        break
        else:
            region_walls[i].down = True

        #print(f"P: {perimeter}")
    price = perimeter*len(region.plants)
    #print("Region: {}".format(region.name))
    #print("Num Plants: {}".format(len(region.plants)))
    #print("Perimeter: {}".format(perimeter))
    #print("Price: {}".format(price))
    #print("")
    total_price += price
    
    



def PrintOutput():
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
PrintOutput()




end = time.time()

print(total_price)
print(end-start)