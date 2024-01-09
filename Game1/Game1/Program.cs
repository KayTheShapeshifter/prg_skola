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
        public static char[,] mapGeneration(char[,] map, int leftBarierIndex, int playableAreaSize)
        {
            Random random = new Random();
            for (int j = 0; j < map.GetLength(0); j++)
            {
                int tempIndex = 0;
                int tempDirection = 0;

                if (leftBarierIndex == 1)//it could go off the map to the left if this wasnt here (if the border is so far left that the next step could make it go off it, then its prohibited to go left)
                {
                    tempDirection = random.Next(2, 4);
                }
                else if (leftBarierIndex == map.GetLength(1) - 2)
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
                    tempDirection = random.Next(1,4);
                }

                switch (tempDirection)
                {
                    case 1: //left
                        leftBarierIndex --;
                        for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '/'; //border gen.
                        tempIndex++;
                        for (int i = 0; i < playableAreaSize; i++) //road gen
                        {
                            map[j, tempIndex] = ' ';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '/'; //border gen
                        tempIndex++;
                        for (int i = 0; i < map.GetLength(1) - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        break;
                    case 2: //right
                        leftBarierIndex++;
                        for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '\\'; //border gen.
                        tempIndex++;
                        for (int i = 0; i < playableAreaSize; i++) //road gen
                        {
                            map[j, tempIndex] = ' ';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '\\'; //border gen
                        tempIndex++;
                        for (int i = 0; i < map.GetLength(1) - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        break;
                    default://center
                        for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '│'; //border gen.
                        tempIndex++;
                        for (int i = 0; i < playableAreaSize; i++) //road gen
                        {
                            map[j, tempIndex] = ' ';
                            tempIndex++;
                        }
                        map[j, tempIndex] = '│'; //border gen
                        tempIndex++;
                        for (int i = 0; i < map.GetLength(1) - (leftBarierIndex + playableAreaSize + 1); i++) //right grass gen
                        {
                            map[j, tempIndex] = '#';
                            tempIndex++;
                        }
                        break;
                }
            }
            return map;
        }
        public static void printMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            char[,] map = new char[1000, 128];
            int playableAreaSize = 16; //size of the "road"
            int InitleftBarierIndex = map.GetLength(1) / 2 - playableAreaSize / 2;

            map = mapGeneration(map, InitleftBarierIndex, playableAreaSize);
            printMap(map);
            Console.ReadKey();
        }
    }
}
