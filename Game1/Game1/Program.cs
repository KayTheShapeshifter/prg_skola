using System;
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
            int tempDirection = random.Next(1, 1); //change
            switch (tempDirection)
            {
                case 1: //left
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        int tempIndex = 0;
                        for (int i = 0; i < leftBarierIndex - 1; i++) //left grass generation
                        {
                            map[tempIndex, j] = '#';
                            tempIndex++;
                        }
                        map[tempIndex, j] = '/'; //border gen.
                        tempIndex++;
                        for (int i = 0; i < playableAreaSize; i++) //road gen
                        {
                            map[tempIndex, j] = ' ';
                            tempIndex++;
                        }
                        map[tempIndex, j] = '/'; //border gen
                        tempIndex++;
                        for (int i = 0; i < map.GetLength(0) - tempIndex; i++) //right grass gen
                        {
                            map[tempIndex, j] = '#';
                            tempIndex++;
                        }
                    }

                    break;
                case 2: //right
                    break;
                case 3: //center
                    break;
                default:
                    break;
            }
            return map;
        }
        public static void printMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            char[,] map = new char[32, 6];
            int playableAreaSize = 8; //size of the "road"
            int leftBarierIndex = (map.GetLength(0) - playableAreaSize) / 2;

            map = mapGeneration(map, leftBarierIndex, playableAreaSize);
            printMap(map);
            Console.ReadKey();
        }
    }
}
