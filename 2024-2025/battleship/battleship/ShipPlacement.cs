using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    internal class ShipPlacement
    {
        public static void PrintMap(char[,] map)
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1).ToString().PadLeft(2)); // Row numbers
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($" {map[i, j]}");
                }
                Console.WriteLine();
            }
        }
        public static char[,] InitFill(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = '~';
                }
            }
            return map;
        }
        public char[,] ShipPlacementFunction(int shipLength, char shipType, char[,] map)
        {
            string input = "";
            char[,] newMap = map;
            int placeRow;
            int placeCol;

            while (true)
            {
                Console.WriteLine($"You are now placing a ship, type {shipType} ({shipLength} x 1). Write a number (1 - 10) for the desired row");
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
                                if (newMap[placeRow - 1 + i, placeCol] != '~') // ~ jsou prazdny policka
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
                                if (map[placeRow - 1, placeCol + i] != '~') 
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
                        return ShipPlacementFunction(shipLength, shipType, map);
                    }

                    // pokud se dostanu sem, tak se to vejde
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


        public char[,] ShipPlacementFunctionComputer(int shipLength, char shipType, char[,] map)
        {
            char[,] newMap = map;
            int placeRow;
            int placeCol;
            int tooManyRepetitions = 0;
            Random rnd = new Random();
            int rndInt;

            placeRow = rnd.Next(10);
            placeCol = rnd.Next(10); 

            while (true)
            {
                rndInt = rnd.Next(2);
                if (rndInt == 0) //vertical
                {
                    if (placeRow + shipLength <= 10) // rows zacinaji od 1 ale index od 0
                    {
                        for (int i = 0; i < shipLength; i++)
                        {
                            if (newMap[placeRow + i, placeCol] != '~') // ~ jsou prazdny policka
                            {
                                return ShipPlacementFunctionComputer(shipLength, shipType, map); // volam to vsechno znova se stejnyma parametrama
                            }
                            map[placeRow + i, placeCol] = shipType;
                        }
                    }
                    else
                    {
                        //nevejde se
                        continue;
                    }
                }
                else if (rndInt == 1)//horizontal
                {
                    if (placeCol + shipLength <= 10) // tady ale uz indexy zacinaji na 0 protoze to konvertuju z pismen
                    {
                        for (int i = 0; i < shipLength; i++)
                        {
                            if (map[placeRow, placeCol + i] != '~')
                            {
                                //overlaps with another ship
                                return ShipPlacementFunctionComputer(shipLength, shipType, map);
                            }
                            map[placeRow, placeCol + i] = shipType;
                        }
                    }
                    else
                    {
                        //nevejde se
                        tooManyRepetitions++;
                        continue;
                    }
                }
                else if (tooManyRepetitions >= 2)
                {
                    return ShipPlacementFunctionComputer(shipLength, shipType, map);
                }

                // pokud se dostanu sem, tak se to vejde
                break;
            }

            return newMap;
        }
    }
}
