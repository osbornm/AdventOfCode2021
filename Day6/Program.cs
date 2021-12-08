using Day6;
using System.Drawing;

Console.WriteLine("Day6");

var input = File.ReadAllText("input.txt").Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));

//var numberOfDaysToRun = 256;
//var Fishes = input.Select(x => new Fish(x)).ToList();
//for (int i = 0; i < numberOfDaysToRun; i++)
//{
//    var newFishes = new List<Fish>();
//    foreach (var fish in Fishes)
//    {
//        var offSpring = fish.RunCycle();
//        if(offSpring != null)
//        {
//            newFishes.Add(offSpring);
//        }
//    }
//    Fishes.AddRange(newFishes);
//}




var fishes = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

foreach (var starterFish in input)
{
    fishes[starterFish]++;
}

var numberOfDaysToRun = 256;
for (int day = 0; day < numberOfDaysToRun; day++)
{
    var spawningFish = fishes[0];
    for (int i = 1; i < 9; i++)
    {
        fishes[i-1] = fishes[i];
    }

    fishes[8] = spawningFish; // the new number of fish is equal to the number that spawned
    fishes[6] += spawningFish; // reset the spawning fish
}




Console.WriteLine("***********************************************");
Console.WriteLine($"answer: {fishes.Sum()}");
Console.WriteLine("***********************************************");
