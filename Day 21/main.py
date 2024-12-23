import time
from termcolor import colored
import functools
import heapq


class Graph:
    def __init__(self):
        self.vertices = {}

    def add_edge(self, v1, v2, cost, direction):
        if v1 not in self.vertices:
            self.vertices[v1] = {}
        self.vertices[v1][v2] = {"cost": cost, "direction": direction}

    def dijkstra_shortest_path(self, src, dest):
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
                return dist, prev

            for v in self.vertices[current_v]:
                cost = self.vertices[current_v][v]["cost"] + current_cost
                if cost < dist[v]:
                    prev[v] = [current_v]
                    dist[v] = cost
                    heapq.heappush(pq, (dist[v], v))
                elif cost == dist[v]:
                    prev[v].append(current_v)
        return None


@functools.cache
def calculate_path(src, dest, graph):
    dist, prev = graph.dijkstra_shortest_path(src, dest)
    print(prev)
    paths = [""]

    walk_backwards(prev, dest, src, paths, 0, graph)
    print(paths)
    path_biggest_chars = {}
    i = 0
    for path in paths:

        current_char = None
        num_char = 0
        biggest_char = 0
        biggest_chars = []
        for direction in path:
            if current_char is None:
                current_char = direction
            else:
                if current_char != direction:
                    current_char = direction
                    biggest_chars.append(biggest_char)
                    num_char = 0
            num_char += 1
            biggest_char = num_char
        biggest_chars.append(biggest_char)

        path_biggest_chars[path] = {'max': max(biggest_chars), 'path': biggest_chars}

    # print(path_biggest_chars)
    max_paths = get_max_paths(path_biggest_chars)
    print(max_paths)


def get_max_paths(path_biggest_chars):
    current_max = 0
    max_paths = {}

    for key in path_biggest_chars:
        if path_biggest_chars[key]["max"] >= current_max:
            current_max = path_biggest_chars[key]["max"]
            # max_paths[key] = ({'max': current_max, 'path': path_biggest_chars[key]["path"]})

    for key in path_biggest_chars:
        # print(path_biggest_chars[key])
        # print(current_max)
        if path_biggest_chars[key]["max"] >= current_max:
            max_paths[key] = ({'max': current_max, 'path': path_biggest_chars[key]["path"]})

    for key in max_paths:
        max_paths[key]['path'].remove(max_paths[key]['max'])
        if len(max_paths[key]['path']) > 0:
            max_paths[key]['max'] = max(max_paths[key]['path'])
    k = list(max_paths.keys())[0]
    while len(max_paths[k]['path']) > 0 and len(max_paths) > 1:
        max_paths = get_max_paths(max_paths)
        k = list(max_paths.keys())[0]
    return max_paths


@functools.cache
def calculate_cost():
    return ""


def generate_numpad():
    graph = Graph()
    start = None
    end = None

    graph.add_edge("7", "8", 1, ">")
    graph.add_edge("7", "4", 1, "v")

    graph.add_edge("8", "7", 1, "<")
    graph.add_edge("8", "5", 1, "v")
    graph.add_edge("8", "9", 1, ">")

    graph.add_edge("9", "8", 1, "<")
    graph.add_edge("9", "6", 1, "v")

    graph.add_edge("4", "5", 1, ">")
    graph.add_edge("4", "7", 1, "^")
    graph.add_edge("4", "1", 1, "v")

    graph.add_edge("5", "4", 1, "<")
    graph.add_edge("5", "8", 1, "^")
    graph.add_edge("5", "6", 1, ">")
    graph.add_edge("5", "2", 1, "v")

    graph.add_edge("6", "5", 1, "<")
    graph.add_edge("6", "9", 1, "^")
    graph.add_edge("6", "3", 1, "v")

    graph.add_edge("1", "2", 1, ">")
    graph.add_edge("1", "4", 1, "^")

    graph.add_edge("2", "1", 1, "<")
    graph.add_edge("2", "5", 1, "^")
    graph.add_edge("2", "3", 1, ">")
    graph.add_edge("2", "0", 1, "v")

    graph.add_edge("3", "2", 1, "<")
    graph.add_edge("3", "6", 1, "^")
    graph.add_edge("3", "A", 1, "v")

    graph.add_edge("0", "2", 1, "^")
    graph.add_edge("0", "A", 1, ">")

    graph.add_edge("A", "0", 1, "<")
    graph.add_edge("A", "3", 1, "^")

    return graph


def generate_directional():
    graph = Graph()
    return graph


def walk_backwards(prev, node, src, paths, curr_path, graph):
    if src == node:
        return
    old_path = paths[curr_path][:]
    for i in range(0, len(prev[node])):
        print((graph.vertices[prev[node][i]][node]["direction"]))
        if i > 0:
            paths.append(old_path)
            new_path = len(paths) - 1
            paths[new_path] = (graph.vertices[prev[node][i]][node]["direction"]) + paths[new_path]
            walk_backwards(prev, prev[node][i], src, paths, new_path, graph)

        else:
            paths[curr_path] = (graph.vertices[prev[node][i]][node]["direction"]) + paths[curr_path]
            walk_backwards(prev, prev[node][i], src, paths, curr_path, graph)


if __name__ == "__main__":
    def main():
        graph_numpad = generate_numpad()
        graph_directional = generate_directional()

        src = "A"
        dest = "7"

        calculate_path(src, dest, graph_numpad)

        start = time.time()

        end = time.time()
        print(f"Total elapsed time: {round(end - start, 2)} seconds.")


    main()
