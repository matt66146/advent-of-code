var input = File.ReadAllLines("input.txt");
Part1(input);
Part2(input);

static void Part1(string[] input)
{
    List<List<string>> data = new();

    for (int c = 0; c < input.Length; c++)
    {

        var row = input[c].Split(" ").ToList();
        row.ForEach(r => r.Trim());
        var emptySpace = row.Where(r => r.Equals(string.Empty)).ToList();
        emptySpace.ForEach(r => row.Remove(r));
        data.Add(row);
    }


    ulong answer = 0;

    Dictionary<int, List<ulong>> nums = new();
    List<string> operations = new();
    for (int i = 0; i < data.Count; i++)
    {
        for (int j = 0; j < data[i].Count; j++)
        {
            if (data[i][j] == "+")
            {
                operations.Add("+");
            }
            else if (data[i][j] == "*")
            {
                operations.Add("*");
            }
            else
            {
                if (!nums.ContainsKey(j)) nums.Add(j, new());
                nums[j].Add(UInt64.Parse(data[i][j]));
            }
        }

    }

    for (int i = 0; i < nums.Count; i++)
    {
        ulong calc = nums[i][0];
        for (int n = 1; n < nums[i].Count; n++)
        {
            if (operations[i] == "*")
            {
                calc *= nums[i][n];
            }
            else
            {
                calc += nums[i][n];
            }

        }
        //Console.Write(string.Join($"{operations[i]}", nums[i]));
        //Console.WriteLine($"= {calc}");


        answer += calc;

        //Console.WriteLine($"Current Answer: {answer}");
    }

    Console.WriteLine($"Part 1: {answer}");
}

static void Part2(string[] input)
{
    ulong answer = 0;

    List<List<int>> problems = new();
    string currentOperation = "";
    List<ulong> problem = new();
    for (int c = 0; c < input[0].Length; c++)
    {
        string num = "";
        for (int r = 0; r < input.Length - 1; r++)
        {
            if (input[input.Length - 1][c] == '+')
            {
                currentOperation = "+";
            }
            else if (input[input.Length - 1][c] == '*')
            {
                currentOperation = "*";
            }
            num += input[r][c].ToString().Trim();
        }
        if (c == input[0].Length - 1)
        {
            problem.Add(UInt64.Parse(num));
            answer += CalculateProblem(currentOperation, ref problem);
        }
        if (num == string.Empty)
        {
            answer += CalculateProblem(currentOperation, ref problem);
        }
        else
        {
            problem.Add(UInt64.Parse(num));
        }

    }


    Console.WriteLine($"Part 2: {answer}");

}

static ulong CalculateProblem(string currentOperation, ref List<ulong> problem)
{
    ulong answer = problem[0];
    for (int i = 1; i < problem.Count; i++)
    {
        if (currentOperation == "*")
        {
            answer *= problem[i];
        }
        else
        {
            answer += problem[i];
        }
    }
    problem = new();
    return answer;
}
