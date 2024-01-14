using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class Map
    {
        public static char[] mapRow = new char[128]; //size of row
        public static int playableAreaSize = 16; //size of the "road"
        public int leftBarrierIndex = mapRow.Length / 2 - playableAreaSize / 2;
        public int mapCapacity = 20;
        public List<char[]> map = new List<char[]>();
        public Random random = new Random();
        public (List<char[]>, int, int) mapGeneration(char[] mapRow, int leftBarierIndex, int playableAreaSize, List<char[]> map, int playerPosition, Map map1)
        {
            Random random = new Random();
            int tempIndex = 0;
            int tempDirection = 0;
            if (leftBarierIndex == 1) //it could go off the map to the left if this wasnt here (if the border is so far left that the next step could make it go off it, then its prohibited to go left)
            {
                tempDirection = map1.random.Next(2, 4);
            }
            else if (leftBarierIndex == mapRow.Length - playableAreaSize - 2)
            {
                int tempPlaceholder = map1.random.Next(1, 3);
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
                tempDirection = map1.random.Next(1, 4);
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
        public void printMap(List<char[]> map)
        {
            Console.Clear();
            foreach (var tempMapRow in map)
            {
                for (int j = 0; j < tempMapRow.Length; j++)
                {
                    Console.Write(tempMapRow[j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

}
