from termcolor import colored
import time
import heapq


class Graph:
    def __init__(self):
        self.vertices = {}

    def add_edge(self, v1, v2, cost):
        if v1 not in self.vertices:
            self.vertices[v1] = {}
        self.vertices[v1][v2] = {"cost": cost}

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


def load_computer_connections(graph, connections):
    for connection in connections:
        graph.add_edge(connection[0], connection[1], 1)
    print(graph.vertices)


if __name__ == "__main__":
    def main():
        start = time.time()
        connections = []
        graph = Graph()
        with open("test.txt") as input_file:
            for line in input_file:
                connections.append((line.strip().split("-")))

        load_computer_connections(graph, connections)

        end = time.time()
        print(f"Total elapsed time: {colored(round(end - start, 2), 'light_blue')} seconds")


    main()
