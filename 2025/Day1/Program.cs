int position = 50;

var f = File.ReadAllLines("testinput.txt");

Console.WriteLine("*Test Input*");
Calc(position, f);
f = File.ReadAllLines("input.txt");
Console.WriteLine("*Real Input*");
Calc(position, f);


static void Calc(int position, string[] f)
{
    int answer = 0;
    int answerP1 = 0;
    foreach (var line in f)
    {
        int change = Int32.Parse(line.Substring(1));


        if (line[0] == 'R')
        {
            answer += (position + change) / 100;
            position = (position + (change % 100)) % 100;
        }
        else
        {
            int newPosition = (position - change) % 100;
            if (position == 0)
            {
                answer += change / 100;
            }
            else if (change > position)
            {
                answer += ((change - position - 1) / 100) + 1;
                if (newPosition == 0) answer++;
            }
            else if (change == position)
            {
                answer++;
            }
            position = newPosition;
        }

    }
    Console.WriteLine($"Answer Part 2: {answer}");
}

static void BadCalcWTF(int position, string[] f)
{
    int answer = 0;

    foreach (var line in f)
    {
        int change = Int32.Parse(line.Substring(1, line.Length - 1));


        for (int i = 0; i < change; i++)
        {
            if (line[0] == 'L')
            {
                position--;
                if (position == -1) position = 99;
            }
            else
            {
                position++;
                if (position == 100) position = 0;
            }
            if (position == 0) answer++;
        }
    }
    Console.WriteLine(answer);
}