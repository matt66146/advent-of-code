import time
import heapq
from termcolor import colored


def load_map(name_string):
    data = []
    width = None
    dots = []
    start = None
    end = None

    with open(name_string) as file_name:
        for line in file_name:
            width = len(line)
            for point in line.strip():
                data.append(point)
    height = len(data) // width


    return data, width, height

class Graph:
    def __init__(self):
        self.vertices = {}

    def add_edge(self, v1, v2, cost):
        if v1 not in self.vertices:
            self.vertices[v1] = {}
        self.vertices[v1][v2] = cost
        # print(len(self.vertices.keys()))

    def shortest_path_part_1(self, src, dest):
        size = len(self.vertices.keys())
        pq = [(0, src)]
        dist = {}
        prev = {}
        for key in self.vertices:
            dist[key] = float('inf')
        for key in self.vertices:
            prev[key] = []
        dist[src] = 0

        while pq:
            current_cost, current_v = heapq.heappop(pq)
            if current_v == dest:
                return current_cost
                # print(current_cost)

            for v in self.vertices[current_v]:
                cost = self.vertices[current_v][v] + current_cost
                if cost < dist[v]:
                    # print(v)
                    prev[v] = [current_v]
                    dist[v] = cost
                    heapq.heappush(pq, (dist[v], v))
                elif cost == dist[v]:
                    prev[v].append(current_v)
        # print(prev)
def calculate_dot_path_costs(data,width,height):
    graph = Graph()
    start = None
    end = None
    dots = {}
    for h in range(0, height):
        for w in range(0, width):
            index = (h * width) + w
            if data[index] != "#":
                # left
                if w > 0:
                    if data[index - 1] != "#":
                        graph.add_edge(f"({w},{h})", f"({w - 1},{h})", 1)
                # up
                if h > 0:
                    if data[index - width] != "#":
                        graph.add_edge(f"({w},{h})", f"({w},{h - 1})", 1)
                # right
                if w < width - 1:
                    if data[index + 1] != "#":
                        graph.add_edge(f"({w},{h})", f"({w + 1},{h})", 1)
                # down
                if h < height - 1:
                    if data[index + width] != "#":
                        graph.add_edge(f"({w},{h})", f"({w},{h + 1})", 1)
                if data[index] == "S":
                    start = f"({w},{h})"
                elif data[index] == "E":
                    end = f"({w},{h})"
                else:
                    dots[(w,h)] = None

    base_cost = graph.shortest_path_part_1(start, end)

    for key in dots:
        dots[key] = graph.shortest_path_part_1(f"({key[0]},{key[1]})", end)
    return base_cost, dots

def print_map(data,dots,width,height,cheats):
    row = " "
    for i in range(0,width):
        row +=("{:5n}".format(i))
    print(row)

    cheat_walls = []
    print("-------------")
    for key in cheats:
        if cheats[key][1] not in cheat_walls:
            cheat_walls.append((cheats[key][1]))

    print("-------------")
    for h in range(0, height):
        row = ("{:<5n}".format(h))
        for w in range(0, width):
            point = data[(h * width) + w]
            if point == ".":
                row += colored("{:5s}".format(str(dots[(w,h)])),"light_green")
            elif (w,h) in cheat_walls:
                row += colored("{:5s}".format(str(data[(h * width) + w])), "light_yellow")
            elif point == "#":
                row += colored("{:5s}".format(str(data[(h * width) + w])),"light_red")
            elif point == "S":
                row += colored("{:5s}".format(str(data[(h * width) + w])), "light_blue")
            elif point == "E":
                row += colored("{:5s}".format(str(data[(h * width) + w])), "light_magenta")




        print(row)

def calculate_cheats(data,dots,width,height):
    cheats = {}
    for key in dots:
        #up
        if (key[0],key[1]-2) in dots:
            saved_time = dots[key]-2 - dots[key[0],key[1]-2]
            if saved_time > 0:
                if data[key[0]*(key[1]-1)] == "#":
                    cheats[key] = (saved_time,(key[0],(key[1]-1)))
        # down
        if (key[0], key[1] + 2) in dots:
            saved_time = dots[key] - 2 - dots[key[0], key[1] + 2]
            if saved_time > 0:
                if data[key[0] * (key[1] + 1)] == "#":
                    cheats[key] = (saved_time,(key[0], (key[1] + 1)))
        # left
        if (key[0] - 2, key[1]) in dots:
            saved_time = dots[key] - 2 - dots[key[0] - 2, key[1]]
            if saved_time > 0:
                if data[(key[0] - 1) * (key[1])] == "#":
                    cheats[key] = (saved_time,((key[0] - 1), (key[1])))
        # right
        if (key[0] + 2, key[1]) in dots:
            saved_time = dots[key] - 2 - dots[key[0] + 2, key[1]]
            if saved_time > 0:
                if data[(key[0] + 1) * (key[1])] == "#":
                    cheats[key] = (saved_time,((key[0] + 1), (key[1])))
    return cheats




if __name__ == "__main__":
    def main():
        data, width, height = load_map("test.txt")
        base_cost, dots = calculate_dot_path_costs(data,width,height)
        print(dots)
        print(f"Base Cost: {base_cost}")
        print_map(data,dots,width,height, {})
        cheats = calculate_cheats(data,dots,width,height)
        print(cheats)
        print_map(data,dots,width,height,cheats)
        print(len(cheats))


    main()