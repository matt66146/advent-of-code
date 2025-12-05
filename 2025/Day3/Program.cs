var input = File.ReadAllLines("input.txt");

Part1(input);
Part2(input);


static void Part1(string[] input)
{
    int answer = 0;
    foreach (var line in input)
    {
        int biggest = 0;
        int secondBig = 0;

        for (int i = 0; i < line.Length; i++)
        {
            int num = (int)Char.GetNumericValue(line[i]);
            if (num > biggest && i < line.Length - 1)
            {
                biggest = num;
                secondBig = 0;
            }
            else if (num > secondBig)
            {
                secondBig = num;
            }
        }
        //Console.WriteLine($"{biggest}{secondBig}");
        answer += biggest * 10 + secondBig;
    }
    Console.WriteLine($"Part 1: {answer}");
}
static void Part2(string[] input)
{
    ulong answer = 0;
    foreach (var line in input)
    {
        string newLine = "";
        int checkStart = 0;
        while (newLine.Length < 12)
        {
            int start = 0;
            int largestStart = 0;

            for (int i = checkStart; i < line.Length; i++)
            {
                int num = (int)Char.GetNumericValue(line[i]);
                if (num > largestStart && line.Substring(i).Length >= 12 - newLine.Length)
                {
                    largestStart = num;
                    start = i;
                }

            }

            newLine += line[start];

            checkStart = start + 1;
        }
        //Console.WriteLine($"{newLine}");
        answer += UInt64.Parse(newLine);
    }
    Console.WriteLine($"Part 2: {answer}");
}