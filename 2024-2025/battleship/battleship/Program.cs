using System;
using System.Numerics;

namespace battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mapSize = 10;
            Console.WriteLine("Hello, please select a map size. For a basic game, select 10. Note: smaller map sizes may not be able to fit all ships and you may run out of the alphabet with bigger sizes.");
            while (true) 
            {
                if (int.TryParse(Console.ReadLine(), out mapSize) && mapSize > 0) // 2 protoze chci pridat moznost si vybrat, s jakyma lodema clovek bude hrat
                {
                    break;
                }
                Console.WriteLine("Invalid input, try again");
            }

            char[,] player = new char[mapSize, mapSize];
            char[,] computer = new char[mapSize, mapSize];
            char[,] ships; //prvni pozice je typ lodi, druha dylka
            char[,] computerVisible = new char[mapSize, mapSize];
            int hitCounterPlayer = 0;
            int hitCounterComputer = 0;
            int hitsNeeded = 0;
            string input;


            while (true)
            {
                Console.WriteLine("Do you want to play with all basic ship types? (y/n)");
                input = Console.ReadLine()?.ToLower();
                if (input == "y")
                {
                    ships = new char[2, 5];
                    ships[0, 0] = 'A'; ships[1, 0] = '5'; // aircraft carrier
                    ships[0, 1] = 'B'; ships[1, 1] = '4'; // battleship
                    ships[0, 2] = 'C'; ships[1, 2] = '3'; // cruiser
                    ships[0, 3] = 'D'; ships[1, 3] = '2'; // destroyer
                    ships[0, 4] = 'S'; ships[1, 4] = '2'; // submarine
                    break;
                }
                else if (input == "n")
                {
                    Console.WriteLine("You will now choose which ships to play with.");
                    var shipList = new System.Collections.Generic.List<(char type, int length)>();

                    if (ShipPlacement.AskForShip("Aircraft Carrier (5 x 1)?"))
                        shipList.Add(('A', 5));

                    if (ShipPlacement.AskForShip("Battleship (4 x 1)?"))
                        shipList.Add(('B', 4));

                    if (ShipPlacement.AskForShip("Cruiser (3 x 1)?"))
                        shipList.Add(('C', 3));

                    if (ShipPlacement.AskForShip("Destroyer (2 x 1)?"))
                        shipList.Add(('D', 2));

                    if (ShipPlacement.AskForShip("Submarine (2 x 1)?"))
                        shipList.Add(('S', 2));

                    ships = new char[2, shipList.Count];
                    for (int i = 0; i < shipList.Count; i++)
                    {
                        ships[0, i] = shipList[i].type;
                        ships[1, i] = (char)(shipList[i].length + '0');
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                }
            }
            







            ShipPlacement shipPlacement = new ShipPlacement();
            for (int i = 0; i < ships.GetLength(1) - 1; i++)
            {
                hitsNeeded += Convert.ToInt32(ships[1, i] - '0');
            }

            player = ShipPlacement.InitFill(player);
            computer = ShipPlacement.InitFill(computer);
            computerVisible = ShipPlacement.InitFill(computerVisible);

            ShipPlacement.PrintMap(player);
            
            for (int i = 0; i < ships.GetLength(1); i++)
            {
                player = shipPlacement.ShipPlacementFunctionComputer(ships[1, i] - '0' , ships[0, i] , player); //to minus 0 tam je, protoze konvertuju z ASCII cisel, ktere maji ruzne hodnoty od tech actual cisel - odectu nulu a protoze ASCII je sekvencni tak jsem na psravnych cislech :)
                //źmenit tu fci na tu bez computer, jen se mi porad nechce zadavat souradnice
                ShipPlacement.PrintMap(player);
            } 
            for (int i = 0; i < ships.GetLength(1); i++)
            {
                computer = shipPlacement.ShipPlacementFunctionComputer(ships[1, i] - '0', ships[0, i], computer);
                Console.WriteLine("Generating computer map, iteration " + (i + 1));
                //ShipPlacement.PrintMap(computer);
            }

            while (true)
            {
                (computer, computerVisible, hitCounterPlayer) = GameplayLoop.PlayerTurn(computer, computerVisible, ships, hitCounterPlayer);
                //hipPlacement.PrintMap(computer);
                ShipPlacement.PrintMap(computerVisible);
                Thread.Sleep(500);
                if (hitCounterPlayer >= hitsNeeded)
                {
                    Console.WriteLine("Player won.");
                    break;
                }
                (player, hitCounterComputer) = GameplayLoop.ComputerTurn(player, ships, hitCounterComputer);
                Thread.Sleep(500);
                ShipPlacement.PrintMap(player);
                Thread.Sleep(500);
                if (hitCounterComputer >= hitsNeeded)
                {
                    Console.WriteLine("Computer won.");
                    break;
                }
            }
            
            Console.ReadLine();
        }
    }
}