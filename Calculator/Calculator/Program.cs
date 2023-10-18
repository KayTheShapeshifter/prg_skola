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

        static string prevodSoustavOperation (double result, string typ) //credit chatgpt za prakticky vsechno tady
        {
            int cisloSoustavy;

            Console.WriteLine("Do jaké číselné soustavy chceš převést? \nFungují soustavy od 2 do 36. Napiš pouze číslo. \nNefunguje u velice velkých čísel z důvodu limitací INTu");

            string inputCisloSoustavy = Console.ReadLine();

            while (!int.TryParse(inputCisloSoustavy, out cisloSoustavy) || cisloSoustavy > 36 || cisloSoustavy < 2) //limituje to ty bases jen na funkcni (2-36)
            {
                if (typ == "a")
                {
                    Console.WriteLine("Chyba: Musíš zadat platné číslo soustavy.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Chyba: Musíš zadat platné číslo soustavy.");
                    Console.WriteLine("Zadej druhé číslo znovu:");
                    inputCisloSoustavy = Console.ReadLine();
                }
            }
            long celaCastVysledku = (int)result; //konvertuje vysledek na int
            double desetinnaCastVysledkuDbl = result - celaCastVysledku; //konvertuje desetinnou cast vysledku na double

            StringBuilder resultBuilder = new StringBuilder();

            while (celaCastVysledku > 0)
            {
                long digit = celaCastVysledku % cisloSoustavy;
                char digitChar = (char)((digit < 10) ? ('0' + digit) : ('A' + digit - 10));
                resultBuilder.Insert(0, digitChar);
                celaCastVysledku /= cisloSoustavy;
            }

            if (desetinnaCastVysledkuDbl > 0)
            {
                resultBuilder.Append("."); // Add the decimal point for fractional part.

                for (int i = 0; i < 16; i++) // tady se da upravit, kolik destetinnych mist chci aby to umelo
                {
                    desetinnaCastVysledkuDbl *= cisloSoustavy;
                    int digit = (int)desetinnaCastVysledkuDbl;
                    char digitChar = (char)((digit < 10) ? ('0' + digit) : ('A' + digit - 10)); // pokud je znak, ktery to prave konvertuje mensi nez 10 tak to ukaze jako cislo, pokud je vetsi tak to ukaze jako pismeno reprezentujici to cislo v jinejch soustavach
                    resultBuilder.Append(digitChar);
                    desetinnaCastVysledkuDbl -= digit;
                }
            }
            return resultBuilder.ToString();
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
            string prevodSoustavy;
            string konvertovanyVysledek;

            Console.WriteLine("Zadej, zda li chceš aby se program při špatném vstupu:\na) ukončil \nb) četl do té doby, dokud uživatel nezadá správný imput \nZadej 'a' nebo 'b'.");
            typ = Console.ReadLine();
            
            if (typ != "a" & typ != "b")
            {
                Console.WriteLine("Chyba: Musíte zadat platný vstup.");
                Console.ReadKey();
                Environment.Exit(1); //vypne program
            }

            do //tohle do-while umoznuje nekolikrat opakovat vypocet
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

                Console.WriteLine("Přeješ si konvertovat výsledek do jiné číselné soustavy? Napiš \"ano\" pokud chceš, jinak odentruj.");
                prevodSoustavy = Console.ReadLine();

                if (prevodSoustavy == "ano") //logika pro konverzi
                {
                    konvertovanyVysledek = prevodSoustavOperation(result, typ);
                    Console.WriteLine(konvertovanyVysledek);
                }

                Console.WriteLine("Přeješ si udělat nový výpočet? zadej \"ano\" pokuď chceš. Pokuď ne stiskni 2x enter a program se ukončí");
                opakovani = Console.ReadLine();

            } while (opakovani == "ano");
           
            Console.ReadKey();
        }

    }
}
