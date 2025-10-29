using System.Text.Json;
using Microsoft.VisualBasic;

var input = File.ReadAllLines("input");
List<Dictionary<string, int>> aunts = new();
Dictionary<string, int> tickerResult = new();
tickerResult["children"] = 3;
tickerResult["samoyeds"] = 2;
tickerResult["pomeranians"] = 3;
tickerResult["akitas"] = 0;
tickerResult["vizslas"] = 0;
tickerResult["goldfish"] = 5;
tickerResult["trees"] = 3;
tickerResult["cars"] = 2;
tickerResult["perfumes"] = 1;
tickerResult["cats"] = 7;

foreach (var line in input)
{
    var words = line.Split(' ');
    var aunt = new Dictionary<string, int>();

    for (int i = 2; i < words.Length; i += 2)
    {
        aunt[words[i].Replace(":", "")] = Int32.Parse(words[i + 1].Replace(",", ""));
    }
    aunts.Add(aunt);
}



//Part 1
int giftedAunt = 0;

foreach (var aunt in aunts)
{
    bool auntFound = true;
    foreach (var key in tickerResult.Keys)
    {
        if (tickerResult[key] == 0)
        {
            if (aunt.ContainsKey(key))
            {
                if (aunt[key] != 0)
                {
                    auntFound = false;
                    break;
                }
            }
        }
        else
        {
            if (aunt.ContainsKey(key))
            {
                if (aunt[key] != tickerResult[key])
                {
                    auntFound = false;
                    break;
                }
            }


        }
    }
    if (auntFound)
    {
        giftedAunt = aunts.IndexOf(aunt) + 1;
        break;
    }
}
Console.WriteLine($"Part 1 - Aunt who gave gift: {giftedAunt}");


//Part 2
giftedAunt = 0;

foreach (var aunt in aunts)
{
    bool auntFound = true;
    foreach (var key in tickerResult.Keys)
    {
        if (tickerResult[key] == 0)
        {
            if (aunt.ContainsKey(key))
            {
                if (key == "cats" || key == "trees")
                {
                    if (!(aunt[key] > tickerResult[key]))
                    {
                        auntFound = false;
                        break;
                    }
                }
                else
                {
                    if (aunt[key] != 0)
                    {
                        auntFound = false;
                        break;
                    }
                }
            }
        }
        else
        {
            if (aunt.ContainsKey(key))
            {
                if (key == "cats" || key == "trees")
                {
                    if (!(aunt[key] > tickerResult[key]))
                    {
                        auntFound = false;
                        break;
                    }
                }
                else if (key == "pomeranians" || key == "goldfish")
                {
                    if (!(aunt[key] < tickerResult[key]))
                    {
                        auntFound = false;
                        break;
                    }
                }
                else
                {
                    if (aunt[key] != tickerResult[key])
                    {
                        auntFound = false;
                        break;
                    }
                }

            }


        }
    }
    if (auntFound)
    {
        giftedAunt = aunts.IndexOf(aunt) + 1;
        break;
    }
}
Console.WriteLine($"Part 2 - Aunt who gave gift: {giftedAunt}");