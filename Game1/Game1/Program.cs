using System;
using System.Collections;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class Program
    {
        public static int mapRowSize = 128;
        public static char[] mapRow = new char[128]; //size of row
        public static int playableAreaSize = 16; //size of the "road"
        public static bool collisionDetection(int playerPosition, List<char[]> map)
        {
            bool collisionDetection = false;
            return collisionDetection;
            char[] mapRow = map[0];
            if (mapRow[playerPosition] == '/' || mapRow[playerPosition] == '│' || mapRow[playerPosition] == '\\')
            {
                
            }
        }
        static void Main(string[] args)
        {
            int playerPosition = mapRow.Length / 2;
            //List<char[]> map = new List<char[]>(mapCapacity);
            bool varCollisionDetection = false;
            Map map1 = new Map();
 
            while (varCollisionDetection == false) //always true now
            {
                while (map1.map.Count <= map1.mapCapacity)
                {
                    char[] map_Row = new char[128];
                    var temp = map1.mapGeneration(map_Row, map1.leftBarrierIndex, playableAreaSize, map1.map, playerPosition, map1);
                    map1.map = temp.Item1;
                    map1.leftBarrierIndex = temp.Item2;
                    playerPosition = temp.Item3;
                    //(map1.map, map1.leftBarrierIndex, playerPosition)
                }
                map1.printMap(map1.map);
                map1.map.RemoveAt(0);
                varCollisionDetection = collisionDetection(playerPosition, map1.map) ;
            }
            Console.ReadKey();
        }
    }
}
