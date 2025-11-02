using System.Text.Json;
using Microsoft.VisualBasic;

int input = 36000000;
int maxHouses = 50;

List<(int House, int Presents)> houses = new();
for (int i = 1; i <= input; i++)
{
    houses.Add((i, 0));
}


for (int elfNum = 1; elfNum <= input; elfNum++)
{
    int housesVisited = 0;
    for (int i = elfNum; i <= houses.Count; i += elfNum)
    {
        houses[i - 1] = (i, (elfNum * 10) + houses[i - 1].Presents);
        housesVisited++;
    }

}
var smallest = houses.Where(house => house.Presents >= input).First();
Console.WriteLine($"Part 1 - Smallest House: {smallest.House} - {smallest.Presents}");


//part 2
houses = new();
for (int i = 1; i <= input; i++)
{
    houses.Add((i, 0));
}


for (int elfNum = 1; elfNum <= input; elfNum++)
{
    int housesVisited = 0;
    for (int i = elfNum; i <= houses.Count; i += elfNum)
    {
        if (housesVisited >= maxHouses) break;
        houses[i - 1] = (i, (elfNum * 11) + houses[i - 1].Presents);
        housesVisited++;
    }

}
smallest = houses.Where(house => house.Presents >= input).First();
Console.WriteLine($"Part 2 - Smallest House: {smallest.House} - {smallest.Presents}");
