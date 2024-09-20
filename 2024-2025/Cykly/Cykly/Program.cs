using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cykly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int a;
            Thread.Sleep(1000);
            do
            {
                a = rnd.Next(1, 100);
                if (a > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (a > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine(a);
                Thread.Sleep(100);
            } while (a != 1);
            
            
            Console.ReadKey();
        }
    }
}
