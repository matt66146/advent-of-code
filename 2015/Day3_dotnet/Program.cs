string f = "";

int x = 0;
int y = 0;
HashSet<(int, int)> houses = new();

//Part2 ***********
int santaX = 0;
int santaY = 0;
int roboX = 0;
int roboY = 0;
HashSet<(int, int)> housesPart2 = new();
bool robo = false;
//*****************

try
{
    f = File.ReadAllText("input");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}

foreach (char move in f)
{
    switch (move)
    {
        case '^':
            y++;
            houses.Add((x, y));

            //part 2
            if (!robo)
            {
                santaY++;
                housesPart2.Add((santaX, santaY));
            }
            else
            {
                roboY++;
                housesPart2.Add((roboX, roboY));
            }
            break;
        case 'v':
            y--;
            houses.Add((x, y));

            //part 2
            if (!robo)
            {
                santaY--;
                housesPart2.Add((santaX, santaY));
            }
            else
            {
                roboY--;
                housesPart2.Add((roboX, roboY));
            }
            break;
        case '<':
            x--;
            houses.Add((x, y));

            //part 2
            if (!robo)
            {
                santaX--;
                housesPart2.Add((santaX, santaY));
            }
            else
            {
                roboX--;
                housesPart2.Add((roboX, roboY));
            }
            break;
        case '>':
            x++;
            houses.Add((x, y));

            //part 2
            if (!robo)
            {
                santaX++;
                housesPart2.Add((santaX, santaY));
            }
            else
            {
                roboX++;
                housesPart2.Add((roboX, roboY));
            }
            break;
        default:
            Console.WriteLine($"Invalid move character: {move}");
            break;
    }
    robo = !robo;
}

Console.WriteLine($"Part 1 - Total houses visited: {houses.Count}");
Console.WriteLine($"Part 2 - Total houses visited: {housesPart2.Count}");