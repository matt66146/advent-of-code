var input = File.ReadAllLines("input.txt");

//Part1(input);
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
        if (line == "2112212224221323212122212232121422221211292212942125222122223422322222422223522212222211332222222272")
        {
            int a = 0;
        }
        ulong biggest = 0;


        int start = 0;
        int largestStart = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line.Substring(i).Length < 12)
            {
                break;
            }
            int num = (int)Char.GetNumericValue(line[i]);
            if (num > largestStart)
            {
                largestStart = num;
                start = i;
            }

        }
        string newLine = "";
        for (int i = start; i < line.Length; i++)
        {
            newLine += line[i];
        }
        while (newLine.Length > 12)
        {
            int smallest = int.MaxValue;
            int index = -1;

            for (int i = 1; i < newLine.Length; i++)
            {

                int num = (int)Char.GetNumericValue(newLine[i]);
                if (num < smallest)
                {
                    index = i;
                    smallest = num;
                }

            }

            //Console.WriteLine(newLine.Length);
            if (index != -1)
            {
                newLine = newLine.Remove(index, 1);
            }

        }
        Console.WriteLine($"{newLine}");
        answer += UInt64.Parse(newLine);
    }
    Console.WriteLine($"Part 2: {answer}");
}