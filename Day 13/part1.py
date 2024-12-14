from collections import namedtuple
import time


Point = namedtuple("Point", ['x','y'])
class ClawMachine:
    def __init__(self,a:Point,b:Point,prize:Point):
        self.a:Point = a
        self.b:Point = b
        self.prize:Point = prize

claw_machines:list[ClawMachine] = []

total_tokens = 0

def CalculateButtonPresses(claw_machine:ClawMachine,start:str):
    answer_found = True
    global total_tokens
    tokens_a = 0
    tokens_b = 0
    #a not implemented for now
    if start == "a":
        if claw_machine.prize.x / claw_machine.a.x < claw_machine.prize.y / claw_machine.a.y:
            tokens_a = min(((claw_machine.prize.x / claw_machine.a.x)*3),300)
            #print(tokens_a)
        else:
            tokens_a = min(((claw_machine.prize.y / claw_machine.a.y)*3),300)
            #print(tokens_a)
        #A Start
    elif start == "b":
        if claw_machine.prize.x / claw_machine.b.x < claw_machine.prize.y / claw_machine.b.y:
            tokens_b = int(min(((claw_machine.prize.x / claw_machine.b.x)),100))
            #print(tokens_b)
        else:
            tokens_b = int(min(((claw_machine.prize.y / claw_machine.b.y)),100))
            #print(tokens_b)
        
        #B Start
        print(f"Prize: {claw_machine.prize.x} {claw_machine.prize.y}")
        print(f"Tokens: {tokens_a} {tokens_b}")
        x1 = claw_machine.b.x * tokens_b
        x2 = claw_machine.a.x * tokens_a

        y1 = claw_machine.b.y * tokens_b
        y2 = claw_machine.a.y * tokens_a
        print(x1+x2, y1+y2)

        distance_x = claw_machine.prize.x-(x1+x2)
        distance_y = claw_machine.prize.y-(y1+y2)
      
        while(distance_x != 0 or distance_y != 0):
            print(f"Total x:{x1+x2}, y:{y1+y2}")
            print(f"Distance: x:{distance_x}, y:{distance_y}")
            print(f"Token: a:{tokens_a}, b:{tokens_b}")
            distance_x -= claw_machine.a.x
            distance_y -= claw_machine.a.y
            if (distance_y >=0 and distance_x >=0):
                tokens_a += 1
            else:
                if (distance_x == 0 and distance_y == 0):
                    print("DONE!")
                else:
                    while distance_x - claw_machine.a.x < 0 or distance_y - claw_machine.a.y < 0:
                        #print(distance_y)
                        tokens_b -= 1
                        x1 = claw_machine.b.x * tokens_b
                        x2 = claw_machine.a.x * tokens_a

                        y1 = claw_machine.b.y * tokens_b
                        y2 = claw_machine.a.y * tokens_a
                        distance_x = claw_machine.prize.x-(x1+x2)
                        distance_y = claw_machine.prize.y-(y1+y2)

                    x1 = claw_machine.b.x * tokens_b
                    x2 = claw_machine.a.x * tokens_a

                    y1 = claw_machine.b.y * tokens_b
                    y2 = claw_machine.a.y * tokens_a
                    

                    distance_x = claw_machine.prize.x-(x1+x2)
                    distance_y = claw_machine.prize.y-(y1+y2)
            if ((tokens_a >=100 and tokens_b >= 100) or (tokens_a < 0 or tokens_b < 0)):
                answer_found = False
                break
                
   
                

        #print(f"Prize: {claw_machine.prize.x} {claw_machine.prize.y}")
        #print(f"Tokens: {tokens_a} {tokens_b}")
        x1 = claw_machine.b.x * tokens_b
        x2 = claw_machine.a.x * tokens_a

        y1 = claw_machine.b.y * tokens_b
        y2 = claw_machine.a.y * tokens_a
        #print(x1+x2, y1+y2)
        if answer_found:
            total_tokens += (tokens_a*3) + tokens_b
        
        







with open("test.txt") as input_file:
    data = input_file.read().split("\n\n")
    for machine in data: 
        item = machine.split("\n")

        a = Point(int(item[0].split(":")[1].split(",")[0].split("+")[1]),int(item[0].split(":")[1].split(",")[1].split("+")[1]))
        b = Point(int(item[1].split(":")[1].split(",")[0].split("+")[1]),int(item[1].split(":")[1].split(",")[1].split("+")[1]))
        prize = Point(int(item[2].split(":")[1].split(",")[0].split("=")[1]),int(item[2].split(":")[1].split(",")[1].split("=")[1]))



        claw_machine = ClawMachine(a,b,prize)
        claw_machines.append(claw_machine)
 

i = 0
for claw_machine in claw_machines:
    #a
    x_weight = claw_machine.prize.x/(claw_machine.a.x/3)
    y_weight = claw_machine.prize.y/(claw_machine.a.y/3)
    a_weight = x_weight+y_weight

    #b
    x_weight = claw_machine.prize.x/(claw_machine.b.x)
    y_weight = claw_machine.prize.y/(claw_machine.b.y)
    b_weight = x_weight+y_weight
    print("Next Machine:")
    CalculateButtonPresses(claw_machine,"b")
    '''
    if a_weight < b_weight:
        CalculateButtonPresses(claw_machine,"a")
    else:
        CalculateButtonPresses(claw_machine,"b")
        '''
    break

print(total_tokens)

