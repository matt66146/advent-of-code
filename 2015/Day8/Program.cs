using System.Text;
using System.Text.RegularExpressions;

List<string> f = new();

f = File.ReadLines("input").ToList();
int numCode = 0;
int numMemory = 0;
int numPart2 = 0;
ASCIIEncoding ascii = new ASCIIEncoding();
foreach (var line in f)
{
    numCode += line.Count();
    var x = Regex.Unescape(line);
    var y = Regex.Escape(line).Replace("\"", "\\\"");
    Console.WriteLine(y);
    numMemory += x.Count() - 2;
    numPart2 += y.Count() + 2;
}
Console.WriteLine($"Code: {numCode}");
Console.WriteLine($"Memory: {numMemory}");
Console.WriteLine($"Code-Memory: {numCode - numMemory}");


Console.WriteLine($"P2 {numPart2}");
Console.WriteLine($"P2 {numPart2 - numCode}");


