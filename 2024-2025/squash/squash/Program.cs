using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace squash
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please make the application full screen for the app to work properly");
            Console.ReadKey();
            Console.Clear();

            Player player = new Player();
            player.direction = '|';
            player.position = 7;
            player.length = 4;

            Map mapClass = new Map();
            char[,] map = mapClass.CreateMap(62, 24);
            mapClass.PrintMap(map);
            int turnCounter = 1;
            Ball ball = new Ball();
            bool lost;
            
            while (true)
            {
                int oldPosition = player.position;
                // Get new position and movement flag; no need to pass movedLastTurn now.
                (player.position, player.direction, map) = player.PlayerMovement(player.position, player.length, map);

                if (true)
                {
                    // player.ClearPlayer(oldPosition, player.length);
                    player.PrintPlayer(player.position, player.direction, player.length);

                    if (player.direction == '↓')
                    {
                        Console.SetCursorPosition(0, oldPosition);
                        Console.Write(' ');
                    }
                    else if (player.direction == '↑')
                    {
                        Console.SetCursorPosition(0, oldPosition + player.length - 1);
                        Console.Write(' ');
                    }
                }

                (lost, map) = ball.BallMovement(turnCounter, map);
                if (lost)
                {
                    break;
                }

                turnCounter++;
                Thread.Sleep(15);
            }


            Thread.Sleep(500);

            Console.WriteLine("You lost. Final score " + (turnCounter - 1));

            Thread.Sleep(500);

            ProcessStartInfo psi = new ProcessStartInfo(); // credit https://tpforums.org/forum/archive/index.php/t-1524.html and others
            psi.CreateNoWindow = true;
            psi.UseShellExecute = true;
            psi.FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(psi);

            Console.ReadKey();
        }
    }
}