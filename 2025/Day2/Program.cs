Part1();
Part2();







static void Part1()
{
    //var ranges = File.ReadAllText("testInput.txt").Split(",");
    var ranges = File.ReadAllText("input.txt").Split(",");

    ulong answer = 0;

    //ranges = ["998-1012"];

    foreach (var range in ranges)
    {
        var rangeParts = range.Split("-");
        ulong first = UInt64.Parse(rangeParts[0]);
        ulong last = UInt64.Parse(rangeParts[1]);

        for (ulong i = first; i <= last; i++)
        {
            string id = i.ToString();
            string current = "";
            for (int j = id.Length / 2; j >= 0; j--)
            {
                if (id.Substring(0, j + 1).Equals(id.Substring(j + 1)))
                {
                    answer += UInt64.Parse(id);
                    break;
                }

            }


        }

    }

    Console.WriteLine($"Part1: {answer}");
}
static void Part2()
{
    //var ranges = File.ReadAllText("testInput.txt").Split(",");
    var ranges = File.ReadAllText("input.txt").Split(",");

    ulong answer = 0;

    //ranges = ["95-115"];

    foreach (var range in ranges)
    {
        var rangeParts = range.Split("-");
        ulong first = UInt64.Parse(rangeParts[0]);
        ulong last = UInt64.Parse(rangeParts[1]);

        for (ulong i = first; i <= last; i++)
        {
            string id = i.ToString();
            string current = "";
            for (int j = 0; j < id.Length - 1; j++)
            {
                current += id[j];

                //Have to figure out splitting subtring into value of current -- then verify each substring is equal to current
                var toCheck = id.Split(current, StringSplitOptions.RemoveEmptyEntries);
                bool bad = false;
                foreach (string sub in toCheck)
                {
                    if (!sub.Equals(current)) bad = true;
                }
                if (!bad)
                {
                    answer += UInt64.Parse(id.ToString());
                    break;
                }
            }


        }

    }

    Console.WriteLine($"Part2: {answer}");
}