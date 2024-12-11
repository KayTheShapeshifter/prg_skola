using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    internal class GameplayLoop
    {
        char[,] PlayerTurn(char[,] map, char[,] visibleMap, char[,] ships)
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
                tile = map[row, col];
                if (tile == '×')
                {
                    Console.WriteLine("Whoopsie, you already shot there you dummy! Try again.");
                    continue;
                }
                else if (tile == '~')
                {
                    Console.WriteLine("You missed, git gud");
                    map[row, col] = '×';
                    visibleMap[row, col] = '×';
                    break;
                } 
                else 
                {
                    Console.WriteLine($"You hit ship type {tile}");
                    map[row, col] = 'ø';
                    visibleMap[row, col] = 'ø';
                }
            }
            




            return map;
        }
    }
}
