string test = "";
int floor = 0;

try
{
    test = File.ReadAllText("input");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    return;
}

foreach (var c in test)
{
    if (c == '(')
    {
        floor++;
    }
    else if (c == ')')
    {
        floor--;
    }
}

Console.WriteLine($"Final floor: {floor}");