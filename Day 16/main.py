import heapq


class Graph:
    def __init__(self):
        self.vertices = {}

    def add_edge(self, v1, v2 , cost):
        if v1 not in self.vertices:
            self.vertices[v1] = {}
        self.vertices[v1][v2] = cost
        #print(len(self.vertices.keys()))

    def shortest_path(self, src, dest):
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





def main():
    '''
    graph = Graph()
    graph.add_edge("A1","A2",1000)
    graph.add_edge("A1", "A4", 1000)

    graph = Graph()
    graph.vertices = {
        "A1": {"A2": 1000, "A4": 1000, "D1": 1},
        "A2": {"A1": 1000, "A3": 1000},
        "A3": {"A2": 1000, "A4": 1000, "B3": 1},
        "A4": {"A1": 1000, "A3": 1000},

        "B1": {"B2": 1000, "B4": 1000, "A1": 1},
        "B2": {"B1": 1000, "B3": 1000, "C2": 1},
        "B3": {"B2": 1000, "B4": 1000},
        "B4": {"B1": 1000, "B3": 1000},

        "C1": {"C2": 1000, "C4": 1000},
        "C2": {"C1": 1000, "C3": 1000},
        "C3": {"C2": 1000, "C4": 1000},
        "C4": {"C1": 1000, "C3": 1000, "B4": 1},

        "D1": {"D2": 1000, "D4": 1000},
        "D2": {"D1": 1000, "D3": 1000, "C2": 1},
        "D3": {"D2": 1000, "D4": 1000, "A3": 1},
        "D4": {"D1": 1000, "D3": 1000},
    }
    '''
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

    print(width)
    print(height)
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










    print(graph.shortest_path(start,end))


if __name__ == '__main__':
    main()
