using System.Text.Json;

string f = "";

f = File.ReadAllText("input");

var test = JsonSerializer.Deserialize<JsonElement>(f);

Console.WriteLine($"Part 1: {Loop(test, false)}");
Console.WriteLine($"Part 2: {Loop(test, true)}");




int Loop(JsonElement element, bool part2)
{
    int sum = 0;
    if (element.ValueKind == JsonValueKind.Number)
    {
        sum = element.GetInt32();
    }
    else if (element.ValueKind == JsonValueKind.Array)
    {
        foreach (var arrayProperty in element.EnumerateArray())
        {
            sum += Loop(arrayProperty, part2);
        }
    }
    else if (element.ValueKind == JsonValueKind.Object)
    {
        if (part2)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.String)
                {
                    if (property.Value.GetString() == "red")
                    {
                        return sum;
                    }
                }
            }
        }
        foreach (var property in element.EnumerateObject())
        {
            sum += Loop(property.Value, part2);
        }
    }
    return sum;
}