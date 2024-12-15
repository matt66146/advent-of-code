

class Bot:
    def __init__(self,x,y,speed_x,speed_y):
        self.x = x
        self.y = y
        self.speed_x = speed_x
        self.speed_y = speed_y
    def __repr__(self):
        return f"x={self.x}, y={self.y}, speed_x={self.speed_x}, speed_y={self.speed_y}"



width = 101
height = 103
time_elapsed = 100


positions = [0] * width * height

bots:list[Bot] = []

quad1=0
quad2=0
quad3=0
quad4=0

with open("input.txt") as input_file:
    for line in input_file.readlines():
        p = line.split(" ")[0].split("=")[1].split(",")
        x = int(p[0])
        y = int(p[1])

        v = line.split(" ")[1].split("=")[1].split(",")
        x_speed = int(v[0])
        y_speed = int(v[1])

        bots.append(Bot(x,y,x_speed,y_speed))





for bot in bots:
    print(bot)
    bot.x = (bot.x + (bot.speed_x*time_elapsed))%width
    bot.y = (bot.y + (bot.speed_y*time_elapsed))%height
    positions[(bot.y*width) + bot.x] += 1


for h in range(0,height):
    row = ""
    for w in range(0,width):
        color = ""
        #top left
        if w < (width/2)-1 and h < (height/2)-1:
            color = "\033[31m"
            quad1+=positions[(h*width)+w]
        #top right
        if w > (width/2) and h < (height/2)-1:
            color = "\033[32m"
            quad2+=positions[(h*width)+w]
        #bottom left
        if w < (width/2)-1 and h > (height/2):
            color = "\033[34m"
            quad3+=positions[(h*width)+w]
        #bottom right
        if w > (width/2)  and h > (height/2):
            color = "\033[35m"
            quad4+=positions[(h*width)+w]

        if w == width//2 or h == height//2:
            row += " "
        else:
            row += color+str(positions[(h*width)+w])+"\033[0m" if positions[(h*width)+w] != 0 else color+"."+"\033[0m"
            
    print(row)



print(quad1*quad2*quad3*quad4)
    