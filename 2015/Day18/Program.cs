using System.Runtime.InteropServices;
using System.Text;

var f = File.ReadAllLines("input");

List<List<char>> input = new List<List<char>>();
Console.CursorVisible = false;
int msDelay = 0;
if (args.Length > 0)
{
    msDelay = Int32.Parse(args[0]);
}

foreach (var line in f)
{
    List<char> lineArray = new();
    for (int i = 0; i < line.Length; i++)
    {
        lineArray.Add(line[i]);
    }
    input.Add(lineArray);
}

if (OperatingSystem.IsWindows())
{
    Console.BufferHeight = 500;
    Console.BufferWidth = 500;
}


Console.ForegroundColor = ConsoleColor.Yellow;
int numSteps = 100;
Console.Clear();
Console.WriteLine("\x1b[3J");
DrawSimulation(input);
Thread.Sleep(msDelay);
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
    //Console.Clear();
    //Console.WriteLine("\x1b[3J");
    DrawSimulation(input);
    Thread.Sleep(millisecondsTimeout: msDelay);
    //Console.ReadKey();
}
//Console.Clear();
Console.WriteLine("\x1b[3J");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Starting Part 2 in 2 seconds...");
Console.ForegroundColor = ConsoleColor.Yellow;
Thread.Sleep(millisecondsTimeout: 2000);
Console.Clear();
Console.WriteLine("\x1b[3J");
for (int i = 0; i < numSteps; i++)
{
    inputP2 = RunSimulation(inputP2, true);
    //Console.Clear();
    //onsole.WriteLine("\x1b[3J");
    DrawSimulation(inputP2);
    Thread.Sleep(millisecondsTimeout: msDelay);
    //Console.ReadKey();
}

Console.ForegroundColor = ConsoleColor.White;
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
    var sb = new StringBuilder();
    Console.SetCursorPosition(0, 0);
    for (int i = 0; i < input.Count; i += 2)
    {
        for (int j = 0; j < input[i].Count; j++)
        {
            // Console.SetCursorPosition(j, i);
            if (input[i][j] == '#')
            {

                if (input[i + 1][j] == '#')
                {
                    sb.Append("█");
                    //Console.Write("█");
                }
                else
                {
                    sb.Append("▀");
                }

            }
            else if (input[i + 1][j] == '#')
            {
                sb.Append("▄");
            }
            else
            {
                sb.Append(" ");
            }



        }
        sb.Append("\n");
    }
    Console.WriteLine($"{sb}\x1b[3J");
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