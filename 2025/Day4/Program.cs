using System.Text;

var input = File.ReadAllLines("input.txt");
int rowLength = input[0].Length;
int columnLength = input.Length;
//int[,] coords = new int[rowLength, columnLength];

Part1(input, rowLength, columnLength);
Part2(input, rowLength, columnLength);




static void Part1(string[] input, int rowLength, int columnLength)
{

    int answer = RemoveRolls(input, rowLength, columnLength);

    Console.WriteLine($"Part 1: {answer}");

}

static int RemoveRolls(string[] input, int rowLength, int columnLength)
{
    int numRollsRemoved = 0;

    for (int y = 0; y < rowLength; y++)
    {
        for (int x = 0; x < columnLength; x++)
        {
            if (input[y][x] == '@')
            {
                if (ForkLiftCanAccess(x, y, input))
                {
                    numRollsRemoved++;
                }
            }
        }
    }
    return numRollsRemoved;
}

static int RemoveRollsPart2(string[] input, int rowLength, int columnLength)
{
    int numRollsRemoved = 0;
    List<(int, int)> removedCoords = new();
    for (int y = 0; y < rowLength; y++)
    {
        for (int x = 0; x < columnLength; x++)
        {
            if (input[y][x] == '@')
            {
                if (ForkLiftCanAccess(x, y, input))
                {
                    numRollsRemoved++;
                    removedCoords.Add((x, y));
                }
            }
        }
    }
    foreach (var coord in removedCoords)
    {
        StringBuilder sb = new StringBuilder(input[coord.Item2]);
        sb[coord.Item1] = '.';
        input[coord.Item2] = sb.ToString();
    }
    if (numRollsRemoved > 0)
    {
        numRollsRemoved += RemoveRollsPart2(input, rowLength, columnLength);
    }
    return numRollsRemoved;
}

static void Part2(string[] input, int rowLength, int columnLength)
{
    int answer = RemoveRollsPart2(input, rowLength, columnLength);
    Console.WriteLine($"Part 2: {answer}");
}


static bool ForkLiftCanAccess(int x, int y, string[] input)
{
    int numRolls = 0;

    int x1;
    int y1;

    //Top Left
    x1 = x - 1;
    y1 = y - 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Top
    x1 = x;
    y1 = y - 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Top Right
    x1 = x + 1;
    y1 = y - 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Right
    x1 = x + 1;
    y1 = y;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Bottom Right
    x1 = x + 1;
    y1 = y + 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Bottom
    x1 = x;
    y1 = y + 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;

    //Bottom Left
    x1 = x - 1;
    y1 = y + 1;
    if (CheckForRoll(x1, y1, input)) numRolls++;
    //Left
    x1 = x - 1;
    y1 = y;
    if (CheckForRoll(x1, y1, input)) numRolls++;


    if (numRolls >= 4)
    {
        return false;
    }
    return true;
}

static bool CheckForRoll(int x, int y, string[] input)
{
    if (x >= 0 && y >= 0 && x < input[0].Length && y < input.Length)
    {
        if (input[y][x] == '@') return true;
    }
    return false;
}