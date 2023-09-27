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
        static string ReadOperation()
        {
            string operace = Console.ReadLine();
            while (true)
            {
                if (operace == "soucet" || "rozdil" || "nasobeni" || deleni)
                {
                    return operace;
                }
                else
                {
                    //vynadej uzivateli
                    operace = Console.ReadLine();
                }
            }

        }

        static void Main(string[] args)
        {
            /*
             * Pokud se budes chtit na neco zeptat a zrovna budu pomahat jinde, zkus se zeptat ChatGPT ;) - https://chat.openai.com/
             * 
             * ZADANI
             * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
             * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
             * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
             * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
             * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
             * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
             * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
             *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
             * 7) Vypis promennou result do konzole
             * 
             * Mozna rozsireni programu pro rychliky / na doma (na poradi nezalezi):
             * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces
             * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
             * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
             *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
             * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
             */

            double num1;
            double num2;
            double result = 0;
            string input1;
            string input2;
            string operace;
            string typ;

            Console.WriteLine("Zadej, zda li chceš aby se program při špatném vstupu a) ukončil b) četl do té doby, dokud uživatel nezadá správný imput. Zadej 'a' nebo 'b'.");
            typ = Console.ReadLine();
            
            if (typ != "a" & typ != "b")
            {
                Console.WriteLine("Chyba: Musíte zadat platný vstup.");
                Console.ReadKey();
                Environment.Exit(1); //vypne program
            }

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
            Console.WriteLine("Druhé číslo je " + input2 + ", nyní vyber operaci (soucet, rozdil, nasobeni, deleni)");

            operace = ReadOperation();
            
            if (operace == "soucet")
            {
                result = num1 + num2;
            }
            else if (operace == "rozdil")
            {
                result = num1 - num2;
            }
            else if (operace == "nasobeni")
            {
                result = num1 * num2;
            }
            else if (operace == "deleni")
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Chyba: Nelze dělit nulou.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
               
            }

            else while (operace != ReadOperation())
                {
                    if (typ == "a")
                    {
                        Console.WriteLine("Chyba: Neplatná operace.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else if (typ == "b") //zopakuje proces jako předtim pokud je zadanej blbej imput a typ == b, nevim jak to zkratit aby se to neopakovalo
                    {
                        Console.WriteLine("Chyba: Musíte zadat platnou operaci");
                        Console.WriteLine("Zadej operaci znovu:");
                        operace = Console.ReadLine();

                        if (operace == "soucet")
                        {
                            result = num1 + num2;
                        }
                        else if (operace == "rozdil")
                        {
                            result = num1 - num2;
                        }
                        else if (operace == "nasobeni")
                        {
                            result = num1 * num2;
                        }
                        else if (operace == "deleni")
                        {
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                            }
                            else
                            {
                                Console.WriteLine("Chyba: Nelze dělit nulou.");
                                Console.ReadKey();
                                Environment.Exit(1);
                            }
                        }
                    }
                }

            Console.WriteLine("výsledek je " + result);

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
            // credit: chatgpt za try parse (předtím byla funkce convert.toint, ale ta necheckovala jestli zkutecne zadal cislo)
        }
    }
}
