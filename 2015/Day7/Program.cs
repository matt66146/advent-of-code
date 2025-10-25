var f = new List<string>();
var fPart2 = new List<string>();

f = File.ReadAllLines("input").ToList();
fPart2 = File.ReadAllLines("inputPart2").ToList();

//Part1
var wires = RunMachine(f);
Console.WriteLine($"Part 1: {wires["a"]}");






//Part2
wires = RunMachine(fPart2);
Console.WriteLine($"Part 2: {wires["a"]}");










Dictionary<string, ushort> RunMachine(List<string> f)
{
    Dictionary<string, ushort> wires = new();
    Dictionary<string, ushort> prevWires = new();

    do
    {
        prevWires = new Dictionary<string, ushort>(wires);

        foreach (string line in f)
        {
            var commands = line.Split(' ').ToList();
            if (commands[0] == "NOT")
            {
                //Initialize wire to 0 if does not exist
                if (!wires.ContainsKey(commands[1])) wires[commands[1]] = 0;

                wires[commands[3]] = (ushort)~wires[commands[1]];
            }
            else
            {
                ushort value;
                if (ushort.TryParse(commands[0], out value))
                {
                    if ((commands[1] == "->"))
                    {
                        wires[commands[2]] = value;
                    }
                    else
                    {
                        //Initialize wire to 0 if does not exist
                        if (!wires.ContainsKey(commands[2])) wires[commands[2]] = 0;
                        switch (commands[1])
                        {
                            case "AND":
                                wires[commands[4]] = (ushort)(value & wires[commands[2]]);
                                break;

                            case "OR":
                                wires[commands[4]] = (ushort)(value | wires[commands[2]]);
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
                    if (!wires.ContainsKey(commands[0])) wires[commands[0]] = 0;
                    switch (commands[1])
                    {
                        case "AND":
                            //Initialize wire to 0 if does not exist
                            if (!wires.ContainsKey(commands[2])) wires[commands[2]] = 0;

                            wires[commands[4]] = (ushort)(wires[commands[0]] & wires[commands[2]]);
                            break;
                        case "OR":
                            //Initialize wire to 0 if does not exist
                            if (!wires.ContainsKey(commands[2])) wires[commands[2]] = 0;

                            wires[commands[4]] = (ushort)(wires[commands[0]] | wires[commands[2]]);
                            break;
                        case "LSHIFT":
                            wires[commands[4]] = (ushort)(wires[commands[0]] << int.Parse(commands[2]));
                            break;
                        case "RSHIFT":
                            wires[commands[4]] = (ushort)(wires[commands[0]] >> int.Parse(commands[2]));
                            break;
                        case "->":
                            //Initialize wire to 0 if does not exist
                            if (!wires.ContainsKey(commands[2])) wires[commands[2]] = 0;
                            wires[commands[2]] = wires[commands[0]];
                            break;

                        default:
                            Console.WriteLine("This should not happen!!!!!!");
                            break;
                    }

                }
            }
        }
    } while (wires.Except(prevWires).Any());
    return wires;
}