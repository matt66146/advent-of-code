List<string> f = new();
f = File.ReadLines("input").ToList();

int rowLength = 1000;

bool[,] lights = new bool[rowLength, rowLength];
int[,] lightsPart2 = new int[rowLength, rowLength];
int numLightsOn = 0;
int totalBrightness = 0;

for (int i = 0; i < rowLength; i++)
{
    for (int j = 0; j < rowLength; j++)
    {
        lights[i, j] = false;
    }
}

foreach (string line in f)
{
    var words = line.Split(" ");
    if (words[0] == "turn")
    {
        var start = words[2].Split(',');
        int startX = int.Parse(start[0]);
        int startY = int.Parse(start[1]);
        var end = words[4].Split(',');
        int endX = int.Parse(end[0]);
        int endY = int.Parse(end[1]);

        bool toggleLightTo = false;

        if (words[1] == "off")
        {
            toggleLightTo = false;
        }
        else if (words[1] == "on")
        {
            toggleLightTo = true;
        }
        else
        {
            Console.WriteLine("ERROR 1");
        }

        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j <= endY; j++)
            {
                lights[i, j] = toggleLightTo;

                //part2
                if (toggleLightTo)
                {
                    lightsPart2[i, j]++;
                }
                else
                {
                    lightsPart2[i, j]--;
                    if (lightsPart2[i, j] < 0) lightsPart2[i, j] = 0;
                }

            }
        }

    }
    else if (words[0] == "toggle")
    {
        var start = words[1].Split(',');
        int startX = int.Parse(start[0]);
        int startY = int.Parse(start[1]);
        var end = words[3].Split(',');
        int endX = int.Parse(end[0]);
        int endY = int.Parse(end[1]);

        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j <= endY; j++)
            {
                lights[i, j] = !lights[i, j];
                lightsPart2[i, j] += 2;
            }
        }
    }
    else
    {
        Console.WriteLine("Error 2");
    }
}

for (int i = 0; i < rowLength; i++)
{
    for (int j = 0; j < rowLength; j++)
    {
        if (lights[i, j])
        {
            numLightsOn++;
        }

        //part 2
        totalBrightness += lightsPart2[i, j];
    }
}

Console.WriteLine(numLightsOn);
Console.WriteLine(totalBrightness);