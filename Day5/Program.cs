using System.Drawing;

Console.WriteLine("Day5 - Part One");



var commandRegex = new System.Text.RegularExpressions.Regex("(\\d*,\\d*) -> (\\d*,\\d*)");
var field = new Dictionary<(int, int), int>();
var input = File.ReadAllLines("input.txt").Select(line =>
{
    var match = commandRegex.Match(line);
    if (!match.Success)
        throw new InvalidOperationException($"Unknown line: {line}");
    var left = match.Groups[1].Value.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
    var right = match.Groups[2].Value.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
    return new { left = new { x = left[0], y = left[1] }, right = new { x = right[0], y = right[1] } };
});


foreach (var line in input)
{

    var xIncrement = line.left.x > line.right.x ? -1 : (line.left.x < line.right.x ? 1 : 0);
    var yIncrement = line.left.y > line.right.y ? -1 : (line.left.y < line.right.y ? 1 : 0);

    //if (xIncrement != 0 && yIncrement != 0)
    //{
    //    Console.WriteLine("not a straight line");
    //    continue;
    //}

    var loopCount = Math.Max(Math.Abs(line.left.x - line.right.x), Math.Abs(line.left.y - line.right.y));
    var x = line.left.x;
    var y = line.left.y;

    for (int i = 0; i <= loopCount; ++i)
    {
        var location = (x, y);
        field.TryGetValue(location, out var count);
        field[location] = count+1;
        x += xIncrement;
        y += yIncrement;
    }
}



Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {field.Values.Where(v => v > 1).Count()}");
Console.WriteLine("***********************************************");
