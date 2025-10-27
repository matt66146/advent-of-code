using Day10;
using System.Text;

string input = "1321131112";








//Part 1
string startingElement = ElementInfo.elements.Where(e => e.Value.Sequence == input).First().Key;
int start = 1;
int end = 40;

var output = RunProcessV2(startingElement, start, end);
StringBuilder sb = new StringBuilder();
foreach (var element in output)
{
    sb.Append(ElementInfo.elements[element].Sequence);
}
Console.WriteLine(sb.ToString().Length);

//Part2
end = 50;

output = RunProcessV2(startingElement, start, end);
sb = new StringBuilder();
foreach (var element in output)
{
    sb.Append(ElementInfo.elements[element].Sequence);
}
Console.WriteLine(sb.ToString().Length);




List<string> RunProcessV2(string startingElement, int start, int end)
{
    List<string> elements = new List<string>();
    foreach (var ele in ElementInfo.elements[startingElement].DecaysInto)
    {
        if (start == end)
        {
            elements.AddRange(ele);
        }
        else
        {
            elements.AddRange(RunProcessV2(ele, start + 1, end));
        }

    }
    return elements;
}



string RunProcessV1(string input)
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

