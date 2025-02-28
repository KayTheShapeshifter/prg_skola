using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squash
{
    internal class Map
    {
        public char[,] CreateMap(int width, int height)
        {
            char[,] map = new char[height, width];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = ' ';
                }
            }
            for (int i = 0; i < map.GetLength(0); i++)
            {
                map[i, map.GetLength(1) - 1] = '|';

            }
            for (int i = 0; i < map.GetLength(1); i++)
            {
                map[0, i] = '-';
                map[map.GetLength(0) - 1, i] = '-';
            }
            for (int i = 0; i < 6; i++)
            {
                map[0, map.GetLength(1) - 1 - i] = '#';
                map[map.GetLength(0) - 1, map.GetLength(1) - 1 - i] = '#';
                map[i, map.GetLength(1) - 1] = '#';
                map[map.GetLength(0) - 1 - i, map.GetLength(1) - 1] = '#';
            }


            return map;
        }
        public void PrintMap(char[,] map)
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
    }
}
