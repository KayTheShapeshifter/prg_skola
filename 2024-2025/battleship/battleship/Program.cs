using System;
using System.Numerics;

namespace battleship
{
    internal class Program
    {
        static void PrintMap(char[,] map)
        {
            Console.WriteLine("  A B C D E F G H I J");
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
        static char[,] InitFill(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 'O';
                }
            }
            return map;
        }
        static void Main(string[] args)
        {
            char[,] player = new char[10,10];
            char[,] computer = new char[10, 10];
            char[,] ships = new char[2, 5]; //prvni pozice je typ lodi, druha dylka
            ships[0, 0] = 'A'; //aircraft carrier
            ships[1, 0] = '5';

            ships[0, 1] = 'B'; //battleship
            ships[1, 1] = '4';

            ships[0, 2] = 'C'; //cruiser
            ships[1, 2] = '3';

            ships[0, 3] = 'D'; //destroyer
            ships[1, 3] = '2';

            ships[0, 4] = 'S'; //sub
            ships[1, 4] = '2';

            ShipPlacement shipPlacement = new ShipPlacement();

            player = InitFill(player);
            computer = InitFill(computer);

            PrintMap(player);

            for (int i = 0; i < ships.GetLength(1); i++)
            {
                player = shipPlacement.ShipPlacementFunction(ships[1, i] - '0' , ships[0, i] , player); //to minus 0 tam je, protoze konvertuju z ASCII cisel, ktere maji ruzne hodnoty od tech actual cisel - odectu nulu a protoze ASCII je sekvencni tak jsem na psravnych cislech :)
                PrintMap(player);
            }

            Console.ReadLine();

        }
    }
}