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
    foreach (var line in f)
    {
        int change = Int32.Parse(line.Substring(1, line.Length - 1));
        answer += (change - position) / 100;
        if ((change - position) / 100 > 0)
        {
            Console.WriteLine("***");
            Console.WriteLine(position);
            Console.WriteLine(line);
            Console.WriteLine((change - position) / 100);
        }
        if (line[0] == 'L')
        {
            if (position - change <= 0 && position != 0)
            {
                answer++;
                if ((change - position) / 100 > 0)
                {
                    Console.WriteLine("+1");
                }
            }
            position = (position - change) % 100;
            if (position < 0)
            {
                position += 100;
            }
        }
        else
        {
            if (position + change >= 100)
            {
                answer++;
                if ((change - position) / 100 > 0)
                {
                    Console.WriteLine("+1");
                }
            }
            position = (position + change) % 100;
        }

        //Console.WriteLine(answer);

    }
    Console.WriteLine($"Answer: {answer}");
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