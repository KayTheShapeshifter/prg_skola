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
        public static (int, bool) SelectRow(char[,] map)
        {
            int row = 0;
            bool success = false;
            if (int.TryParse(Console.ReadLine(), out row) && row >= 1 && row <= map.GetLength(1)) //je to, co zadava cislo a vejde se mi to tam?
            {
                Console.WriteLine($"You selected row {row}");
                success = true;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
            return (row, success);
        }
        public static (int, bool) SelectCol(char[,] map)
        {
            string input;
            int col = 0;
            bool success = false;
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Length == 1 && input[0] >= 'A' && input[0] <= map.GetLength(0) + 'A') //jestli se nepletu, tak ono to dokaze s tema cislama pracovat jako kdybychom se nachazeli v jine ciselne soustave
            {
                col = input[0] - 'A'; // 0 v zavorkach je proto, ze pristupuju na prvni znak v stringu input... 
                                           //jinak tohle je logika na konverzi z te "soustavy" tech pismen na ciselnou - jakoby kdyz odectu A tak jdu na normalni desitkovou pak :)
                Console.WriteLine($"You selected collumn {input}");
                success = true;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
            return (col, success);

        }
        public char[,] ShipPlacementFunction(int shipLength, char shipType, char[,] map)
        {
            string input = "";
            char[,] newMap = map;
            int placeRow;
            int placeCol;
            bool success = false;

            while (true)
            {
                Console.WriteLine($"You are now placing a ship, type {shipType} ({shipLength} x 1). Write a number (1 - {map.GetLength(1)}) for the desired row");
                (placeRow, success) = SelectRow(map);
                if (success)
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine($"Write a letter (A - {Convert.ToChar(map.GetLength(0) - 1 + 'A')}) for the desired collumn");
                (placeCol, success) = SelectCol(map);
                if (success)
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("You have now selected the top left anchor for the ship. Write V for vertical or H for horizontal. Type retry to try to place the ship again");
                input = Console.ReadLine()?.ToUpper();
                if (input == "V" || input == "H" || input == "RETRY")
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
                    else if (input == "RETRY")
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



            while (true)
            {
                placeRow = rnd.Next(map.GetLength(1));
                placeCol = rnd.Next(map.GetLength(0));
                rndInt = rnd.Next(2);
                if (rndInt == 0) //vertical
                {
                    if (placeRow + shipLength <= map.GetLength(1)) // rows zacinaji od 1 ale index od 0
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
                    if (placeCol + shipLength <= map.GetLength(1)) // tady ale uz indexy zacinaji na 0 protoze to konvertuju z pismen
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
