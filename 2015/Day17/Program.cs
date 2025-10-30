var input = File.ReadAllLines("input");

//Test input
//input = ["20", "15", "10", "5", "5"];
//*********

List<int> containers = new();

foreach (var line in input)
{
    containers.Add(Int32.Parse(line));
}

//Change dicts to tuples and use caching to speed up processing
//Use hashset of tuples to prevent duplicate combos

int max = 150;
List<Dictionary<int, int>> combos = new();


combos = FindCombos(new Dictionary<int, int>(), containers);

List<Dictionary<int, int>> FindCombos(Dictionary<int, int> combo, List<int> containers)
{
    List<Dictionary<int, int>> combos = new();
    if (combo.Values.Sum() == max)
    {
        combos.Add(combo);
    }
    else
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if ((combo.Values.Sum() + containers[i]) <= max)
            {
                Dictionary<int, int> currentCombo = new(combo);
                currentCombo[containers.IndexOf(containers[i])] = containers[i];
                List<int> containersLeft = new(containers);
                containersLeft.Remove(containers[i]);
                combos.AddRange(FindCombos(currentCombo, containersLeft));
            }
        }
    }
    return combos;
}

Console.WriteLine($"Num Combos: {combos.Count()}");

foreach (var c in combos)
{
    Console.WriteLine(string.Join(' ', c));
}




