string input = "hepxcrrq";



while (!IsValidPassword(input))
{
    input = AddOne(input.Length - 1, input);
}
Console.WriteLine($"Part 1: {input}");


do
{
    input = AddOne(input.Length - 1, input);
} while (!IsValidPassword(input));
Console.WriteLine($"Part 2: {input}");






string AddOne(int index, string pw)
{
    var chars = pw.ToCharArray();
    if (chars[index] == 'z')
    {
        chars[index] = 'a';
        pw = AddOne(index - 1, String.Join("", chars));
    }
    else
    {
        chars[index]++;
        pw = String.Join("", chars);
    }
    return pw;
}


bool IsValidPassword(string input)
{
    return ThreeInARow(input) && NoBadLetters(input) && CheckRepeat(input);
}

bool ThreeInARow(string input)
{
    for (int i = 0; i < input.Length - 2; i++)
    {
        int j = i + 1;
        int k = 1;
        while ((char)(input[i] + k) == input[j])
        {
            if (j > i + 1)
            {
                return true;
            }
            j++;
            k++;
        }
    }
    return false;
}

bool NoBadLetters(string input)
{
    if (input.Contains('i') || input.Contains('o') || input.Contains('l'))
    {
        return false;
    }
    return true;
}

bool CheckRepeat(string input)
{
    string prev = "";
    int numRepeat = 0;
    for (int i = 0; i < input.Length - 1; i++)
    {
        if (input[i] == input[i + 1])
        {
            numRepeat++;
            i++;
            if (numRepeat == 2)
            {
                return true;
            }
        }


    }
    return false;
}
