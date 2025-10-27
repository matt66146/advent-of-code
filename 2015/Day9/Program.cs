List<string> routes = new();

routes = File.ReadLines("input").ToList();

Graph graph = new Graph();
var test = graph.Nodes.Find(n => n.Name == "test");

foreach (var route in routes)
{
    var parts = route.Split(' ');

    //Get or create start node
    Node? node = graph.Nodes.Find(n => n.Name == parts[0]);
    if (node == null)
    {
        node = CreateNode(parts[0]);
        graph.Nodes.Add(node);
    }

    //Get or create end node
    Node? endNode = graph.Nodes.Find(n => n.Name == parts[2]);
    if (endNode == null)
    {
        endNode = CreateNode(parts[2]);
        graph.Nodes.Add(endNode);
    }

    var edge = new Edge(endNode, Int32.Parse(parts[4]));
    node.Edges.Add(edge);

    edge = new Edge(node, Int32.Parse(parts[4]));
    endNode.Edges.Add(edge);

}


List<int> routeCosts = new();
int i = 0;

foreach (var node in graph.Nodes)
{
    List<Node> visitedNodes = new();
    FollowRoute(node, visitedNodes, 0);
}


void FollowRoute(Node node, List<Node> visitedNodes, int cost)
{
    i++;
    visitedNodes.Add(node);
    if (visitedNodes.Count == graph.Nodes.Count)
    {
        routeCosts.Add(cost);
    }

    foreach (var edge in node.Edges)
    {
        if (!visitedNodes.Contains(edge.EndNode))
        {
            FollowRoute(edge.EndNode, [.. visitedNodes], cost + edge.Cost);
        }

    }
}
routeCosts.Sort();

Console.WriteLine($"Part 1 - Lowest Cost: {routeCosts[0]}");
Console.WriteLine($"Part 1 - Highest Cost: {routeCosts[routeCosts.Count - 1]}");

Node CreateNode(string Name)
{
    var node = new Node(Name);
    return node;
}



class Graph()
{
    public List<Node> Nodes { get; set; } = new();
}


class Node(string name)
{
    public string Name { get; set; } = name;
    public List<Edge> Edges { get; set; } = new();
}

class Edge(Node endNode, int cost)
{
    public Node EndNode { get; set; } = endNode;
    public int Cost { get; set; } = cost;
}
