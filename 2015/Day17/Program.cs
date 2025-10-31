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
int loops = 0;
Dictionary<string, List<List<(int Index, int Size)>>> cache = new();

List<List<(int Index, int Size)>> combos = FindCombos(new List<(int Index, int Size)>(), 0, containers);

List<List<(int Index, int Size)>> FindCombos(List<(int Index, int Size)> combo, int sum, List<(int Index, int Size)> containers)
{
    combo.Sort();
    string value = GenerateKey(combo, sum, containers);

    List<List<(int Index, int Size)>>? cacheCombos;

    if (!cache.TryGetValue(value, out cacheCombos))
    {
        loops++;
        List<List<(int Index, int Size)>> combos = new();
        if (sum == max)
        {

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

                    foreach (var a in FindCombos(currentCombo, currentSum, containersLeft))
                    {
                        bool found = false;
                        foreach (var b in combos)
                        {
                            if (b.SequenceEqual(a))
                            {
                                found = true;
                            }
                        }
                        if (!found) combos.Add(a);

                        /*
                        if (!combos.Any(list => list.SequenceEqual(a)))
                        {
                            combos.Add(a);
                        }
                        */
                    }
                }
            }
        }
        cache[value] = combos;
        return combos;
    }
    else
    {
        return cacheCombos;
    }
}



string GenerateKey(List<(int Index, int Size)> combo, int sum, List<(int Index, int Size)> containers)
{
    string comboString = string.Join(",", combo.Select(c => c));
    string sumString = sum.ToString();
    string containersString = string.Join(",", containers.Select(c => c));

    string cache = string.Join(",", "a" + comboString, "b" + sumString, "c" + containersString);
    //Console.WriteLine(cache);
    return cache;
}

Console.WriteLine(loops);
Console.WriteLine($"Part 1 - Number of combos: {combos.Count}");


int min = combos[1].Count;
int numMin = 1;

for (int i = 1; i < combos.Count; i++)
{
    if (combos[i].Count == min)
    {
        numMin++;
    }
    else if (combos[i].Count < min)
    {
        numMin = 1;
        min = combos[i].Count;
    }
}

Console.WriteLine($"Part 2 - Number of min size combos: {numMin}");
