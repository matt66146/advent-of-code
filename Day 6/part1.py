from enum import Enum
import time
import os

wall = "#"
empty = "."
X = "X"

class Direction(Enum):
    Up = "^"
    Down = "v"
    Left = "<"
    Right = ">"

class Guard:
    def __init__(self,direction=None,x=None, y=None):
        self.direction = direction
        self.x = x
        self.y = y
    def index(self):
        return (self.y*(num_rows))+self.x


puzzle_map = []


num_rows = 0
num_cols = 0
total_positions = 1

guard  = Guard(direction=Direction.Up)
end = False

def clear_console():
    """Clears the console."""
    command = 'cls' if os.name in ('nt', 'dos') else 'clear'
    os.system(command)

def PrintMap():
    for i in range(0,num_rows):
        row_text = ""
        for j in range(0,num_rows):

            row_text += puzzle_map[(i*(num_rows))+j]
        print(row_text)

def GetGuardLocation():
    index = puzzle_map.index(guard.direction.value)
    x = index%num_rows
    y = index//num_rows
    guard.x = x
    guard.y = y
    return [x,y,index]

def GetIndex(x,y):
    return (y*(num_rows))+x


def MoveForward():
   global puzzle_map
   global guard
   global total_positions
   global end
   
   match guard.direction:
        case Direction.Up:
            if guard.y - 1 >= 0:
                move_pos = GetIndex(guard.x,guard.y-1)
                if puzzle_map[move_pos] == empty or puzzle_map[move_pos] == X:
                    if puzzle_map[move_pos] == empty:
                        total_positions += 1
                    puzzle_map[move_pos] = guard.direction.value
                    puzzle_map[guard.index()] = X
                    guard.y -= 1
                elif puzzle_map[move_pos] == wall:
                    guard.direction = Direction.Right
                    puzzle_map[guard.index()] = guard.direction.value

            else:
                end = True
        case Direction.Down:
            if guard.y + 1 < num_rows:
                move_pos = GetIndex(guard.x,guard.y+1)
                if puzzle_map[move_pos] == empty or puzzle_map[move_pos] == X:
                    if puzzle_map[move_pos] == empty:
                        total_positions += 1
                    puzzle_map[move_pos] = guard.direction.value
                    puzzle_map[guard.index()] = X
                    guard.y += 1
                elif puzzle_map[move_pos] == wall:
                    guard.direction = Direction.Left
                    puzzle_map[guard.index()] = guard.direction.value

            else:
                end = True
        case Direction.Left:
            if guard.x - 1 >= 0:
                move_pos = GetIndex(guard.x-1,guard.y)
                if puzzle_map[move_pos] == empty or puzzle_map[move_pos] == X:
                    if puzzle_map[move_pos] == empty:
                        total_positions += 1
                    puzzle_map[move_pos] = guard.direction.value
                    puzzle_map[guard.index()] = X
                    guard.x -= 1
                elif puzzle_map[move_pos] == wall:
                    guard.direction = Direction.Up
                    puzzle_map[guard.index()] = guard.direction.value
            else:
                end = True
        case Direction.Right:
            if guard.x + 1 < num_cols:
                move_pos = GetIndex(guard.x+1,guard.y)
                if puzzle_map[move_pos] == empty or puzzle_map[move_pos] == X:
                    if puzzle_map[move_pos] == empty:
                        total_positions += 1
                    puzzle_map[move_pos] = guard.direction.value
                    puzzle_map[guard.index()] = X
                    guard.x += 1
                elif puzzle_map[move_pos] == wall:
                    guard.direction = Direction.Down
                    puzzle_map[guard.index()] = guard.direction.value

            else:
                end = True
        case _:
            print("This shouldn't happen")


with open("input.txt") as input_file:
    data = input_file.readlines()
    num_rows = len(data)
    num_cols = len(data[0].rstrip())
    for row in data:
        row = row.rstrip()
        for point in row:
            puzzle_map.append(point)
GetGuardLocation()


while not end:
    MoveForward()
    """
    clear_console()
    PrintMap()
    print(total_positions)
    MoveForward()
    """

PrintMap()
print(total_positions)