
Console.WriteLine("Day8");

var inputs = File.ReadAllLines("input.txt").Select(l =>
{
    var parts = l.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
    return (
        digits: parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries),
        value: parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
    );
}).ToList();


// 1 has two segments
// 4 has four segments
// 7 has three segements
// 8 has seven segments

var simpleLetters = new int[] { 2, 3, 4, 7 };
var answer1 = 0;

foreach (var input in inputs)
{
    answer1 += input.value.Where(o => simpleLetters.Contains(o.Length)).Count();
}



Console.WriteLine("***********************************************");
Console.WriteLine($"answer 1: {answer1}");
Console.WriteLine("***********************************************");

var answer2 = 0L;

foreach (var input in inputs)
{
    var map = new Dictionary<int, string>(); // yes this could be an array my brain hurt from 0 indexing :man-shrugging:

    // Handle the simple digits
    map[1] = input.digits.Single(d => d.Length == 2);
    map[4] = input.digits.Single(d => d.Length == 4);
    map[7] = input.digits.Single(d => d.Length == 3);
    map[8] = input.digits.Single(d => d.Length == 7);

    // five segments

    var fiveDigitValues = input.digits.Where(d => d.Length == 5).ToList();

    map[2] = fiveDigitValues.Single(fdv => fdv.Intersect(map[4]).Count() == 2); // a two has to share 2 parts with a four
    fiveDigitValues.Remove(map[2]);

    map[3] = fiveDigitValues.Single(fdv => fdv.Intersect(map[1]).Count() == 2); // a three shares 2 parts with a one 
    fiveDigitValues.Remove(map[3]);

    map[5] = fiveDigitValues.Single(); // anything else without the overlap is a five

    // six segments

    var sixDigitValues = input.digits.Where(d => d.Length == 6).ToList();

    map[6] = sixDigitValues.Single(fdv => fdv.Intersect(map[1]).Count() == 1); // a six has one part with a one
    sixDigitValues.Remove(map[6]);

    map[9] = sixDigitValues.Single(fdv => fdv.Intersect(map[4]).Count() == 4); // a nine has all parts of a four
    sixDigitValues.Remove(map[9]);

    map[0] = sixDigitValues.Single(); // this must be a zero then


    var value = 0L;

    foreach (var digit in input.value)
    {
        for (var digitIdx = 0; digitIdx < 10; ++digitIdx)
        {
            if (map[digitIdx].Length == digit.Length && map[digitIdx].Intersect(digit).Count() == digit.Length)
            {
                value = value * 10 + digitIdx;
                break;
            }
        }
    }

    answer2 += value;

}






Console.WriteLine("***********************************************");
Console.WriteLine($"answer 1: {answer2}");
Console.WriteLine("***********************************************");
