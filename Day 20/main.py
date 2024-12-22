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
                return current_cost,prev
                # print(current_cost)

            for v in self.vertices[current_v]:
                cost = self.vertices[current_v][v] + current_cost
                if cost < dist[v]:
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
    s = None
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
                    s = (w,h)
                    start = f"({w},{h})"
                elif data[index] == "E":
                    end = f"({w},{h})"
                else:
                    dots[(w,h)] = None

    dots[s],path = graph.shortest_path_part_1(start, end)
    #print(path)
    #print(len(path.keys()))

    prev = end
    cur_distance = 0

    while len(path[prev]) > 0 :
        dots[eval(prev)] = cur_distance
        prev = path[prev][0]
        cur_distance += 1




    #print(dots)
    base_cost = dots[s]
    return base_cost, dots

def print_map(data,dots,width,height,cheats):
    row = " "
    for i in range(0,width):
        row +=("{:5n}".format(i))
    #print(row)

    cheat_walls = []
    for key in cheats:
        if cheats[key][1] not in cheat_walls:
            cheat_walls.append((cheats[key][1]))

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




        #print(row)
def manhattan(x1,y1,x2,y2):
    return abs(x1-x2) + abs(y1-y2)


def calculate_cheats(data,dots,width,height,min_saved_time,cheat_time):
    cheats = {}
    for key in dots:
        for y in range(max(key[1] - cheat_time, 0),min(key[1] + cheat_time+1, height)):
            for x in range(max(key[0] - cheat_time, 0),min(key[0] + cheat_time+1, width)):
                if (x,y) in dots:
                    distance = manhattan(key[0],key[1],x,y)
                    if distance <= cheat_time:
                        saved_time = dots[key]-distance - dots[x,y]
                        if saved_time >= min_saved_time:
                            cheats[(key, (x,y))] = saved_time
    return cheats




if __name__ == "__main__":
    def main():
        start = time.time()
        min_saved_time = 100
        data, width, height = load_map("input.txt")
        base_cost, dots= calculate_dot_path_costs(data,width,height)
        cheat_time = 20
        #print(len(dots))
        #return
        #print(dots)
        #print(f"Base Cost: {base_cost}")
        #print_map(data,dots,width,height, {})
        cheats = calculate_cheats(data,dots,width,height,min_saved_time,cheat_time)
        #print(cheats)
        #print_map(data,dots,width,height,cheats)
        print(f"Number of cheats that save at least {min_saved_time} seconds: {len(cheats)}")

        cheat_times = {}

        for key in cheats:
            if cheats[key] in cheat_times:
                cheat_times[cheats[key]] += 1
            else:
                cheat_times[cheats[key]] = 1

        #sorted_dict = dict(sorted(cheat_times.items()))
        #print(sorted_dict)
        end = time.time()
        print(f"Total elapsed time: {round(end-start,2)} seconds")

    main()