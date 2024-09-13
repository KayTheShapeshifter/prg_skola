using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.
            int[] intArray = {0, 1, 2, 3, 4,};

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            Console.WriteLine("výpis for cyklem");
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }

            Console.WriteLine("výpis foreach cyklem");
            foreach (int i in intArray)
            {
                Console.WriteLine(i);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            Console.WriteLine("soucet");
            int sum = 0;
            foreach (int i in intArray)
            {
                sum = sum + i;
            }
            Console.WriteLine(sum);

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            Console.WriteLine("prumer");
            int average = sum/ intArray.Length;
            Console.WriteLine(average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            Console.WriteLine("max");
            int max = intArray.Max();
            Console.WriteLine(max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            Console.WriteLine("min");
            int min = intArray.Min();
            Console.WriteLine(min);


            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            Console.WriteLine("kolikaty cislo chces vedet?");
            int number = int.Parse(Console.ReadLine());
            int index = Array.IndexOf(intArray, number);
            if (index == -1)
            {
                Console.WriteLine("prvek v poli neexistuje");
            }
            else
            {
                Console.WriteLine("index je: " + index);
            }

            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random rng = new Random();
            intArray = new int[100];
            for (int i = 0; i < 100; i++)
            {
                intArray[i] = rng.Next(0,10);
                Console.WriteLine("prvek pole je " + intArray[i]);
            }


            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];

            foreach (int num in intArray)
            {
                counts[num]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine("cislo " + i + "je " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] reversedArray = new int[intArray.Length];
            for (int i = reversedArray.Length - 1; i < -1; i--)
            {
                reversedArray[i] = intArray[99 - i];
                Console.WriteLine("prvek obraceneho pole je " + reversedArray[i]);
            }


            Console.ReadKey();
        }
    }
}
