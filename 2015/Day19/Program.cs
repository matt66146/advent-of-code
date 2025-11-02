
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

var input = File.ReadAllLines("input.txt");

List<(string Input, string Output)> machine = new();

for (int i = 0; i < input.Length - 2; i++)
{
    var lineArray = input[i].Split(" => ");
    (string Input, string Output) instruction = (lineArray[0], lineArray[1]);
    machine.Add(instruction);

}



List<string> startingMolecules = new();

foreach (char c in input[input.Length - 1])
{
    startingMolecules.Add(c.ToString());
}


HashSet<string> molecules = GenerateMolecule(startingMolecules, machine);

HashSet<string> GenerateMolecule(List<string> startingMolecules, List<(string Input, string Output)> machine)
{
    HashSet<string> molecules = new();
    foreach (var instruction in machine)
    {
        for (int i = 0; i < startingMolecules.Count; i++)
        {

            string moleculeToCheck = "";
            for (int j = 0; j < instruction.Input.Length; j++)
            {
                if (i < startingMolecules.Count - 1)
                {
                    moleculeToCheck += startingMolecules[i + j];
                }
                else
                {
                    moleculeToCheck += startingMolecules[i];
                }

            }
            if (moleculeToCheck == instruction.Input)
            {
                List<string> newMolecule = [.. startingMolecules];
                newMolecule[i] = instruction.Output;
                for (int j = 1; j < instruction.Input.Length; j++)
                {
                    newMolecule[i + j] = string.Empty;
                }

                molecules.Add(string.Join("", newMolecule));
            }
        }

    }


    return molecules;

}
/*
foreach (var molecule in molecules)
{
    Console.WriteLine(molecule);
}
*/

Console.WriteLine($"Part 1 - Num Distinct Molecules: {molecules.Count}");

//part 2 - stupid hack answer
string a = string.Join("", startingMolecules);
var goal = a.ToCharArray();
int numSymbols = goal.Where(m => Char.IsUpper(m)).Count();
int numRn = Regex.Matches(a, "Rn").Count;

int numAr = Regex.Matches(a, "Ar").Count;
int numY = Regex.Matches(a, "Y").Count;

int answer = numSymbols - numRn - numAr - 2 * numY - 1;

Console.WriteLine(answer);