using System;
using System.Collections;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Game1
{
    internal class Program
    {
        public static int mapRowSize = 128;
        public static int playableAreaSize = 16; //size of the "road"

        static void Main(string[] args) 
        {
            GameLoop.startGame();
            Map map1 = new Map();
            GameLoop gameLoop = new GameLoop();
            bool varCollisionDetection = false;
            int scoreCounter = 0;

            while (varCollisionDetection == false) //always true now
            {
                gameLoop.playerPosition = gameLoop.playerMovement(gameLoop.playerPosition);
                while (map1.map.Count <= map1.mapCapacity)
                {
                    char[] mapRow = new char[128];
                    var temp = map1.mapGeneration(mapRow, map1.leftBarrierIndex, playableAreaSize, map1.map, gameLoop.playerPosition, map1);
                    map1.map = temp.Item1;
                    map1.leftBarrierIndex = temp.Item2;
                    gameLoop.playerPosition = temp.Item3;
                }
                map1.printMap(map1.map, gameLoop);
                map1.map.RemoveAt(0);
                varCollisionDetection = gameLoop.collisionDetection(gameLoop.playerPosition, map1.map);
                scoreCounter++;
                Thread.Sleep(100);
            }
            gameLoop.endgame(scoreCounter, map1);
            
            Console.ReadKey();
        }
    }
}
