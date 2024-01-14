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
        public static char[] mapRow = new char[128]; //size of row
        public static int playableAreaSize = 16; //size of the "road"
        public static int InitleftBarierIndex = mapRow.Length / 2 - playableAreaSize / 2;
        public static int mapCapacity = 20;
        public static (List<char[]>, int, int) mapGeneration(char[] mapRow, int leftBarierIndex, int playableAreaSize, List<char[]> map,int playerPosition)
        {
            Random random = new Random();
            int tempIndex = 0;
            int tempDirection = 0;
            if (leftBarierIndex == 1) //it could go off the map to the left if this wasnt here (if the border is so far left that the next step could make it go off it, then its prohibited to go left)
            {
                tempDirection = random.Next(2, 4);
            }
            else if (leftBarierIndex == mapRow.Length - playableAreaSize - 2)
            {
                int tempPlaceholder = random.Next(1, 3);
                if (tempPlaceholder == 1)
                {
                    tempDirection = 1;
                }
                else
                {
                    tempDirection = 3;
                }
            }
            else
            {
                tempDirection = random.Next(1, 4);
            }

            switch (tempDirection)
            {
                case 1: //left
                    leftBarierIndex--;
                    for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '/'; //border gen.
                    tempIndex++;
                    for (int i = 0; i < playableAreaSize; i++) //road gen
                    {
                        mapRow[tempIndex] = ' ';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '/'; //border gen
                    tempIndex++;
                    for (int i = 0; i < mapRow.Length - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    playerPosition--;
                    break;
                case 2: //right
                    leftBarierIndex++;
                    for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '\\'; //border gen.
                    tempIndex++;
                    for (int i = 0; i < playableAreaSize; i++) //road gen
                    {
                        mapRow[tempIndex] = ' ';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '\\'; //border gen
                    tempIndex++;
                    for (int i = 0; i < mapRow.Length - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    playerPosition++;
                    break;
                default://center
                    for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '│'; //border gen.
                    tempIndex++;
                    for (int i = 0; i < playableAreaSize; i++) //road gen
                    {
                        mapRow[tempIndex] = ' ';
                        tempIndex++;
                    }
                    mapRow[tempIndex] = '│'; //border gen
                    tempIndex++;
                    for (int i = 0; i < mapRow.Length - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                    {
                        mapRow[tempIndex] = '#';
                        tempIndex++;
                    }
                    break;
            }
            map.Add(mapRow);
            return (map, leftBarierIndex, playerPosition);
        }
        public static void printMap(List<char[]> map)
        {
            foreach (var tempMapRow in map)
            {
                for (int j = 0; j < tempMapRow.Length; j++)
                {
                    Console.Write(tempMapRow[j]);
                }
                Console.WriteLine();
            }
        }
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
            List<char[]> map = new List<char[]>(mapCapacity);
            bool varCollisionDetection = false;

            while (varCollisionDetection == false) //always true now
            {
                while (map.Count <= mapCapacity)
                {
                    (map, InitleftBarierIndex, playerPosition) = mapGeneration(mapRow, InitleftBarierIndex, playableAreaSize, map, playerPosition);
                }
                printMap(map);
                varCollisionDetection = collisionDetection(playerPosition, map) ;
            }
            Console.ReadKey();
        }
    }
}
