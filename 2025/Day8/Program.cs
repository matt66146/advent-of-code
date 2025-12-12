var input = File.ReadAllLines("input.txt");
List<JunctionBox> junctionBoxes = new();

for (int i = 0; i < input.Length; i++)
{
    var data = input[i].Split(",");
    junctionBoxes.Add(new JunctionBox() { X = Int32.Parse(data[0]), Y = Int32.Parse(data[1]), Z = Int32.Parse(data[2]), Circuit = i });
}

//Console.WriteLine(string.Join("\n", junctionBoxes.Select(x => x.ToString())));

SortedSet<Distance> distances = new(Comparer<Distance>.Create((a, b) => a.Value.CompareTo(b.Value)));

for (int i = 0; i < junctionBoxes.Count - 1; i++)
{
    for (int j = i + 1; j < junctionBoxes.Count; j++)
    {
        distances.Add(new Distance() { A = junctionBoxes[i], B = junctionBoxes[j], Value = CalculateDistance(junctionBoxes[i], junctionBoxes[j]) });
    }
}

//Console.WriteLine(string.Join("\n", distances.Select(x => x.ToString())));

for (int i = 0; i < 1000; i++)
{
    Console.WriteLine($"B: {distances.ElementAt(i).B} - A: {distances.ElementAt(i).A}");
    var A = junctionBoxes[distances.ElementAt(i).A.Circuit].Circuit;
    var B = junctionBoxes[distances.ElementAt(i).B.Circuit].Circuit;


    foreach (var box in junctionBoxes)
    {
        if (box.Circuit == B) box.Circuit = A;
    }


}

var test = junctionBoxes.GroupBy(x => x.Circuit).Select(x => x.Select(y => y.Circuit).ToList()).ToList();
test = test.OrderByDescending(x => x.Count).ToList();
int answer = 1;
for (int i = 0; i < 3; i++)
{
    //Console.WriteLine(test[i].Count);
    answer *= test[i].Count;
}
//Console.WriteLine(string.Join("\n", test.Select(x => x.Count)));
//Console.WriteLine(string.Join("\n", junctionBoxes.OrderBy(x => x.Circuit).Select(x => x.ToString())));

Console.WriteLine($"Part 1: {answer}");
static double CalculateDistance(JunctionBox circuit1, JunctionBox circuit2)
{
    return Math.Sqrt(
        //(x2-x1)^2
        ((circuit2.X - circuit1.X) * (circuit2.X - circuit1.X))

        +
        //(y2-y1)^2
        ((circuit2.Y - circuit1.Y) * (circuit2.Y - circuit1.Y))

        +
        //(z2-z1)^2
        ((circuit2.Z - circuit1.Z) * (circuit2.Z - circuit1.Z))
    );
}

class JunctionBox
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int Circuit { get; set; }

    public override string ToString()
    {
        return $"X: {X}, Y: {Y}, Z: {Z}, Circuit: {Circuit}";
    }
}

class Distance
{
    public JunctionBox A { get; set; } = new();
    public JunctionBox B { get; set; } = new();
    public double Value { get; set; }

    public override string ToString()
    {
        return $"A: {A.Circuit}, B: {B.Circuit}, Distance: {Value}";
    }
}
