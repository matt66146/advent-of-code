var input = File.ReadAllLines("input");

//Test input
//input = ["20", "15", "10", "5", "5"];
//*********

List<int> containers = new();

foreach (var line in input)
{
    containers.Add(Int32.Parse(line));
}

int max = 150;
List<Dictionary<int, int>> combos = new();


FindCombos(new Dictionary<int, int>(), containers);

void FindCombos(Dictionary<int, int> combo, List<int> containers)
{
    Console.WriteLine("test");
    if (combo.Values.Sum() == max)
    {
        combos.Add(combo);
    }
    else
    {
        foreach (var container in containers)
        {
            if ((combo.Values.Sum() + container) <= max)
            {
                Dictionary<int, int> currentCombo = new(combo);
                currentCombo[container] = container;
                List<int> containersLeft = new(containers);
                containersLeft.Remove(container);
                FindCombos(currentCombo, containersLeft);
            }
        }
    }
}

Console.WriteLine($"Num Combos: {combos.Count()}");

foreach (var c in combos)
{
    Console.WriteLine(string.Join(' ', c));
}




