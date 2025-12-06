var input = File.ReadAllLines("input.txt");

List<(ulong Start, ulong End)> ranges = new();

List<ulong> ingredients = new();


GenerateData(input, ranges, ingredients);

Part1(ranges, ingredients);
Part2(input, ranges);


static void Part1(List<(ulong Start, ulong End)> ranges, List<ulong> ingredients)
{
    ulong answer = 0;
    foreach (ulong ingredient in ingredients)
    {
        foreach (var range in ranges)
        {
            if (CheckRange(range.Start, range.End, ingredient))
            {
                answer++;
                break;
            }
        }

    }

    Console.WriteLine($"Part 1: {answer}");

}
static void Part2(string[] input, List<(ulong Start, ulong End)> ranges)
{
    GenerateDataPart2(input, ranges);
    ulong answer = 0;

    foreach (var range in ranges)
    {
        ulong result = CheckFresh(range.Start, range.End);
        if (result < 0)
        {
            Console.WriteLine(result);
        }
        answer += result;
    }



    Console.WriteLine($"Part 2: {answer}");

}

static bool CheckRange(ulong start, ulong end, ulong num)
{
    if (num >= start && num <= end)
    {
        return true;
    }

    return false;
}

static ulong CheckFresh(ulong start, ulong end)
{
    ulong answer = end - start + 1;
    //Console.WriteLine(answer);
    return answer;
}

static void GenerateData(string[] input, List<(ulong Start, ulong End)> ranges, List<ulong> ingredients)
{
    bool updateRanges = true;
    foreach (string line in input)
    {
        if (line == string.Empty)
        {
            updateRanges = false;
            continue;
        }
        if (updateRanges)
        {
            var split = line.Split("-");
            ranges.Add((UInt64.Parse(split[0]), UInt64.Parse(split[1])));
        }
        else
        {
            ingredients.Add(UInt64.Parse(line));
        }
    }
}

static void GenerateDataPart2(string[] input, List<(ulong Start, ulong End)> ranges)
{
    bool foundChange = false;
    for (int i = 0; i < ranges.Count; i++)
    {
        for (int j = i + 1; j < ranges.Count; j++)
        {
            if (ranges[j].End >= ranges[i].Start && ranges[j].End <= ranges[i].End)
            {
                ulong start = ranges[j].Start;
                ulong end = ranges[i].Start - 1;

                if (end < start)
                {
                    ranges.Remove(ranges[j]);
                }
                else
                {
                    ranges[j] = (start, end);
                }
                foundChange = true;
            }
            else if (ranges[i].End >= ranges[j].Start && ranges[i].End <= ranges[j].End)
            {
                ulong start = ranges[i].Start;
                ulong end = ranges[j].Start - 1;

                if (end < start)
                {
                    ranges.Remove(ranges[i]);
                }
                else
                {
                    ranges[i] = (start, end);
                }
                foundChange = true;
            }
        }
    }
    if (foundChange) GenerateDataPart2(input, ranges);
}



