using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RockPaperScissors.Program;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        public static class GlobalVar
        {
            public const int sleepTimer = 300;
        }

        public class Player
        {
            public int id;
            public double score = 0;
            public int recentMove;
            Random rng;
            public Player(int id)
            {
                this.id = id;
                this.rng = new Random(id);
            }

            public int GenerateMove(int topLimit)
            {
                int move = this.rng.Next(1, topLimit);
                
                return move;
            }
            public void ScoreAdd(double scoreToAdd)
            {
                this.score = this.score + scoreToAdd;
                Console.WriteLine("Player " + this.id + " gains " + scoreToAdd + " score.");
            }
        }
        
        static void Main(string[] args)
        {
            double endScore = 10;
            int playerIdCounter = 1;
            Player player1 = new Player(playerIdCounter);
            playerIdCounter++;
            Player player2 = new Player(playerIdCounter);
            playerIdCounter++;

           
            while (true)
            {
                Console.WriteLine("Welcome to my little minigame program. Press a number corresponding to the game you want to play.\n" +
                    "1 - rock, paper, scissors\n" +
                    "2 - deathroll");
                char operation = Console.ReadKey().KeyChar;
                if (operation == '1')
                {
                    Console.WriteLine();
                    RockPaperScissors(player1, player2, endScore);
                    break;
                }
                else if (operation == '2')
                {
                    Console.WriteLine();
                    Deatroll(player1 , player2, endScore);
                    break;
                }
                else
                {
                    Console.WriteLine("Špatný imput, zkus to znova");
                }
            }

            if (player1.score > player2.score)
            {
                Console.WriteLine("Player 1 won");
            }
            else
            {
                Console.WriteLine("Player 2 won");
            }
            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
        }
        public static void RockPaperScissors(Player player1, Player player2, double endScore)
        {
            Dictionary<int, string> rockPaperScissors = new Dictionary<int, string>();
            rockPaperScissors.Add(1, "rock");
            rockPaperScissors.Add(2, "paper");
            rockPaperScissors.Add(3, "scissors");

            while (player1.score < endScore && player2.score < endScore)
            {
                Thread.Sleep(GlobalVar.sleepTimer);
                player1.recentMove = player1.GenerateMove(4);
                player2.recentMove = player2.GenerateMove(4);
                Console.WriteLine("Player 1 chose " + rockPaperScissors[player1.recentMove] + " and Player2 chose " + rockPaperScissors[player2.recentMove]);

                switch (player1.recentMove)
                {
                    case 1:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player1.ScoreAdd(0.5);
                                player2.ScoreAdd(0.5);
                                break;
                            case 2:
                                player1.ScoreAdd(1);
                                break;
                            case 3:
                                player2.ScoreAdd(1);
                                break;
                        }
                        break;
                    case 2:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player2.ScoreAdd(1);
                                break;
                            case 2:
                                player1.ScoreAdd(0.5);
                                player2.ScoreAdd(0.5);
                                break;
                            case 3:
                                player1.ScoreAdd(1);
                                break;
                        }
                        break;
                    case 3:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player1.ScoreAdd(1);
                                break;
                            case 2:
                                player2.ScoreAdd(1);
                                break;
                            case 3:
                                player1.ScoreAdd(0.5);
                                player2.ScoreAdd(0.5);
                                break;
                        }
                        break;
                }
                Console.WriteLine("Player 1 has a score of" + player1.score + " and player 2 has a score of " + player2.score);
                Console.WriteLine();
            }
        }
        public static void Deatroll(Player player1, Player player2, double endScore)
        {
            Random rng = new Random();
            int iteration = 0;

            while (player1.score < endScore && player2.score < endScore)
            {
                int topLimit = rng.Next(2, 10000);
                Thread.Sleep(GlobalVar.sleepTimer * 2);
                while (true)
                {
                    Thread.Sleep(GlobalVar.sleepTimer);
                    iteration++;
                    player1.recentMove = player1.GenerateMove(topLimit);
                    topLimit = player1.recentMove;
                    Console.WriteLine("Player 1 rolled " + player1.recentMove);
                    Thread.Sleep(GlobalVar.sleepTimer);

                    if (player1.recentMove == 1)
                    {
                        Console.WriteLine("Player 1 won.");
                        break;
                    }
                    Console.WriteLine("The top limit is " + topLimit);


                    Thread.Sleep(GlobalVar.sleepTimer);
                    iteration++;
                    player2.recentMove = player2.GenerateMove(topLimit);
                    topLimit = player2.recentMove;
                    Console.WriteLine("Player 2 rolled " + player2.recentMove);
                    Thread.Sleep(GlobalVar.sleepTimer);
                    if (player2.recentMove == 1)
                    {
                        Console.WriteLine("Player 2 won.");
                        break;
                    }
                    Console.WriteLine("The top limit is " + topLimit);

                }

                if (Convert.ToBoolean(iteration % 2))
                {
                    player1.ScoreAdd(1);
                }
                else
                {
                    player2.ScoreAdd(1);
                }

                Console.WriteLine("Player 1 has a score of " + player1.score + " and player 2 has a score of " + player2.score);
                Console.WriteLine("\n");
            }
        }
    }
}
