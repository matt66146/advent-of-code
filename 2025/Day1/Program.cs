int position = 50;

var f = File.ReadAllLines("testinput.txt");

Calc(position, f);
f = File.ReadAllLines("input.txt");
Calc(position, f);




static void Calc(int position, string[] f)
{
    int answer = 0;
    Console.WriteLine($"Start {position}");
    foreach (var line in f)
    {
        int change = Int32.Parse(line.Substring(1, line.Length - 1));

        if (line[0] == 'L')
        {
            position = (position - change) % 100;
            if (position < 0)
            {
                position += 100;
            }
        }
        else
        {
            position = (position + change) % 100;
        }

        if (position == 0)
        {
            answer++;
        }
    }
    Console.WriteLine($"Answer: {answer}");
}
