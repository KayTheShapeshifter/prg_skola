using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            string result = "0";
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == null)
                {
                    userInput = result;
                }
                Freetype freetype = new Freetype();
                result = freetype.CalcMain(userInput);
                Console.WriteLine(result);

            }
            
        }
    }
}