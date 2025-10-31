var f = File.ReadAllLines("input");

List<List<char>> input = new List<List<char>>();
Console.CursorVisible = false;

foreach (var line in f)
{
    List<char> lineArray = new();
    for (int i = 0; i < line.Length; i++)
    {
        lineArray.Add(line[i]);
    }
    input.Add(lineArray);
}

int numSteps = 100;
//Console.Clear();
//DrawSimulation(input);
//Thread.Sleep(1000);
//Console.WriteLine(GetLightsOn(input));
//Console.ReadKey();




List<List<char>> inputP2 = new();

foreach (var line in input)
{
    List<char> lineArray = new();
    for (int i = 0; i < line.Count; i++)
    {
        lineArray.Add(line[i]);
    }
    inputP2.Add(lineArray);
}


for (int i = 0; i < inputP2.Count; i++)
{
    for (int j = 0; j < inputP2[i].Count; j++)
    {
        if (i == 0 && j == 0)
        {
            inputP2[i][j] = '#';
        }

        if (i == 0 && j == inputP2[i].Count - 1)
        {
            inputP2[i][j] = '#';
        }

        if (i == inputP2.Count - 1 && j == 0)
        {
            inputP2[i][j] = '#';
        }

        if (i == inputP2.Count - 1 && j == inputP2[i].Count - 1)
        {
            inputP2[i][j] = '#';
        }
    }
}

for (int i = 0; i < numSteps; i++)
{
    input = RunSimulation(input, false);
    Console.Clear();
    //Console.WriteLine("\x1b[3J");
    DrawSimulation(input);
    Thread.Sleep(millisecondsTimeout: 16);
    //Console.ReadKey();
}
Console.Clear();
Console.WriteLine("Part 2 in 5 seconds...");
Thread.Sleep(millisecondsTimeout: 5000);
for (int i = 0; i < numSteps; i++)
{
    inputP2 = RunSimulation(inputP2, true);
    Console.Clear();
    //Console.WriteLine("\x1b[3J");
    DrawSimulation(inputP2);
    Thread.Sleep(millisecondsTimeout: 16);
    //Console.ReadKey();
}
Console.CursorVisible = true;
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;

Console.WriteLine($"Part 1 - Light On: {GetLightsOn(input)}");
Console.WriteLine($"Part 2 - Light On: {GetLightsOn(inputP2)}");


int GetLightsOn(List<List<char>> input)
{
    int lightsOn = 0;
    foreach (var line in input)
    {
        foreach (var c in line)
        {
            if (c == '#') lightsOn++;
        }
    }
    return lightsOn;
}


void DrawSimulation(List<List<char>> input)
{
    for (int i = 0; i < input.Count; i += 2)
    {
        for (int j = 0; j < input[i].Count; j++)
        {
            if (input[i][j] == '#')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            if (input[i + 1][j] == '#')
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.Write("▀");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write("\n");
    }
}
List<List<char>> RunSimulation(List<List<char>> input, bool faultyLights)
{
    List<List<char>> newInput = new();

    foreach (var line in input)
    {
        List<char> lineArray = new();
        for (int i = 0; i < line.Count; i++)
        {
            lineArray.Add(line[i]);
        }
        newInput.Add(lineArray);
    }

    for (int i = 0; i < input.Count; i++)
    {
        for (int j = 0; j < input[i].Count; j++)
        {
            int numNeighbors = 0;

            //left
            if (j > 0)
            {
                if (input[i][j - 1] == '#')
                {
                    numNeighbors++;
                }
            }

            //right
            if (j < input[i].Count - 1)
            {
                if (input[i][j + 1] == '#')
                {
                    numNeighbors++;
                }
            }

            //up
            if (i > 0)
            {
                if (input[i - 1][j] == '#')
                {
                    numNeighbors++;
                }
            }

            //down
            if (i < input.Count - 1)
            {
                if (input[i + 1][j] == '#')
                {
                    numNeighbors++;
                }
            }

            //topLeft
            if (i > 0 && j > 0)
            {
                if (input[i - 1][j - 1] == '#')
                {
                    numNeighbors++;
                }
            }

            //topRight
            if (i > 0 && j < input[i].Count - 1)
            {
                if (input[i - 1][j + 1] == '#')
                {
                    numNeighbors++;
                }
            }

            //bottomLeft
            if (i < input.Count - 1 && j > 0)
            {
                if (input[i + 1][j - 1] == '#')
                {
                    numNeighbors++;
                }
            }

            //bottomRight
            if (i < input.Count - 1 && j < input[i].Count - 1)
            {
                if (input[i + 1][j + 1] == '#')
                {
                    numNeighbors++;
                }
            }

            if (input[i][j] == '#')
            {
                if (numNeighbors < 2 || numNeighbors > 3)
                {
                    newInput[i][j] = '.';
                }
            }
            else
            {
                if (numNeighbors == 3)
                {
                    newInput[i][j] = '#';
                }
            }


            if (faultyLights)
            {
                if (i == 0 && j == 0)
                {
                    newInput[i][j] = '#';
                }

                if (i == 0 && j == newInput[i].Count - 1)
                {
                    newInput[i][j] = '#';
                }

                if (i == newInput.Count - 1 && j == 0)
                {
                    newInput[i][j] = '#';
                }

                if (i == newInput.Count - 1 && j == newInput[i].Count - 1)
                {
                    newInput[i][j] = '#';
                }
            }


        }
    }


    return newInput;
}