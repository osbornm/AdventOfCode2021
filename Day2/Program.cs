//Console.WriteLine("Day2 - Part One");


//var lines = from line in File.ReadAllLines("input.txt") where !string.IsNullOrEmpty(line) select line.Trim();

//var commandRegex = new System.Text.RegularExpressions.Regex("^(\\w*) (\\d*)$");

//var commands = lines.Select(line =>
//{
//    var match = commandRegex.Match(line);
//    if (!match.Success)
//        throw new InvalidOperationException($"Unknown instruction: {line}");
//    return new { command = match.Groups[1].Value, value = long.Parse(match.Groups[2].Value) };
//});

//var horizontal = 0L;
//var depth = 0L;

//foreach (var command in commands)
//{
//    switch (command.command.ToLowerInvariant())
//    {
//        case "forward":
//            horizontal += command.value;
//            break;
//        case "down":
//            depth += command.value;
//            break;
//        case "up":
//            depth -= command.value;
//            break;
//        default:
//            Console.WriteLine($"Unknown command '{command.command}'");
//            break;
//    }
//}


//Console.WriteLine("***********************************************");
//Console.WriteLine($"answer: {{horizontal: {horizontal}, depth: {depth}}}");
//Console.WriteLine($"answer: {horizontal* depth}");
//Console.WriteLine("***********************************************");
//Console.WriteLine();
//Console.WriteLine();

Console.WriteLine("Day2 - Part One");


var lines = from line in File.ReadAllLines("input.txt") where !string.IsNullOrEmpty(line) select line.Trim();

var commandRegex = new System.Text.RegularExpressions.Regex("^(\\w*) (\\d*)$");

var commands = lines.Select(line =>
{
    var match = commandRegex.Match(line);
    if (!match.Success)
        throw new InvalidOperationException($"Unknown instruction: {line}");
    return new { command = match.Groups[1].Value, value = long.Parse(match.Groups[2].Value) };
});

var horizontal = 0L;
var depth = 0L;
var aim = 0L;

foreach (var command in commands)
{
    switch (command.command.ToLowerInvariant())
    {
        case "forward":
            horizontal += command.value;
            depth += (aim * command.value);
            break;
        case "down":
            aim += command.value;
            break;
        case "up":
            aim -= command.value;
            break;
        default:
            Console.WriteLine($"Unknown command '{command.command}'");
            break;
    }
}


Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {{horizontal: {horizontal}, depth: {depth}, aim: {aim}}}");
Console.WriteLine($"answer: {horizontal * depth}");
Console.WriteLine("***********************************************");