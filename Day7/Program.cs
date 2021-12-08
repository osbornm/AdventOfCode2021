
Console.WriteLine("Day7");

var crabs = File.ReadAllText("input.txt").Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));

var bestOption = (position: crabs.Min(), fuel: long.MaxValue);



for (int current = 0; current <= crabs.Max(); current++)
{
    var fuel = 0L;

    foreach (var crab in crabs)
    {
        var steps = Math.Abs(crab - current);
        fuel += ((steps * (steps + 1)) /2);
    }
    if(bestOption.fuel > fuel)
        bestOption = (position: current, fuel: fuel);
}


Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {bestOption.fuel}");
Console.WriteLine("***********************************************");