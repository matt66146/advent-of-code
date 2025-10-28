var f = File.ReadAllLines("testInput");

HashSet<string> guests = new();

List<string> seats = new();


foreach (var line in f)
{
    guests.Add(line.Split(' ').First());
}

foreach (var guest in guests)
{
    Console.WriteLine(guest);
}


class Guest(Dictionary<string, int> happiness)
{
    Dictionary<string, int> Happiness = happiness;
}