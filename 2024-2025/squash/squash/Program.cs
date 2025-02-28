using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace squash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please make the application full screen for the app to work properly");
            Console.ReadKey();
            Map mapClass = new Map();
            char[,] map = mapClass.CreateMap(96, 24);
            mapClass.PrintMap(map);
            

        }
    }
}