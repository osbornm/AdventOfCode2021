Console.WriteLine("Day1 - Part One");

var lines = from line in File.ReadAllLines("input.txt") where !string.IsNullOrEmpty(line) select line.Trim();
var convertedInput = lines.Select(line => Double.Parse(line)).ToArray();

var PartOnetotalIncreases = 0;
for (int i = 1; i < convertedInput.Length; i++)
{
    var hasIncreased = convertedInput[i] > convertedInput[i - 1];
    if(hasIncreased)
    {
        PartOnetotalIncreases++;
    }
    var friendlyDisplay = hasIncreased ? "increased" : "decreased";
    Console.WriteLine($"{convertedInput[i]} ({friendlyDisplay})");
}

Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {PartOnetotalIncreases}");
Console.WriteLine("***********************************************");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Day1 - Part Two");

var PartTwototalIncreases = 0;
var previousSum = convertedInput[0] + convertedInput[1] + convertedInput[2];
for (int i = 1; i < convertedInput.Length-2; i++)
{
    var newSum = convertedInput[i] + convertedInput[i + 1] + convertedInput[i + 2];
    var hasIncreased = newSum > previousSum;
    if (hasIncreased)
    {
        PartTwototalIncreases += 1;
    }
    var friendlyDisplay = hasIncreased ? "increased" : "decreased";
    previousSum = newSum;
}

Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {PartTwototalIncreases}");
Console.WriteLine("***********************************************");