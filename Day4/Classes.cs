using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Board
    {
        public int[,] Numbers = new int[5, 5];
        public int LastNumber { get; set; }
        public Board(string[] rawData)
        {
            for (int x = 0; x < 5; x++)
            {
                var row = rawData[x].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => Convert.ToInt32(n)).ToList();
                for (int y = 0; y < 5; y++)
                {
                    Numbers[x, y] = row[y];
                }
            }
        }
        public bool isWinner()
        {
            for (int i = 0; i < 5; i++)
            {
                if(Numbers[0, i] + Numbers[1, i] + Numbers[2, i] + Numbers[3, i] + Numbers[4, i] == -5)
                {
                    return true;
                }

                if (Numbers[i, 0] + Numbers[i, 1] + Numbers[i, 2] + Numbers[i, 3] + Numbers[i, 4] == -5)
                {
                    return true;
                }

            }
            return false;
        }

        public bool PlayNumber(int number)
        {
            LastNumber = number;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (Numbers[x, y] == number)
                    {
                        Numbers[x, y] = -1;
                    }
                }
            }

            return isWinner();
        }

        public long GetAnswer()
        {
            var sum = 0;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (Numbers[x, y] != -1)
                    {
                        sum += Numbers[x, y];
                    }
                }
            }

            return LastNumber * sum;
        }
    }
}
