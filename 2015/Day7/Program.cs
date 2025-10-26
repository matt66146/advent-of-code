using System.Diagnostics;

var f = new List<string>();

f = File.ReadAllLines("input").ToList();

var wires = new Dictionary<string, string>();
var connectionCache = new Dictionary<string, ushort>();
var stopwatch = new Stopwatch();


stopwatch.Start();
foreach (var line in f)
{
    var words = line.Split(' ');

    wires[$"{words[words.Length - 1]}"] = String.Join(" ", words.Take(words.Length - 2));
}


ushort RunMachine(string key)
{
    ushort value;
    if (ushort.TryParse(key, out value))
    {
        return value;
    }

    if (connectionCache.ContainsKey(key)) return connectionCache[key];


    var instructionArr = wires[key].Split(" ");

    //Simple case i.e lx -> a
    if (instructionArr.Length == 1)
    {
        connectionCache[key] = RunMachine(instructionArr[0]);
    }
    //NOT case i.e NOT lx -> a
    else if (instructionArr.Length == 2)
    {
        connectionCache[key] = (ushort)~RunMachine(instructionArr[1]);
    }
    //AND, OR, and SHIFT cases
    else
    {
        switch (instructionArr[1])
        {
            case "AND":
                connectionCache[key] = (ushort)(RunMachine(instructionArr[0]) & RunMachine(instructionArr[2]));
                break;
            case "OR":
                connectionCache[key] = (ushort)(RunMachine(instructionArr[0]) | RunMachine(instructionArr[2]));
                break;
            case "LSHIFT":
                connectionCache[key] = (ushort)(RunMachine(instructionArr[0]) << RunMachine(instructionArr[2]));
                break;
            case "RSHIFT":
                connectionCache[key] = (ushort)(RunMachine(instructionArr[0]) >> RunMachine(instructionArr[2]));
                break;

            default:
                Console.WriteLine("ERROR THIS SHOULD NEVER HAPPEN");
                break;
        }
    }

    return connectionCache[key];
}



foreach (var wire in wires)
{
    RunMachine(wire.Key);
}

Console.WriteLine($"Part 1 - Wire a: {connectionCache["a"]}");


var b = connectionCache["a"];

connectionCache = new Dictionary<string, ushort>();
connectionCache["b"] = b;

foreach (var wire in wires)
{
    RunMachine(wire.Key);
}

Console.WriteLine($"Part 2 - Wire a: {connectionCache["a"]}");

stopwatch.Stop();
Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed}");







//Old version
stopwatch.Restart();
//Part1
var wiresOLD = RunMachineOLD(true, (ushort)0);
Console.WriteLine($"Part 1: {wiresOLD["a"]}");






//Part2
wiresOLD = RunMachineOLD(false, wiresOLD["a"]);
Console.WriteLine($"Part 2: {wiresOLD["a"]}");

stopwatch.Stop();
Console.WriteLine($"Elapsed Time: {stopwatch.Elapsed}");


Dictionary<string, ushort> RunMachineOLD(bool part1, ushort b)
{
    Dictionary<string, ushort> wiresOLD = new();
    Dictionary<string, ushort> prevWires = new();

    do
    {
        prevWires = new Dictionary<string, ushort>(wiresOLD);

        foreach (string line in f)
        {
            var commands = line.Split(' ').ToList();
            if (commands[0] == "NOT")
            {
                //Initialize wire to 0 if does not exist
                if (!wiresOLD.ContainsKey(commands[1])) wiresOLD[commands[1]] = 0;

                wiresOLD[commands[3]] = (ushort)~wiresOLD[commands[1]];
            }
            else
            {
                ushort value;
                if (ushort.TryParse(commands[0], out value))
                {
                    if ((commands[1] == "->"))
                    {
                        wiresOLD[commands[2]] = value;
                        if (!part1 && commands[2] == "b")
                        {
                            wiresOLD[commands[2]] = b;
                        }
                    }
                    else
                    {
                        //Initialize wire to 0 if does not exist
                        if (!wiresOLD.ContainsKey(commands[2])) wiresOLD[commands[2]] = 0;
                        switch (commands[1])
                        {
                            case "AND":
                                wiresOLD[commands[4]] = (ushort)(value & wiresOLD[commands[2]]);
                                break;

                            case "OR":
                                wiresOLD[commands[4]] = (ushort)(value | wiresOLD[commands[2]]);
                                break;

                            default:
                                Console.WriteLine("This should not happen!!!!!!");
                                break;
                        }
                    }
                }
                else
                {
                    //Initialize wire to 0 if does not exist
                    if (!wiresOLD.ContainsKey(commands[0])) wiresOLD[commands[0]] = 0;
                    switch (commands[1])
                    {
                        case "AND":
                            //Initialize wire to 0 if does not exist
                            if (!wiresOLD.ContainsKey(commands[2])) wiresOLD[commands[2]] = 0;

                            wiresOLD[commands[4]] = (ushort)(wiresOLD[commands[0]] & wiresOLD[commands[2]]);
                            break;
                        case "OR":
                            //Initialize wire to 0 if does not exist
                            if (!wiresOLD.ContainsKey(commands[2])) wiresOLD[commands[2]] = 0;

                            wiresOLD[commands[4]] = (ushort)(wiresOLD[commands[0]] | wiresOLD[commands[2]]);
                            break;
                        case "LSHIFT":
                            wiresOLD[commands[4]] = (ushort)(wiresOLD[commands[0]] << int.Parse(commands[2]));
                            break;
                        case "RSHIFT":
                            wiresOLD[commands[4]] = (ushort)(wiresOLD[commands[0]] >> int.Parse(commands[2]));
                            break;
                        case "->":
                            //Initialize wire to 0 if does not exist
                            if (!wiresOLD.ContainsKey(commands[2])) wiresOLD[commands[2]] = 0;
                            wiresOLD[commands[2]] = wiresOLD[commands[0]];

                            break;

                        default:
                            Console.WriteLine("This should not happen!!!!!!");
                            break;
                    }

                }
            }
        }
    } while (wiresOLD.Except(prevWires).Any());
    return wiresOLD;
}
