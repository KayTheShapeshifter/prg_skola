using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal  class Map
    {
        public char[,] map = new char[64,30];
        public int leftBarierIndex;
        public int rightBarierIndex;
        public int playabeAreaSize; //size of the "road"
        public void mapGeneration()
        {
            Random random = new Random();
            int tempDirection = random.Next(1,3);
            switch (tempDirection)
            {
                case 1: //left
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        int tempIndex = 0;
                        for (int i = tempIndex; i < leftBarierIndex - 1; i++) //left grass generation
                        {
                            map[tempIndex, 1] = '#';
                            tempIndex++;
                        }
                        map[tempIndex, 1] = '/'; //border gen.
                        for (int i = 0; i < playabeAreaSize; i++) //road gen
                        {
                            map[tempIndex, 1] = ' ';
                            tempIndex++;
                        }
                        map[tempIndex, 1] = '/'; //border gen
                        tempIndex++;
                        for (int i = 0; i < map.GetLength(0) - tempIndex; i++) //right grass gen
                        {
                            map[tempIndex, 1] = '#';
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
        }
        public void printMap()
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
    }
}
