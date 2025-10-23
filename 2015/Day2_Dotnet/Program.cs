var f = File.ReadAllLines("input");
var totalArea = 0;
var totalRibbon = 0;
foreach (var line in f)
{
    var dimensions = line.Split('x').Select(int.Parse).ToList();
    var l = dimensions[0];
    var w = dimensions[1];
    var h = dimensions[2];
    dimensions.Sort();
    var area = (2 * l * w) + (2 * w * h) + (2 * h * l) + (dimensions[0] * dimensions[1]);

    Console.WriteLine(area);
    totalArea += area;

    var ribbon = (2 * dimensions[0]) + (2 * dimensions[1]) + (l * w * h);

    totalRibbon += ribbon;
}

Console.WriteLine(totalArea);
Console.WriteLine(totalRibbon);