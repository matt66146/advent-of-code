var f = File.ReadAllLines("input");
List<Reindeer> reindeers = new List<Reindeer>();

foreach (var line in f)
{
    var words = line.Split(' ');

    string name = words[0];
    int speed = Int32.Parse(words[3]);
    int duration = Int32.Parse(words[6]);
    int cooldown = Int32.Parse(words[13]);

    reindeers.Add(new Reindeer(name, speed, duration, cooldown));
}



Fly(reindeers);

reindeers = reindeers.OrderByDescending(r => r.DistanceTravelled).ToList();
Console.WriteLine($"Part 1: {reindeers[0].DistanceTravelled}");

reindeers = reindeers.OrderByDescending(r => r.Points).ToList();
Console.WriteLine($"Part 2: {reindeers[0].Points}");


void Fly(List<Reindeer> r)
{
    int totalTime = 2503;



    while (totalTime > 0)
    {
        foreach (var reindeer in r)
        {
            if (reindeer.OnCooldown)
            {
                reindeer.CurrentCooldown++;
                if (reindeer.CurrentCooldown == reindeer.Cooldown)
                {
                    reindeer.OnCooldown = false;
                    reindeer.CurrentCooldown = 0;
                }
            }
            else
            {
                reindeer.DistanceTravelled += reindeer.Speed;
                reindeer.CurrentDuration++;
                if (reindeer.CurrentDuration == reindeer.Duration)
                {
                    reindeer.OnCooldown = true;
                    reindeer.CurrentDuration = 0;
                }
            }
        }
        r = r.OrderByDescending(r => r.DistanceTravelled).ToList();
        r[0].Points++;
        if (r[0].DistanceTravelled == r[1].DistanceTravelled)
        {
            for (int i = 1; i < r.Count; i++)
            {
                if (r[0].DistanceTravelled == r[i].DistanceTravelled)
                {
                    r[i].Points++;
                }
            }
        }
        totalTime--;
    }
}
class Reindeer(string name, int speed, int duration, int cooldown)
{
    public string Name { get; set; } = name;
    public int Speed { get; set; } = speed;
    public int Duration { get; set; } = duration;
    public int Cooldown { get; set; } = cooldown;
    public int DistanceTravelled { get; set; } = 0;
    public int Points { get; set; } = 0;
    public int CurrentDuration { get; set; } = 0;
    public int CurrentCooldown { get; set; } = 0;
    public bool OnCooldown { get; set; } = false;
}

