using System;
using System.Numerics;

namespace battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] player = new char[10,10];
            char[,] computer = new char[10, 10];
            char[,] ships = new char[2, 5]; //prvni pozice je typ lodi, druha dylka
            char[,] computerVisible = new char[10, 10];

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

            player = ShipPlacement.InitFill(player);
            computer = ShipPlacement.InitFill(computer);
            computerVisible = ShipPlacement.InitFill(computerVisible);

            ShipPlacement.PrintMap(player);
            
            for (int i = 0; i < ships.GetLength(1); i++)
            {
                player = shipPlacement.ShipPlacementFunction(ships[1, i] - '0' , ships[0, i] , player); //to minus 0 tam je, protoze konvertuju z ASCII cisel, ktere maji ruzne hodnoty od tech actual cisel - odectu nulu a protoze ASCII je sekvencni tak jsem na psravnych cislech :)
                ShipPlacement.PrintMap(player);
            } 
            for (int i = 0; i < ships.GetLength(1); i++)
            {
                computer = shipPlacement.ShipPlacementFunctionComputer(ships[1, i] - '0', ships[0, i], computer); //to minus 0 tam je, protoze konvertuju z ASCII cisel, ktere maji ruzne hodnoty od tech actual cisel - odectu nulu a protoze ASCII je sekvencni tak jsem na psravnych cislech :)
                Console.WriteLine("Generating computer map, iteration " + (i + 1));
                ShipPlacement.PrintMap(computer);
            }


            Console.ReadLine();

        }
    }
}