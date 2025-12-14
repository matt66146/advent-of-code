var input = File.ReadAllLines("testInput.txt");

Part1(input);
Part2(input);

static void Part2(string[] input)
{
    List<(long x, long y)> redTiles = new();
    List<(long x, long y)> greenTiles = new();

    GenerateRedTiles(input, redTiles);

    GenerateGreenTiles(redTiles, greenTiles);


    foreach (var tile in redTiles)
    {
        Console.WriteLine($"{tile.x},{tile.y}");
    }
    Console.WriteLine("-Green Tiles-");
    foreach (var tile in greenTiles)
    {
        Console.WriteLine($"{tile.x},{tile.y}");
    }
    Console.WriteLine(greenTiles.Count);
}
static void GenerateRedTiles(string[] input, List<(long x, long y)> redTiles)
{
    for (int i = 0; i < input.Length; i++)
    {
        var partsA = input[i].Split(",");
        (long x, long y) a = (Int64.Parse(partsA[0]), Int64.Parse(partsA[1]));
        redTiles.Add((a.x, a.y));
    }
}
static void GenerateGreenTiles(List<(long x, long y)> redTiles, List<(long x, long y)> greenTiles)
{
    for (int i = 0; i < redTiles.Count; i++)
    {
        long x1 = 0;
        long y1 = 0;
        long x2 = 0;
        long y2 = 0;

        if (i + 1 == redTiles.Count)
        {
            x1 = redTiles[i].x;
            y1 = redTiles[i].y;
            x2 = redTiles[0].x;
            y2 = redTiles[0].y;
        }
        else
        {
            x1 = redTiles[i].x;
            y1 = redTiles[i].y;
            x2 = redTiles[i + 1].x;
            y2 = redTiles[i + 1].y;
        }
        if (x1 == x2)
        {
            long start = Math.Min(y1, y2);
            long end = Math.Max(y1, y2);
            for (long j = start + 1; j < end; j++)
            {
                greenTiles.Add((x1, j));
            }
        }
        else
        {
            long start = Math.Min(x1, x2);
            long end = Math.Max(x1, x2);
            for (long j = start + 1; j < end; j++)
            {
                greenTiles.Add((j, y1));
            }
        }
    }
}


static void Part1(string[] input)
{
    long answer = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 1; j < input.Length; j++)
        {
            var partsA = input[i].Split(",");
            var partsB = input[j].Split(",");
            (long x, long y) a = (Int64.Parse(partsA[0]), Int64.Parse(partsA[1]));
            (long x, long y) b = (Int64.Parse(partsB[0]), Int64.Parse(partsB[1]));

            long area = (Math.Abs(a.x - b.x) + 1) * (Math.Abs(a.y - b.y) + 1);
            if (area > answer) answer = area;
        }
    }

    Console.WriteLine($"Part 1 {answer}");
}