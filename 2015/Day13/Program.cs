var f = File.ReadAllLines("input");

Dictionary<string, Dictionary<string, int>> guests = new();


List<string> guestNames = new();

foreach (var line in f)
{
    var parts = (line.Split(' '));
    string guestName = parts[0];
    string guestNameToCompare = parts[parts.Length - 1].Split(".")[0];
    int happiness = 0;

    happiness = Int32.Parse(parts.Where(p => Int32.TryParse(p, out happiness)).First());
    if (parts.Contains("lose"))
    {
        happiness = happiness * -1;
    }
    //Console.WriteLine($"{guestName} {happiness} {guestNameToCompare}");
    if (!guests.ContainsKey(guestName)) guests[guestName] = new Dictionary<string, int>();
    guests[guestName][guestNameToCompare] = happiness;

    if (!guestNames.Contains(guestName)) guestNames.Add(guestName);
}

//Console.WriteLine(JsonSerializer.Serialize(guests));



//Part 1
var test = guestNames.Permute();

List<int> happinessList = new();
foreach (var order in test)
{
    int totalHappiness = CalculateHappiness(order.ToList(), guests);
    happinessList.Add(totalHappiness);
    //Console.WriteLine(totalHappiness);
}
happinessList = happinessList.OrderByDescending(i => i).ToList();

Console.WriteLine($"Part 1 - Total Happiness: {happinessList[0]}");

//part 2
guests["Matt"] = new();
guestNames.Add("Matt");
foreach (var guest in guestNames)
{
    guests["Matt"][guest] = 0;
}
foreach (var guest in guestNames)
{
    guests[guest]["Matt"] = 0;
}

test = guestNames.Permute();
happinessList = new();
foreach (var order in test)
{
    //Console.WriteLine(JsonSerializer.Serialize(order));
    int totalHappiness = CalculateHappiness(order.ToList(), guests);
    happinessList.Add(totalHappiness);
    //Console.WriteLine(totalHappiness);
}
happinessList = happinessList.OrderByDescending(i => i).ToList();

Console.WriteLine($"Part 1 - Total Happiness: {happinessList[0]}");






int CalculateHappiness(List<string> guestNames, Dictionary<string, Dictionary<string, int>> guests)
{
    int happiness = 0;

    for (int i = 0; i < guestNames.Count; i++)
    {
        int left = i - 1;
        if (left < 0) left = guestNames.Count - 1;
        int right = i + 1;
        if (right > guestNames.Count - 1) right = 0;

        string guest = guestNames[i];
        string leftGuest = guestNames[left];
        string rightGuest = guestNames[right];

        happiness += guests[guest][leftGuest];
        happiness += guests[guest][rightGuest];

    }

    return happiness;
}

public static class Test
{
    public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
        {
            yield break;
        }

        var list = sequence.ToList();

        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;

            foreach (var startingElement in list)
            {
                var index = startingElementIndex;
                var remainingItems = list.Where((e, i) => i != index);

                foreach (var permutationOfRemainder in remainingItems.Permute())
                {
                    yield return permutationOfRemainder.Prepend(startingElement);
                }

                startingElementIndex++;
            }
        }
    }
}