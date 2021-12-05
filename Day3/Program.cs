Console.WriteLine("Day3 - Part One");


var lines = (from line in File.ReadAllLines("input.txt") where !string.IsNullOrEmpty(line) select line.Trim()).ToArray();

var numberOfBits = lines[0].Count();
var gamma = 0L;
var epsilon = 0L;

for (int i = 0; i < numberOfBits; i++)
{
    var zeros = 0L;
    var ones = 0L;
    foreach (var line in lines)
    {
        if(line[i] == '1')
        {
            ++ones;
        } else
        {
            ++zeros;
        }  
    }

    if(ones > zeros)
    {
        gamma = gamma * 2 + 1;
        epsilon = epsilon * 2;
        // Gamma get ones
    } else {
        gamma = gamma * 2;
        epsilon = epsilon * 2 +1;
    }
}

Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {gamma * epsilon}");
Console.WriteLine("***********************************************");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Day3 - Part One");


ulong oxygenFilter(string[] theArray, int position)
{
    if (theArray.Length == 1) return Convert.ToUInt64(theArray[0], 2);

    var searchChar = '1';
    var numberOfOnes = theArray.Count(line => line[position] == '1');

    if (numberOfOnes < theArray.Length - numberOfOnes) searchChar = '0';


    return oxygenFilter(theArray.Where(line => line[position] == searchChar).ToArray(), ++position);
};

var oxygen = oxygenFilter(lines, 0);


ulong CO2Filter(string[] theArray, int position)
{
    if (theArray.Length == 1) return Convert.ToUInt64(theArray[0], 2);

    var searchChar = '1';
    var numberOfOnes = theArray.Count(line => line[position] == '1');
    if (numberOfOnes >= theArray.Length - numberOfOnes) searchChar = '0';

    return CO2Filter(theArray.Where(line => line[position] == searchChar).ToArray(), ++position);
};

var co2 = CO2Filter(lines, 0);

Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {{oxygen: {oxygen}, co2: {co2}}}");
Console.WriteLine($"answer: {oxygen * co2}");
Console.WriteLine("***********************************************");