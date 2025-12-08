var input = File.ReadAllLines("testInput.txt");
Dictionary<int, List<JunctionBox>> circuits = new();
SortedList<int, int> circuitSizes = new();

for (int i = 0; i < input.Length; i++)
{
    var data = input[i].Split(",");
    circuits.Add(i, new());
    circuits[i].Add(new JunctionBox() { X = Int32.Parse(data[0]), Y = Int32.Parse(data[1]), Z = Int32.Parse(data[2]), Circuit = i });
    circuitSizes.Add(i, 1);
}


PrintCircuits(circuits);

for (int n = 0; n < 10; n++)
{


    double smallestDistance = ulong.MaxValue;
    JunctionBox? s1 = null;
    JunctionBox? s2 = null;


    for (int i = 0; i < circuits.Count; i++)
    {
        for (int j = i + 1; j < circuits.Count; j++)
        {
            for (int k = 0; k < circuits[i].Count; k++)
            {
                for (int l = 0; l < circuits[j].Count; l++)
                {
                    var distance = CalculateDistance(circuits[i][k], circuits[j][l]);
                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        s1 = circuits[i][k];
                        s2 = circuits[j][l];
                    }
                }
            }


        }
    }
    Console.WriteLine(smallestDistance);
    Console.WriteLine(s1?.Circuit);
    Console.WriteLine(s2?.Circuit);

    if (s1 is null) throw new Exception("s1 error!");
    if (s2 is null) throw new Exception("s2 error!");
    Console.WriteLine(circuits[s2.Circuit].Count);

    for (int i = 0; i < circuits[s2.Circuit].Count; i++)
    {
        PrintCircuits(circuits);

        circuits[s1.Circuit].Add(circuits[s2.Circuit][i]);

    }
    circuits.Remove(s2.Circuit);

    for (int i = 0; i < circuits[s1.Circuit].Count; i++)
    {
        circuits[s1.Circuit][i].Circuit = s1.Circuit;
    }


    PrintCircuits(circuits);

}
void PrintCircuits(Dictionary<int, List<JunctionBox>> circuits)
{
    Console.WriteLine("WTF");
    foreach (var circuit in circuits)
    {
        foreach (var box in circuit.Value)
        {
            Console.WriteLine($"x={box.X}, y={box.Y}, z={box.Z}, circuit={box.Circuit}");
        }
    }

}

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
}
