using System;

namespace HW1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void nRow(int[,] map)
        {
            Console.WriteLine("Zadej řádek, který chceš vypsat");
            int row = int.Parse(Console.ReadLine());
            for (int i = 0; i < map.GetLength(0) - 1; i++) 
            {
                Console.WriteLine(map[i, row]);
            }
        }

        static void Main(string[] args)
        {
            int operationInt = 0;
            int fillCounter = 1;
            Console.WriteLine("Potřebuji vědět velikost tvé chtěnné matice. Zadej, kolik chceš mít rozměr X");
            int xLength = int.Parse(Console.ReadLine());
            Console.WriteLine("Nyní zadej rozměr Y");
            int yLength = int.Parse(Console.ReadLine());

            int[,] map = new int[xLength, yLength]; //souřadnice jsou "prohozeny" protože jinak by X bylo Y a a naopak

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = fillCounter;
                    fillCounter++;
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Nyni si vyber operaci. Zadej pouze číslo. " +
                "\n1 - vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow." +
                "\n2 - ");
            operationInt = int.Parse(Console.ReadLine());
            switch (operationInt)
            {
                case 1:
                    nRow(map);
                    break;
                default:
                    break;
            }

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;

            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.












            Console.ReadKey();
        }
    }
}