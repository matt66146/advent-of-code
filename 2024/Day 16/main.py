import heapq


class Graph:
    def __init__(self):
        self.vertices = {}

    def add_edge(self, v1, v2 , cost):
        if v1 not in self.vertices:
            self.vertices[v1] = {}
        self.vertices[v1][v2] = cost
        #print(len(self.vertices.keys()))

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
            if current_v[:-1] == dest:
                return current_cost
                #print(current_cost)

            for v in self.vertices[current_v]:
                cost = self.vertices[current_v][v] + current_cost
                if cost < dist[v]:
                    #print(v)
                    prev[v] = [current_v]
                    dist[v] = cost
                    heapq.heappush(pq, (dist[v], v))
                elif cost == dist[v]:
                    prev[v].append(current_v)
        #print(prev)

    def shortest_path_part_2(self, src, dest):
        size = len(self.vertices.keys())
        pq = [(0, src)]
        dist = {}
        prev = {}
        for key in self.vertices:
            dist[key] = float('inf')
        for key in self.vertices:
            prev[key] = []
        dist[src] = 0
        potential_shortest_paths = []

        while pq:
            current_cost, current_v = heapq.heappop(pq)
            if current_v[:-1] == dest:
                print(f"V: {current_v} Cost: {current_cost}")
                potential_shortest_paths.append((current_v,current_cost))


            for v in self.vertices[current_v]:
                cost = self.vertices[current_v][v] + current_cost
                if cost < dist[v]:
                    #print(v)
                    prev[v] = [current_v]
                    dist[v] = cost
                    heapq.heappush(pq, (dist[v], v))
                elif cost == dist[v]:
                    prev[v].append(current_v)
        #print(prev)

        potential_shortest_paths.sort(key=lambda x: x[1])
        lowest_cost = potential_shortest_paths[0][1]
        nodes_walked = []
        for path in potential_shortest_paths:
            if path[1] == lowest_cost:
                nodes_walked += walk_backwards(prev, path[0], src)
            else:
                break
        nodes_walked = set(nodes_walked)
        print(nodes_walked)
        print(len(nodes_walked))


def walk_backwards(prev, node, src):
    nodes_walked = [node[:-1]]
    if src[:-1] == node[:-1]:
        return nodes_walked
    for n in prev[node]:
        nodes_walked += walk_backwards(prev, n, src)

    return nodes_walked


def main():
    graph = Graph()
    start = None
    end = None
    with open("input.txt") as input_file:
        data = []
        for line in input_file:
            width = len(line)
            for point in line.strip():
                data.append(point)
        height = len(data) // width


    for h in range(0,height):
        for w in range(0,width):
            index = (h*width) + w
            if data[index] != "#":

                #left
                if data[index - 1] != "#":
                    graph.add_edge(f"({w},{h})1",f"({w-1},{h})1",1)
                #up
                if data[index - width] != "#":
                    graph.add_edge(f"({w},{h})2",f"({w},{h-1})2",1)
                #right
                if data[index + 1] != "#":
                    graph.add_edge(f"({w},{h})3",f"({w+1},{h})3",1)
                #down
                if data[index + width] != "#":
                    graph.add_edge(f"({w},{h})4",f"({w},{h+1})4",1)

                #1
                graph.add_edge(f"({w},{h})1", f"({w},{h})2", 1000)
                graph.add_edge(f"({w},{h})1", f"({w},{h})4", 1000)

                #2
                graph.add_edge(f"({w},{h})2", f"({w},{h})1", 1000)
                graph.add_edge(f"({w},{h})2", f"({w},{h})3", 1000)

                #3
                graph.add_edge(f"({w},{h})3", f"({w},{h})2", 1000)
                graph.add_edge(f"({w},{h})3", f"({w},{h})4", 1000)

                #4
                graph.add_edge(f"({w},{h})4", f"({w},{h})1", 1000)
                graph.add_edge(f"({w},{h})4", f"({w},{h})3", 1000)

            if data[index] == "S":
                start = f"({w},{h})3"
            if data[index] == "E":
                end = f"({w},{h})"










    #print(graph.shortest_path_part_1(start,end))
    print(graph.shortest_path_part_2(start,end))

if __name__ == '__main__':
    main()
