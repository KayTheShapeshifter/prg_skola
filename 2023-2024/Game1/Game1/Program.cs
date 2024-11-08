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
            int speed;

            for (int i = 0; i < map1.mapCapacity; i++) //this section generates the initial section of the map so that the player doesnt start out of nowhere
            {
                char[] mapRow = new char[mapRowSize];
                var temp = map1.initMapGeneration(mapRow, map1.leftBarrierIndex, playableAreaSize, map1.map);
                map1.map = temp.Item1;
                map1.leftBarrierIndex = temp.Item2;
            }
            map1.printMap(map1.map, map1);

            while (varCollisionDetection == false) //always true now
            {
                (map1.playerPosition, map1.playerDirection) = gameLoop.playerMovement(map1.playerPosition, map1.playerDirection);
                while (map1.map.Count <= map1.mapCapacity)
                {
                    char[] mapRow = new char[mapRowSize];
                    var temp = map1.mapGeneration(mapRow, map1.leftBarrierIndex, playableAreaSize, map1.map, map1);
                    map1.map = temp.Item1;
                    map1.leftBarrierIndex = temp.Item2;
                }
                map1.printNewRow(map1.map, map1, scoreCounter);
                map1.map.RemoveAt(0);
                varCollisionDetection = gameLoop.collisionDetection(map1.playerPosition, map1.map);
                scoreCounter++;
                speed = gameLoop.IncreaseDifficulty(scoreCounter);
                Thread.Sleep(speed);
            }
            gameLoop.endgame(scoreCounter, map1);
            
            Console.ReadKey();
        }
    }
}
