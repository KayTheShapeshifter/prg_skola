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
            Map map1 = new Map();
            //List<char[]> map = new List<char[]>(mapCapacity);
            bool varCollisionDetection = false;
            GameLoop gameLoop = new GameLoop();

            while (varCollisionDetection == false) //always true now
            {
                gameLoop.playerPosition = gameLoop.runGame(gameLoop.playerPosition);
                while (map1.map.Count <= map1.mapCapacity)
                {
                    char[] map_Row = new char[128];
                    var temp = map1.mapGeneration(map_Row, map1.leftBarrierIndex, playableAreaSize, map1.map, gameLoop.playerPosition, map1);
                    map1.map = temp.Item1;
                    map1.leftBarrierIndex = temp.Item2;
                    gameLoop.playerPosition = temp.Item3;
                    //(map1.map, map1.leftBarrierIndex, playerPosition)
                }
                map1.printMap(map1.map, gameLoop);
                map1.map.RemoveAt(0);
                varCollisionDetection = gameLoop.collisionDetection(gameLoop.playerPosition, map1.map) ;
                Thread.Sleep(100);
            }

            GameLoop.rickroll(); //haha git gud

            Console.ReadKey();
        }
    }
}
