
using System.Text.Json;

var input = File.ReadAllLines("input");

//Test input
//input = ["20", "15", "10", "5", "5"];
//*********


List<(int Index, int Size)> containers = new();

for (int i = 0; i < input.Length; i++)
{
    containers.Add((i, Int32.Parse(input[i])));
}

foreach (var container in containers)
{
    //Console.WriteLine(container);
}

int max = 150;

List<List<(int Index, int Size)>> combos = FindCombos(new List<(int Index, int Size)>(), 0, containers);

List<List<(int Index, int Size)>> FindCombos(List<(int Index, int Size)> combo, int sum, List<(int Index, int Size)> containers)
{
    List<List<(int Index, int Size)>> combos = new();
    if (sum == max)
    {
        combo.Sort();
        combos.Add(combo);
    }
    else
    {
        foreach (var container in containers)
        {
            if (sum + container.Size <= max)
            {
                List<(int Index, int Size)> currentCombo = new(combo);
                currentCombo.Add(container);
                List<(int Index, int Size)> containersLeft = new(containers);
                containersLeft.Remove(container);
                int currentSum = sum + container.Size;

                foreach (var a in FindCombos(currentCombo, sum + container.Size, containersLeft))
                {

                    if (!combos.Any(list => list.SequenceEqual(a)))
                    {
                        combos.Add(a);
                    }
                }
            }
        }
    }



    return combos;
}


foreach (var combo in combos)
{
    Console.WriteLine(string.Join(", ", combo.Select(t => t)));
}

Console.WriteLine($"Part 1 - Number of combos: {combos.Count}");
