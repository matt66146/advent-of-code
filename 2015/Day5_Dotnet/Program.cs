List<char> vowels = ['a', 'e', 'i', 'o', 'u'];
List<string> badDuplicates = ["ab", "cd", "pq", "xy"];

var f = File.ReadLines("input");

int niceStrings = 0;
int niceStrings2 = 0;

foreach (var line in f)
{
    if (CheckVowels(line))
    {
        if (CheckBadDuplicates(line))
        {
            if (CheckDuplicates(line))
            {
                niceStrings++;
            }
        }
    }

    //part 2
    if (CheckDuplicatePairs(line))
    {
        if (CheckRepeat(line))
        {
            niceStrings2++;
        }
    }
}

Console.WriteLine($"Part 1: {niceStrings}");
Console.WriteLine($"Part 2: {niceStrings2}");



bool CheckDuplicatePairs(string line)
{


    for (int i = 0; i < line.Count() - 3; i++)
    {
        if (line.Substring(i + 2, line.Count() - (i + 2)).Contains(line.Substring(i, 2)))
        {
            return true;
        }

    }

    return false;
}

bool CheckRepeat(string line)
{
    string prev = "";
    for (int i = 0; i < line.Count() - 2; i++)
    {
        if (line[i] == line[i + 2])
        {
            return true;
        }

    }
    return false;
}




bool CheckVowels(string line)
{
    //better version?
    return line.Count(c => vowels.Contains(c)) >= 3;
}

bool CheckDuplicates(string line)
{
    for (int i = 0; i < line.Count() - 1; i++)
    {
        if (line[i] == line[i + 1])
        {
            return true;
        }
    }

    return false;
}

bool CheckBadDuplicates(string line)
{
    for (int i = 0; i < line.Count() - 1; i++)
    {
        if (badDuplicates.Contains($"{line[i]}{line[i + 1]}"))
        {
            return false;
        }
    }

    return true;
}
