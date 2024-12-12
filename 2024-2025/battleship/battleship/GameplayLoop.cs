using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    internal class GameplayLoop
    {
        public static (char[,], char[,], int) PlayerTurn(char[,] map, char[,] visibleMap, char[,] ships, int hitCounter)
        {
            int row;
            int col;
            bool success;
            char tile;

            while (true)
            {
                while (true)
                {
                    Console.WriteLine($"You are now targeting a shell at the enemy. Write a number (1 - {map.GetLength(1)}) for the desired row");
                    (row, success) = ShipPlacement.SelectRow(map);
                    if (success)
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine($"Write a letter (A - {Convert.ToChar(map.GetLength(0) - 1 + 'A')}) for the desired collumn");
                    (col, success) = ShipPlacement.SelectCol(map);
                    if (success)
                    {
                        break;
                    }
                }
                row--;

                tile = map[row, col];
                if (tile == 'ø')
                {
                    Console.WriteLine("Whoopsie, you already shot there you dummy! Try again.");
                    continue;
                }
                else if (tile == '~')
                {
                    Console.WriteLine("You missed, git gud");
                    map[row, col] = 'ø';
                    visibleMap[row, col] = 'ø';
                    break;
                } 
                else 
                {
                    Console.WriteLine($"You hit ship type {tile}");
                    map[row, col] = '×';
                    visibleMap[row, col] = '×';
                    hitCounter++;
                    break;
                }
            }
            return (map, visibleMap, hitCounter);
        }
        public static (char[,], int) ComputerTurn(char[,] map, char[,] ships, int hitCounter)
        {
            Random rnd = new Random();
            int row;
            int col;
            char tile;

            while (true)
            {
                row = rnd.Next(map.GetLength(1) - 1);
                col = rnd.Next(map.GetLength(0));

                tile = map[row, col];

                if (tile == 'ø')
                {
                    continue;
                }
                else if (tile == '~')
                {
                    map[row, col] = 'ø';
                    Console.WriteLine($"The computer hit water at {row}, {Convert.ToChar(col + 'A')}");
                    break;
                }
                else
                {
                    map[row, col] = '×';
                    Console.WriteLine($"The computer hit you at {row}, {Convert.ToChar(col + 'A')}. Striking ship type {tile}");
                    hitCounter++;
                    break;
                }
            }
            

            return (map, hitCounter);
        }
    }
}
