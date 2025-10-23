using System.Security.Cryptography;

string input = "yzbqklnj";
int i = 0;

bool part1Found = false;
bool part2Found = false;

using (var md5 = MD5.Create())
{
    while (!part1Found || !part2Found)
    {
        var bytes = System.Text.Encoding.ASCII.GetBytes(input + i.ToString());
        var hashBytes = md5.ComputeHash(bytes);
        var hashString = Convert.ToHexString(hashBytes);

        if (!part1Found && hashString.StartsWith("00000"))
        {
            Console.WriteLine($"Part 1: {i}");
            part1Found = true;
        }

        if (hashString.StartsWith("000000"))
        {
            Console.WriteLine($"Part 2: {i}");
            part2Found = true;
        }

        i++;
    }
}