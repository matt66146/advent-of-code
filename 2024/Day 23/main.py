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

        if v2 not in self.vertices:
            self.vertices[v2] = {}
        self.vertices[v2][v1] = {"cost": cost}

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

    def find_groups(self):
        groups = []

        for key in self.vertices:
            for edge in self.vertices[key]:
                for e in self.vertices[edge]:
                    if key in self.vertices[e]:
                        if key[0] == 't' or edge[0] == 't' or e[0] == 't':
                            t = [key, edge, e]
                            t.sort()
                            groups.append(tuple(t))

        return list(set(groups))

    def find_cliques(self):
        cliques = []
        visited = set()
        for node in self.vertices:
            if len(self.vertices[node].keys()) > 1:
                print(node)

        return cliques

    def bors_kerbosch(self, set1, vertices_set, set2, vertices, C):

        if len(vertices_set) == 0 and len(set2) == 0:
            if len(set1) >= 2:
                C.append(sorted(set1))
            return

        for v in vertices_set.copy():
            self.bors_kerbosch(set1.union(set([v])), vertices_set.intersection(vertices[v]),
                               set2.intersection(vertices[v]), vertices, C)
            vertices_set.remove(v)
            set2.add(v)

    def max_clique(self):
        cliques = []
        self.bors_kerbosch(set([]), set(self.vertices.keys()), set([]), self.vertices, cliques)
        max_length = 0
        max_clique = []
        print(cliques)
        for clique in cliques:
            if len(clique) > max_length:
                max_length = len(clique)
                max_clique = clique

        return max_clique


def load_computer_connections(graph, connections):
    for connection in connections:
        graph.add_edge(connection[0], connection[1], 1)


if __name__ == "__main__":
    def main():
        start = time.time()
        connections = []
        graph = Graph()
        with open("input.txt") as input_file:
            for line in input_file:
                connections.append((line.strip().split("-")))

        load_computer_connections(graph, connections)

        # part 1
        groups = graph.find_groups()
        groups.sort()
        print(f"Part 1: {len(groups)}")

        # part 2
        max_clique = graph.max_clique()
        max_clique.sort()
        print(max_clique)

        end = time.time()
        print(f"Total elapsed time: {colored(round(end - start, 2), 'light_blue')} seconds")


    main()
