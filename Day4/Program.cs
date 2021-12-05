using Day4;

//Console.WriteLine("Day4 - Part One");



//var input = File.ReadAllText("input.txt").Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


//var numbers = input[0].Trim().Split(',').Select(n => Convert.ToInt32(n)).ToList();

//var boards = new List<Board>();
//for (int i = 1; i < input.Length; i++)
//{
//    boards.Add(new Board(input[i].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)));
//}


//var Play = () => {
//    foreach (var number in numbers)
//    {
//        foreach (var board in boards)
//        {
//            if (board.PlayNumber(number)) {
//                return board;
//            }
//        }
//    }
//    return null;
//};

//var winningBoard = Play();


//Console.WriteLine("***********************************************");
//if (winningBoard != null)
//{
//    Console.WriteLine($"Found a Winner! {winningBoard.GetAnswer()}");
//} 
//else
//{
//    Console.WriteLine("💔 No winning board found 💔");
//}
//Console.WriteLine("***********************************************");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Day4 - Part Two");


var input = File.ReadAllText("input.txt").Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


var numbers = input[0].Trim().Split(',').Select(n => Convert.ToInt32(n)).ToList();

var boards = new List<Board>();
for (int i = 1; i < input.Length; i++)
{
    boards.Add(new Board(input[i].Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)));
}


var Play = () => {
    foreach (var number in numbers)
    {
        foreach (var board in boards)
        {
            if (board.PlayNumber(number))
            {
                return board;
            }
        }
    }
    return null;
};

while (boards.Count > 1)
{
    var boardToRemove = Play();
    boards.Remove(boardToRemove);
}

var winningBoard = Play();


Console.WriteLine("***********************************************");
if (winningBoard != null)
{
    Console.WriteLine($"Found a Winner! {winningBoard.GetAnswer()}");
}
else
{
    Console.WriteLine("💔 No winning board found 💔");
}