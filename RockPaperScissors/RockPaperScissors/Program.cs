using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        static byte ReadTahClovek()
        {
            string tahString = Console.ReadLine();
            byte tah = Convert.ToByte(tahString);
            while (true)
            {
                if (tahString == "1" || tahString == "2" || tahString == "3")
                {
                    return tah;
                }
                else
                {
                    Console.WriteLine("nespravny vstup");
                    tah = Console.ReadLine();
                }
            }

        }
        static void Main(string[] args)
        {
            /*
             * Jednoduchy program na procviceni podminek a cyklu.
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem kamen-nuzky-papir.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy skore obou
             *
             * Opakuj tolikrat, kolik kol chces hrat:
             * {
             *      Dokud uzivatel nezada vstup spravne:
             *      {
             *          - nacitej vstup od uzivatele
             *      }
             *      
             *      - vygeneruj s pomoci rng.Next() nahodny vstup pocitace
             *      
             *      Pokud vyhral uzivatel:
             *      {
             *          - informuj uzivatele, ze vyhral kolo
             *          - zvys skore uzivateli o 1
             *      }
             *      Pokud vyhral pocitac:
             *      {
             *          - informuj uzivatele, ze prohral kolo
             *          - zvys skore pocitaci o 1
             *      }
             *      Pokud byla remiza:
             *      {
             *          - informuj uzivatele, ze doslo k remize
             *      }
             * }
             * 
             * - informuj uzivatele, jake mel skore on/a a pocitac a kdo vyhral.
             */
            int skoreClovek = 0;
            int skorePocitac = 0;
            int pocetKol = 0;
            int ChtenyPocetKol = 0;
            byte tahClovek;
            byte tahPocitac;

            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel
            Console.WriteLine("Vítám tě u kámen, nůžky, papír. Zadej 'kamen', 'nuzky' nebo 'papir'");
            tahClovek = ReadTahClovek();
            Console.WriteLine("Zvolil jsi" + tahClovek);



            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
        }
    }
}
