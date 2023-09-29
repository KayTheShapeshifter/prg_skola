using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static string ReadOperation(string typ)
        {
            string operace = Console.ReadLine();
            while (true)
            {
                if (operace == "soucet" || operace == "rozdil" || operace == "nasobeni" || operace == "deleni" || operace == "mocnina" || operace == "odmocnina" || operace == "logaritmus")
                {
                    return operace;
                }
                else
                {
                    if (typ == "a")
                    {

                        Console.WriteLine("Chyba: Musíte zadat platnou operaci.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    Console.WriteLine("Špatný input, zadej operaci znovu");
                    operace = Console.ReadLine();
                }
            }
        }
        static double Calculate(double num1, double num2, string operace) //credit: chatgpt za default a convertnuti else ifů do switche
        {
            switch (operace)
            {
                case "soucet":
                    return num1 + num2;
                case "rozdil":
                    return num1 - num2;
                case "nasobeni":
                    return num1 * num2;
                case "deleni":
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Chyba: Nelze dělit nulou.");
                        Console.ReadKey();
                        Environment.Exit(1);
                        return 0;
                    }
                case "mocnina":
                    return Math.Pow(num1, num2);
                case "odmocnina":
                    return Math.Pow(num1, 1 / num2);
                case "logaritmus":
                    return Math.Log(num1, num2);
                default:
                    Console.WriteLine("Chyba: Neplatná operace.");
                    return 0; // to return 0 tady je, protoze jinak by to hodilo bug ze ne vzdy to da nejaky cislo, jinak je to useless protoze u operace to uz vyhodi vsechny pripady kde operace neni zadna z naprogramovanejch
            }
        }

        static void Main(string[] args)
        {
            double num1;
            double num2;
            double result;
            string input1;
            string input2;
            string operace;
            string typ;
            string opakovani;

            Console.WriteLine("Zadej, zda li chceš aby se program při špatném vstupu:\na) ukončil \nb) četl do té doby, dokud uživatel nezadá správný imput \nZadej 'a' nebo 'b'.");
            typ = Console.ReadLine();
            
            if (typ != "a" & typ != "b")
            {
                Console.WriteLine("Chyba: Musíte zadat platný vstup.");
                Console.ReadKey();
                Environment.Exit(1); //vypne program
            }
            do
            {
                Console.WriteLine("Zadej první číslo");
                input1 = Console.ReadLine();

                while (!double.TryParse(input1, out num1)) //prvni while fce byli od chatgpt, poté jsem si je upravil já
                {
                    if (typ == "a")
                    {
                        Console.WriteLine("Chyba: Musíte zadat platné číslo pro první vstup.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else if (typ == "b")
                    {
                        Console.WriteLine("Chyba: Musíte zadat platné číslo pro první vstup.");
                        Console.WriteLine("Zadej první číslo znovu:");
                        input1 = Console.ReadLine();
                    }
                }

                Console.WriteLine("První číslo je " + input1 + ", nyní zadej druhé");

                input2 = Console.ReadLine();
                while (!double.TryParse(input2, out num2))
                {
                    if (typ == "a")
                    {
                        Console.WriteLine("Chyba: Musíte zadat platné číslo pro druhý vstup.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else if (typ == "b")

                    {
                        Console.WriteLine("Chyba: Musíte zadat platné číslo pro druhý vstup.");
                        Console.WriteLine("Zadej druhé číslo znovu:");
                        input2 = Console.ReadLine();
                    }
                }

                Console.WriteLine("Druhé číslo je " + input2 + ", nyní vyber jednu z operací:\nsoucet, rozdil, nasobeni, deleni, mocnina, odmocnina, logaritmus");
                operace = ReadOperation(typ);

                result = Calculate(num1, num2, operace);
                Console.WriteLine("Výsledek je " + result + ".");

                Console.WriteLine("Přeješ si udělat nový výpočet? zadej \"ano\" pokuď chceš. Pokuď ne stiskni 2x enter a program se ukončí");
                opakovani = Console.ReadLine();

            } while (opakovani == "ano");
           
            Console.ReadKey();
        }

    }
}
