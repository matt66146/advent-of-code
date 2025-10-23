import heapq
import time

def generate_map(data, width, height, walls):
    for h in range(0, height):
        for w in range(0, width):
            if (w, h) in walls:
                data[(h * width) + w] = "#"
            else:
                data[(h * width) + w] = "."


def print_map(data, width, height):
    for h in range(0, height):
        row = ""
        for w in range(0, width):
            row += str(data[(h * width) + w])
        print(row)


def load_walls(file_string):
    walls = []
    with open(file_string) as file_name:
        for line in file_name:
            coord = line.strip().split(",")
            walls.append((int(coord[0]), int(coord[1])))
    return walls


def get_wall_index(wall, file_string):
    with open(file_string) as file_name:
        return file_name.readlines()[wall - 1]


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


def find_shortest_path(data, width, height):
    graph = Graph()
    start = None
    end = None

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

    start = f"({0},{0})"
    end = f"({width - 1},{height - 1})"

    return graph.shortest_path_part_1(start, end)


if __name__ == "__main__":
    def main():
        start = time.time()
        width = 71
        height = 71
        data = [None] * width * height
        file_string = "input.txt"
        num_walls = 1024

        # Part 1
        walls = load_walls(file_string)
        if len(walls) > 0:
            generate_map(data, width, height, walls[0:num_walls])
            # print_map(data, width, height)
            print(f"Part 1: {find_shortest_path(data, width, height)}")

        # Part 2
        min_wall = 1025
        max_wall = len(walls)
        while min_wall < max_wall:
            num_walls = (min_wall + max_wall) // 2
            walls = load_walls(file_string)
            if len(walls) > 0:
                generate_map(data, width, height, walls[0:num_walls])
                # print_map(data, width, height)
                if find_shortest_path(data, width, height) is None:
                    max_wall = num_walls - 1
                else:
                    min_wall = num_walls + 1
        print(f"Part 2: {get_wall_index(num_walls, file_string)}")
        end = time.time()
        print(end-start)

    main()
