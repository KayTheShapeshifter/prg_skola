using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    internal class ShipPlacement
    {
        public char[,] ShipPlacementFunction(int shipLength, char shipType, char[,] map)
        {
            string input = "";
            char[,] newMap = map;
            int placeRow;
            int placeCol;

            while (true)
            {
                Console.WriteLine($"You are now placing a ship ({shipLength} x 1). Write a number (1 - 10) for the desired row");
                if (int.TryParse(Console.ReadLine(), out placeRow) && placeRow >= 1 && placeRow <= 10) //je to, co zadava cislo a vejde se mi to tam?
                {
                    Console.WriteLine($"You selected row {placeRow}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
            while (true)
            {
                Console.WriteLine("Write a letter (A - J) for the desired collumn");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && input.Length == 1 && input[0] >= 'A' && input[0] <= 'J') //jestli se nepletu, tak ono to dokaze s tema cislama pracovat jako kdybychom se nachazeli v jine ciselne soustave
                {
                    placeCol = input[0] - 'A'; // 0 v zavorkach je proto, ze pristupuju na prvni znak v stringu input... 
                    //jinak tohle je logika na konverzi z te "soustavy" tech pismen na ciselnou - jakoby kdyz odectu A tak jdu na normalni desitkovou pak :)
                    Console.WriteLine($"You selected collumn {input} (index {placeRow})");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
            while (true)
            {
                Console.WriteLine("You have now selected the top left anchor for the ship. Write V for vertical or H for horizontal. Type retry to try to place the ship again");
                input = Console.ReadLine()?.ToUpper();
                if (input == "V" || input == "H")
                {
                    if (input == "V")
                    {
                        if (placeRow - 1 + shipLength <= 10) // rows zacinaji od 1 ale index od 0
                        {
                            Console.WriteLine("The ship fits vertically.");
                            for (int i = 0; i < shipLength; i++)
                            {
                                if (newMap[placeRow - 1 + i, placeCol] != 'O') // O jsou prazdny policka
                                {
                                    Console.WriteLine("The ship overlaps with another ship. Try again.");
                                    return ShipPlacementFunction(shipLength, shipType, map); // volam to vsechno znova se stejnyma parametrama
                                }
                                map[placeRow - 1 + i, placeCol] = shipType; 
                            }
                        }
                        else
                        {
                            Console.WriteLine("The ship cannot fit vertically in the selected position. Try again.");
                            continue;
                        }
                    }
                    else if (input == "H")
                    {
                        if (placeCol + shipLength <= 10) // tady ale uz indexy zacinaji na 0 protoze to konvertuju z pismen
                        {
                            Console.WriteLine("The ship fits horizontally.");
                            for (int i = 0; i < shipLength; i++)
                            {
                                if (map[placeRow - 1, placeCol + i] != 'O') 
                                {
                                    Console.WriteLine("The ship overlaps with another ship. Try again.");
                                    return ShipPlacementFunction(shipLength, shipType, map);
                                }
                                map[placeRow - 1, placeCol + i] = shipType; 
                            }
                        }
                        else
                        {
                            Console.WriteLine("The ship cannot fit horizontally in the selected position. Try again.");
                            continue;
                        }
                    } 
                    else if (Console.ReadLine()?.ToLower() == "RETRY")
                    {
                        // tady to znova zavola tu fci se stejnyma parametrama
                    }

                    // If we reach here, the ship fits in the selected orientation
                    Console.WriteLine($"You selected orientation: {(input == "V" ? "Vertical" : "Horizontal")}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }                
            }




            return newMap;
        }
    }
}
