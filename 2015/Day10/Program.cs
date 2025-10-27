string input = "1321131112";



for (int i = 0; i < 40; i++)
{
    Console.WriteLine(i);
    input = RunProcess(input);
}
Console.WriteLine(input);
Console.WriteLine(input.Length);



string RunProcess(string input)
{
    string newInput = "";
    for (int i = 0; i < input.Length;)
    {
        char c = input[i];
        int num = 1;
        int j = i + 1;

        if (j < input.Length)
        {
            while (input[j] == c)
            {
                num++;
                j++;
            }
        }
        i += num;
        //Console.WriteLine($"{num} {c}");
        newInput += $"{num}{c}";
    }

    return newInput;
}