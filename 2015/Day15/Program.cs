using System.Text.Json;

List<Ingredient> ingredients = new();

var input = File.ReadAllLines("input");

foreach (var line in input)
{
    var words = line.Split(' ');
    ingredients.Add(new Ingredient(
        words[0], //Name
        int.Parse(words[2].Remove(words[2].Length - 1)), //Capacity
        int.Parse(words[4].Remove(words[4].Length - 1)), //Durability
        int.Parse(words[6].Remove(words[6].Length - 1)), //Flavor
        int.Parse(words[8].Remove(words[8].Length - 1)), //Texture
        int.Parse(words[10].Remove(words[10].Length)))); //Calories
}

List<Ingredient> teaspoons = new();


//Part1
int score = 0;
int max = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100 - i; j++)
    {
        for (int k = 0; k < 100 - i - j; k++)
        {
            int h = 100 - i - j - k;
            int capacity =
                ingredients.ElementAt(0).Capacity * i +
                ingredients.ElementAt(1).Capacity * j +
                ingredients.ElementAt(2).Capacity * k +
                ingredients.ElementAt(3).Capacity * h;

            int durability =
                ingredients.ElementAt(0).Durability * i +
                ingredients.ElementAt(1).Durability * j +
                ingredients.ElementAt(2).Durability * k +
                ingredients.ElementAt(3).Durability * h;

            int flavor =
                ingredients.ElementAt(0).Flavor * i +
                ingredients.ElementAt(1).Flavor * j +
                ingredients.ElementAt(2).Flavor * k +
                ingredients.ElementAt(3).Flavor * h;

            int texture =
                ingredients.ElementAt(0).Texture * i +
                ingredients.ElementAt(1).Texture * j +
                ingredients.ElementAt(2).Texture * k +
                ingredients.ElementAt(3).Texture * h;

            int calories =
                ingredients.ElementAt(0).Calories * i +
                ingredients.ElementAt(1).Calories * j +
                ingredients.ElementAt(2).Calories * k +
                ingredients.ElementAt(3).Calories * h;

            if (capacity <= 0 || durability <= 0 || flavor <= 0 || texture <= 0)
            {
                score = 0;
                continue;
            }
            score = capacity * durability * flavor * texture;
            if (score > max) max = score;
        }
    }
}
Console.WriteLine($"Part 1 : {max}");


//Part2
score = 0;
max = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100 - i; j++)
    {
        for (int k = 0; k < 100 - i - j; k++)
        {
            int h = 100 - i - j - k;
            int capacity =
                ingredients.ElementAt(0).Capacity * i +
                ingredients.ElementAt(1).Capacity * j +
                ingredients.ElementAt(2).Capacity * k +
                ingredients.ElementAt(3).Capacity * h;

            int durability =
                ingredients.ElementAt(0).Durability * i +
                ingredients.ElementAt(1).Durability * j +
                ingredients.ElementAt(2).Durability * k +
                ingredients.ElementAt(3).Durability * h;

            int flavor =
                ingredients.ElementAt(0).Flavor * i +
                ingredients.ElementAt(1).Flavor * j +
                ingredients.ElementAt(2).Flavor * k +
                ingredients.ElementAt(3).Flavor * h;

            int texture =
                ingredients.ElementAt(0).Texture * i +
                ingredients.ElementAt(1).Texture * j +
                ingredients.ElementAt(2).Texture * k +
                ingredients.ElementAt(3).Texture * h;

            int calories =
                ingredients.ElementAt(0).Calories * i +
                ingredients.ElementAt(1).Calories * j +
                ingredients.ElementAt(2).Calories * k +
                ingredients.ElementAt(3).Calories * h;

            if (!(calories == 500)) continue;
            if (capacity <= 0 || durability <= 0 || flavor <= 0 || texture <= 0)
            {
                score = 0;
                continue;
            }
            score = capacity * durability * flavor * texture;
            if (score > max) max = score;
        }
    }
}
Console.WriteLine($"Part 2 : {max}");


class Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
{
    public string Name { get; set; } = name;
    public int Capacity { get; set; } = capacity;
    public int Durability { get; set; } = durability;
    public int Flavor { get; set; } = flavor;
    public int Texture { get; set; } = texture;
    public int Calories { get; set; } = calories;
}
