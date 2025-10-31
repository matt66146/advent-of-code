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
Console.Clear();
//DrawSimulation(input);
//Thread.Sleep(1000);
//Console.WriteLine(GetLightsOn(input));
//Console.ReadKey();


for (int i = 0; i < numSteps; i++)
{
    input = RunSimulation(input);
    //Console.Clear();
    //Console.WriteLine("\x1b[3J");
    //rawSimulation(input);
    //Thread.Sleep(millisecondsTimeout: 100);
    //Console.ReadKey();
}
Console.WriteLine(GetLightsOn(input));
Console.CursorVisible = true;

Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;



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
List<List<char>> RunSimulation(List<List<char>> input)
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



        }
    }


    return newInput;
}