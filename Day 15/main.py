from termcolor import colored, cprint
import time

class TileMap:
    def __init__(self, data, width, height):
        self.data: list[Object|Wall|Robot|Box|BoxLeft|BoxRight] = data
        self.width = width
        self.height = height


class Object:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def try_move(self, direction, tile_map: TileMap):
        return True

    def move(self, direction, tile_map: TileMap):
        # store .
        tmp = tile_map.data[((self.y * tile_map.width) + self.x) + direction]

        # change . to @
        tile_map.data[((self.y * tile_map.width) + self.x) + direction] = tile_map.data[
            ((self.y * tile_map.width) + self.x)]

        # change @ to dot
        tile_map.data[((self.y * tile_map.width) + self.x)] = tmp

        # update .
        index = (self.y * tile_map.width) + self.x
        tile_map.data[((self.y * tile_map.width) + self.x)].x = self.x
        tile_map.data[((self.y * tile_map.width) + self.x)].y = self.y

        # update @
        index = (self.y * tile_map.width) + self.x + direction
        self.x = index % tile_map.width
        self.y = index // tile_map.width


class Wall(Object):
    def __init__(self, x, y):
        super().__init__(x, y)

    def try_move(self, direction, tile_map: TileMap):
        return False


class Robot(Object):
    def __init__(self, x, y):
        super().__init__(x, y)

    def try_move(self, direction, tile_map: TileMap):
        if tile_map.data[((self.y * tile_map.width) + self.x) + direction].try_move(direction, tile_map):
            super().move(direction, tile_map)


class BoxRight(Object):
    def __init__(self, x, y):
        super().__init__(x, y)

    def check_move_valid(self,list_objects:list,direction, tile_map: TileMap):
        my_index = ((self.y * tile_map.width) + self.x)
        next_index = ((self.y * tile_map.width) + self.x) + direction
        if not isinstance(tile_map.data[next_index],Wall):
            if self in list_objects:
                return list_objects
            list_objects.append(self)
            if len(list_objects) >= 2:
                if tile_map.data[my_index-1] != list_objects[-2]:
                    # check left side of box
                    if not tile_map.data[my_index - 1].check_move_valid(list_objects,direction, tile_map):
                        return []
            else:
                # check left side of box
                if not tile_map.data[my_index - 1].check_move_valid(list_objects, direction, tile_map):
                    return []

            if isinstance(tile_map.data[next_index],BoxRight) or isinstance(tile_map.data[next_index],BoxLeft):
                #check next box is valid
                if not tile_map.data[next_index].check_move_valid(list_objects,direction, tile_map):
                    return []
        else:
            list_objects = []

        return list_objects

    def try_move(self, direction, tile_map: TileMap):
        if abs(direction) > 1:
            list_objects = self.check_move_valid([],direction,tile_map)
            if not list_objects:
                return False
            else:
                if direction < 0:
                    list_objects.sort(key=lambda obj: obj.y)
                else:
                    list_objects.sort(key=lambda obj: obj.y, reverse=True)
                for box in list_objects:
                    box.move(direction, tile_map)
                return True


        # Left right
        if tile_map.data[((self.y * tile_map.width) + self.x) + direction].try_move(direction, tile_map):
            self.move(direction, tile_map)
            return True
        else:
            return False

    def move(self, direction, tile_map: TileMap):
        super().move(direction, tile_map)

class BoxLeft(Object):
    def __init__(self, x, y):
        super().__init__(x, y)

    def check_move_valid(self,list_objects:list,direction, tile_map: TileMap):
        my_index = ((self.y * tile_map.width) + self.x)
        next_index = ((self.y * tile_map.width) + self.x) + direction
        if not isinstance(tile_map.data[next_index],Wall):
            if self in list_objects:
                return list_objects
            list_objects.append(self)
            if len(list_objects) >= 2:
                if tile_map.data[my_index + 1] != list_objects[-2]:
                    # check right side of box
                    if not tile_map.data[my_index + 1].check_move_valid(list_objects, direction, tile_map):
                        return []
            else:
                # check right side of box
                if not tile_map.data[my_index + 1].check_move_valid(list_objects, direction, tile_map):
                    return []

            if isinstance(tile_map.data[next_index],BoxRight) or isinstance(tile_map.data[next_index],BoxLeft):
                #check next box is valid
                if not tile_map.data[next_index].check_move_valid(list_objects,direction, tile_map):
                    return []
        else:
            list_objects = []

        return list_objects

    def try_move(self, direction, tile_map: TileMap):
        if abs(direction) > 1:
            list_objects = self.check_move_valid([],direction,tile_map)
            if not list_objects:
                return False
            else:
                if direction < 0:
                    list_objects.sort(key=lambda obj: obj.y)
                else:
                    list_objects.sort(key=lambda obj: obj.y, reverse=True)
                for box in list_objects:
                    box.move(direction, tile_map)
                return True


        # Left right
        if tile_map.data[((self.y * tile_map.width) + self.x) + direction].try_move(direction, tile_map):
            self.move(direction, tile_map)
            return True
        else:
            return False

class Box(Object):
    def __init__(self, x, y):
        super().__init__(x, y)

    def try_move(self, direction, tile_map: TileMap):
        if tile_map.data[((self.y * tile_map.width) + self.x) + direction].try_move(direction, tile_map):
            self.move(direction, tile_map)
            return True
        else:
            return False

    def move(self, direction, tile_map: TileMap):
        super().move(direction, tile_map)


def print_tile_map(tile_map):
    for h in range(0, tile_map.height):
        row = ""
        for w in range(0, tile_map.width):
            if isinstance(tile_map.data[(h * tile_map.width) + w], Box):
                row += colored("O", "light_blue")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Robot):
                row += colored("@", "light_green")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Wall):
                row += colored("#", "light_red")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Object):
                row += "."
        print(row)


def print_tile_map_p2(tile_map):
    for h in range(0, tile_map.height):
        row = ""
        for w in range(0, tile_map.width):
            if isinstance(tile_map.data[(h * tile_map.width) + w], BoxLeft):
                row += colored("[", "light_blue")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], BoxRight):
                row += colored("]", "light_blue")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Robot):
                row += colored("@", "light_green")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Wall):
                row += colored("#", "light_red")
            elif isinstance(tile_map.data[(h * tile_map.width) + w], Object):
                row += "."
        print(row)


def part1(file_name):
    data = []
    string_data = []
    inputs = []
    robot: Robot | None = None
    with open(file_name) as input_file:
        for line in input_file:
            if line.strip() == "":
                break
            width = len(line.strip())
            for point in line.strip():
                string_data.append(point)
        height = len(string_data) // width
        for line in input_file.readlines():
            for symbol in line:
                inputs.append(symbol)

    for i in range(0, len(string_data)):
        if string_data[i] == ".":
            x = i % width
            y = i // width
            data.append(Object(x, y))
        elif string_data[i] == "@":
            x = i % width
            y = i // width
            robot = Robot(x, y)
            data.append(robot)
        elif string_data[i] == "#":
            x = i % width
            y = i // width
            data.append(Wall(x, y))
        elif string_data[i] == "O":
            x = i % width
            y = i // width
            data.append(Box(x, y))

    tile_map = TileMap(data, width, height)
    #print_tile_map(tile_map)

    for direction in inputs:
        if direction == "<":
            robot.try_move(-1, tile_map)
        elif direction == ">":
            robot.try_move(1, tile_map)
        elif direction == "^":
            robot.try_move(-width, tile_map)
        elif direction == "v":
            robot.try_move(width, tile_map)
        # print_tile_map(tile_map)
    gps_sum = 0
    for symbol in tile_map.data:
        if isinstance(symbol, Box):
            gps_sum += (symbol.y * 100) + symbol.x

    #print_tile_map(tile_map)
    print(f"Part1: {gps_sum}")


def part2(file_name):
    data = []
    string_data = []
    inputs = []
    robot: Robot | None = None
    with open(file_name) as input_file:
        for line in input_file:
            if line.strip() == "":
                break
            width = len(line.strip())
            for point in line.strip():
                if point == "#":
                    string_data.append(point)
                    string_data.append(point)
                elif point == "O":
                    string_data.append("[")
                    string_data.append("]")
                elif point == ".":
                    string_data.append(point)
                    string_data.append(point)
                elif point == "@":
                    string_data.append(point)
                    string_data.append(".")
        width *= 2
        height = len(string_data) // width
        for line in input_file.readlines():
            for symbol in line:
                inputs.append(symbol)

    for i in range(0, len(string_data)):
        if string_data[i] == ".":
            x = i % width
            y = i // width
            data.append(Object(x, y))
        elif string_data[i] == "@":
            x = i % width
            y = i // width
            robot = Robot(x, y)
            data.append(robot)
        elif string_data[i] == "#":
            x = i % width
            y = i // width
            data.append(Wall(x, y))
        elif string_data[i] == "[":
            x = i % width
            y = i // width
            data.append(BoxLeft(x, y))
        elif string_data[i] == "]":
            x = i % width
            y = i // width
            data.append(BoxRight(x, y))

    tile_map = TileMap(data, width, height)
    #print_tile_map_p2(tile_map)

    i = 0
    for direction in inputs:
        if direction == "<":
            robot.try_move(-1, tile_map)
        elif direction == ">":
            robot.try_move(1, tile_map)
        elif direction == "^":
            robot.try_move(-width, tile_map)
        elif direction == "v":
            robot.try_move(width, tile_map)
        # print_tile_map(tile_map)
        i += 1
    gps_sum = 0
    for symbol in tile_map.data:
        if isinstance(symbol, BoxLeft):
            gps_sum += (symbol.y * 100) + symbol.x

    #print_tile_map_p2(tile_map)
    print(f"Part2: {gps_sum}")


if __name__ == "__main__":
    def main():
        #part1("test_p1.txt")
        #part1("test.txt")
        part1("input.txt")
        part2("input.txt")


    main()
