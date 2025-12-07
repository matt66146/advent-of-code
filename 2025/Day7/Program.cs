using System.ComponentModel;

var input = File.ReadAllLines("input.txt");

Dictionary<(int x, int y), char> grid = new();

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        grid.Add((x, y), input[y][x]);
    }
}

var beam = grid.First(g => g.Value == 'S').Key;

Part1(grid, beam, input.Length, input[0].Length);
Part2(grid, beam, input.Length, input[0].Length);

static void Part1(Dictionary<(int x, int y), char> grid, (int x, int y) beam, int height, int width)
{
    FollowPath(grid, (beam.x, beam.y + 1), height, width);
    Console.WriteLine($"Part 1: {Splitter.splittersHit.Count}");

}

static void Part2(Dictionary<(int x, int y), char> grid, (int x, int y) beam, int height, int width)
{
    ulong answer = FollowPathPart2(grid, (beam.x, beam.y + 1), height, width);
    Console.WriteLine($"Part 2: {answer}");

}

static void FollowPath(Dictionary<(int x, int y), char> grid, (int x, int y) beam, int height, int width)
{

    if (beam.y >= height - 1) return;


    if (grid[beam] == '^')
    {
        if (!Splitter.splittersHit.Contains((beam)))
        {
            Splitter.splittersHit.Add(beam);

            FollowPath(grid, (beam.x - 1, beam.y), height, width);
            FollowPath(grid, (beam.x + 1, beam.y), height, width);
        }
    }
    else
    {
        grid[beam] = '|';
        FollowPath(grid, (beam.x, beam.y + 1), height, width);
    }
}

static ulong FollowPathPart2(Dictionary<(int x, int y), char> grid, (int x, int y) beam, int height, int width)
{

    ulong answer = 0;
    if (beam.y >= height - 1) return 1;

    if (Cache.cache.Keys.Contains(beam)) return Cache.cache[beam];

    if (grid[beam] == '^')
    {
        answer += FollowPathPart2(grid, (beam.x - 1, beam.y), height, width);
        answer += FollowPathPart2(grid, (beam.x + 1, beam.y), height, width);
    }
    else
    {
        grid[beam] = '|';
        answer += FollowPathPart2(grid, (beam.x, beam.y + 1), height, width);
    }
    Cache.cache[beam] = answer;

    return answer;
}

public class Splitter
{
    public static HashSet<(int x, int y)> splittersHit = new();
}
public class Cache
{
    public static Dictionary<(int x, int y), ulong> cache = new();
}