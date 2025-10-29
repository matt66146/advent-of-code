using System.Text.Json;

List<Ingredient> ingredients = new();
/*
ingredients.Add(new Ingredient("Butterscotch", -1, -2, 6, 3, 8));
ingredients.Add(new Ingredient("Cinnamon", 2, 3, -2, -1, 3));
*/

var input = File.ReadAllLines("input");

foreach (var line in input)
{
    var words = line.Split(' ');
    /*
    string name = words[0];
 
    int capacity = int.Parse(words[2]);
    int durability = int.Parse(words[4]);
    int flavor = int.Parse(words[6]);
    int texture = int.Parse(words[8]);
    int calories = int.Parse(words[10]);
    */
    foreach (var word in words)
    {
        //Console.WriteLine(word);
    }
    ingredients.Add(new Ingredient(
        words[0], //Name
        int.Parse(words[2].Remove(words[2].Length - 1)), //Capacity
        int.Parse(words[4].Remove(words[4].Length - 1)), //Durability
        int.Parse(words[6].Remove(words[6].Length - 1)), //Flavor
        int.Parse(words[8].Remove(words[8].Length - 1)), //Texture
        int.Parse(words[10].Remove(words[10].Length)))); //Calories
}

foreach (var ingredient in ingredients)
{
    //Console.WriteLine(JsonSerializer.Serialize(ingredient));
}

List<Ingredient> teaspoons = new();

foreach (var ingredient in ingredients)
{
    teaspoons.Add(ingredient);
}

for (int i = ingredients.Count; i < 100; i++)
{
    int capacity = 0;
    int durability = 0;
    int flavor = 0;
    int texture = 0;
    int calories = 0;

    foreach (var ingredient in teaspoons)
    {
        capacity += ingredient.Capacity;
        durability += ingredient.Durability;
        flavor += ingredient.Flavor;
        texture += ingredient.Texture;
        calories += ingredient.Calories;
    }
    int tempScore = 0;
    Ingredient bestToAdd = null;
    foreach (var ingredient in ingredients)
    {
        int iScore = (capacity + ingredient.Capacity) * (durability + ingredient.Durability) * (flavor + ingredient.Flavor) * (texture + ingredient.Texture);
        if (calories + ingredient.Calories <= 500 || 1 == 1)
        {
            if (iScore > tempScore)
            {
                tempScore = iScore;
                bestToAdd = ingredient;
            }
        }


    }
    if (bestToAdd == null)
    {
        //break;
        throw new Exception("THIS SHOULD NOT HAPPEN!!!!");
    }
    teaspoons.Add(bestToAdd);
}

int c = 0;
int d = 0;
int f = 0;
int t = 0;
int cal = 0;

foreach (var ingredient in teaspoons)
{
    c += ingredient.Capacity;
    d += ingredient.Durability;
    f += ingredient.Flavor;
    t += ingredient.Texture;
    cal += ingredient.Calories;
}
int totalScore = c * d * f * t;



Dictionary<string, int> percent = new();
foreach (var ingredient in teaspoons)
{
    if (!percent.ContainsKey(ingredient.Name))
    {
        percent[ingredient.Name] = 0;
    }
    percent[ingredient.Name]++;
}

Console.WriteLine(JsonSerializer.Serialize(percent));
Console.WriteLine(cal);
Console.WriteLine(totalScore);


class Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
{
    public string Name { get; set; } = name;
    public int Capacity { get; set; } = capacity;
    public int Durability { get; set; } = durability;
    public int Flavor { get; set; } = flavor;
    public int Texture { get; set; } = texture;
    public int Calories { get; set; } = calories;
}
