
Console.WriteLine("Day9");

var inputs = File.ReadAllLines("input.txt").Select(l => l.ToArray().Select(c => Convert.ToInt32($"{c}", 10)).ToList()).ToList();

var lowPoints = new List<int>();

for (int y = 0; y < inputs.Count(); y++)
{
    for (int x = 0; x < inputs[y].Count(); x++)
    {
        var currentPoint = inputs[y][x];
        var left = x - 1 >= 0 ? inputs[y][x - 1] : int.MaxValue;
        var right = x + 1 < inputs[y].Count() ? inputs[y][x + 1] : int.MaxValue;
        var top = y - 1 >= 0 ? inputs[y - 1][x] : int.MaxValue;
        var bottom = y + 1 < inputs.Count() ? inputs[y + 1][x] : int.MaxValue;

        if (currentPoint < left && currentPoint < right && currentPoint < top && currentPoint < bottom)
        {
            lowPoints.Add(currentPoint);
        }
    }
}

Console.WriteLine("***********************************************");
Console.WriteLine($"answer 1: {lowPoints.Sum(x => x + 1)}");
Console.WriteLine("***********************************************");


var basins = new List<long>();

for (int y = 0; y < inputs.Count(); y++)
{
    for (int x = 0; x < inputs[y].Count(); x++)
    {
        var b = Calculate(x, y);
        if (b != 0)
        {
            basins.Add(b);
        }
    }
}

long Calculate(int x, int y)
{
    if (x < 0 || y < 0 || y >= inputs.Count() || x >= inputs[y].Count() || inputs[y][x] > 8)
        return 0;

    inputs[y][x] = int.MaxValue;
    return 1 + Calculate(x - 1, y) + Calculate(x + 1, y) + Calculate(x, y - 1) + Calculate(x, y + 1);
}

Console.WriteLine("***********************************************");
Console.WriteLine($"answer 2: {basins.OrderByDescending(x => x).Take(3).Aggregate(1L, (x, sum) => x * sum)}");
Console.WriteLine("***********************************************");
