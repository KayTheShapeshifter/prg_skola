using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
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

            public int GenerateMove()
            {
                int move = this.rng.Next(1, 4);
                return move;
            }
            public void ScoreWin()
            {
                this.score++;
                Console.WriteLine("Player" + this.id + " gains a point");
            }
        }
        static void Main(string[] args)
        {
            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel
            int playerIdCounter = 1;
            Player player1 = new Player(playerIdCounter);
            playerIdCounter++;
            Player player2 = new Player(playerIdCounter);
            playerIdCounter++;
            Dictionary <int, string> rockPaperScissors = new Dictionary<int, string>();
            rockPaperScissors.Add(1, "rock");
            rockPaperScissors.Add(2, "paper");
            rockPaperScissors.Add(3, "scissors");

            while (player1.score < 10 && player2.score < 10)
            {
                Thread.Sleep(100);
                player1.recentMove = player1.GenerateMove();
                player2.recentMove = player2.GenerateMove();

                Console.WriteLine("Player 1 chose " + rockPaperScissors[player1.recentMove] + " and Player2 chose " + rockPaperScissors[player2.recentMove]);
                
                switch (player1.recentMove) 
                { 
                    case 1:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player1.score += 0.5;
                                player2.score += 0.5;
                                break;
                            case 2:
                                player1.ScoreWin(); 
                                break;
                            case 3:
                                player2.ScoreWin();
                                break;
                        }
                        break;
                    case 2:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player2.ScoreWin();
                                break;
                            case 2:
                                player1.score += 0.5;
                                player2.score += 0.5;
                                break;
                            case 3:
                                player1.ScoreWin();
                                break;
                        }
                        break;
                    case 3:
                        switch (player2.recentMove)
                        {
                            case 1:
                                player1.ScoreWin();
                                break;
                            case 2:
                                player2.ScoreWin();
                                break;
                            case 3:
                                player1.score += 0.5;
                                player2.score += 0.5;
                                break;
                        }
                    break;
                }
                Console.WriteLine("Player 1 has " + player1.score + " points and player 2 has " + player2.score + " points");
                Console.WriteLine();
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
    }
}
