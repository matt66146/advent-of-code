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

def CalculateButtonPresses(claw_machine:ClawMachine):
    global total_tokens
    tokens_a = 0
    tokens_b = 0
    print(f"{claw_machine.a.x}a + {claw_machine.b.x}b = {claw_machine.prize.x}")
    print(f"{claw_machine.a.y}a + {claw_machine.b.y}b = {claw_machine.prize.y}")

    a1 = claw_machine.a.x * claw_machine.b.y
    b1 = claw_machine.b.x * claw_machine.b.y
    c1 = claw_machine.prize.x * claw_machine.b.y

    a2 = claw_machine.a.y * claw_machine.b.x
    b2 = claw_machine.b.y * claw_machine.b.x
    c2 = claw_machine.prize.y * claw_machine.b.x
    print(a1,b1,c1)
    print(a2,b2,c2)

    print(f"{a1-a2} + {b1-b2} = {c1-c2}")
    if (c1-c2)%(a1-a2) != 0:
        print("No Solution")
        return
    a = (c1-c2)/(a1-a2)
    print(a,"\n\n")

    print(f"{claw_machine.a.x*a} + {claw_machine.b.x} = {claw_machine.prize.x}")

    if (claw_machine.prize.x-(claw_machine.a.x*a))%claw_machine.b.x != 0:
            print("No Solution")
            return
    b = (claw_machine.prize.x-(claw_machine.a.x*a))/claw_machine.b.x
    
    print(b)
    tokens_a = a * 3
    tokens_b = b
    total_tokens += tokens_a+tokens_b







with open("input.txt") as input_file:
    data = input_file.read().split("\n\n")
    for machine in data: 
        item = machine.split("\n")

        a = Point(int(item[0].split(":")[1].split(",")[0].split("+")[1]),int(item[0].split(":")[1].split(",")[1].split("+")[1]))
        b = Point(int(item[1].split(":")[1].split(",")[0].split("+")[1]),int(item[1].split(":")[1].split(",")[1].split("+")[1]))
        prize = Point(10000000000000+int(item[2].split(":")[1].split(",")[0].split("=")[1]),10000000000000+int(item[2].split(":")[1].split(",")[1].split("=")[1]))



        claw_machine = ClawMachine(a,b,prize)
        claw_machines.append(claw_machine)
 


for claw_machine in claw_machines:
    print("Next Machine:")
    CalculateButtonPresses(claw_machine)


print(total_tokens)

