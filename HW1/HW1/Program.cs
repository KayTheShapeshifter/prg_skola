using System;
using System.Data.Common;

namespace HW1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void swapElement(int[,] map)
        {
            Console.WriteLine("Napiš X-ovou souřadnici prvního prvku.");
            int xFirst = int.Parse(Console.ReadLine());

            Console.WriteLine("Napiš Y-ovou souřadnici prvního prvku.");
            int yFirst = int.Parse(Console.ReadLine());

            Console.WriteLine("Napiš X-ovou souřadnici druhého prvku.");
            int xSecond = int.Parse(Console.ReadLine());

            Console.WriteLine("Napiš Y-ovou souřadnici druhého prvku.");
            int ySecond = int.Parse(Console.ReadLine());

            int temp = map[xFirst, yFirst];
            map[xFirst, yFirst] = map[xSecond, ySecond];
            map[xSecond, ySecond] = temp;

            for (int i = 0; i < map.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        static void swapRow(int[,] map)
        {
            Console.WriteLine("Napiš, první řádek, který chcete prohodit.");
            int nRowSwap = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Napiš, druhé řádek, který chcete prohodit.");
            int mRowSwap = int.Parse(Console.ReadLine()) - 1;

            for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
            {
                int temp = map[nRowSwap, j];
                map[nRowSwap, j] = map[mRowSwap, j];
                map[mRowSwap, j] = temp;
            }

            for (int i = 0; i < map.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        static void swapCollumn(int[,] map)
        {
            Console.WriteLine("Napiš, první sloupec, který chcete prohodit.");
            int nColSwap = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Napiš, dlouhý sloupec, který chcete prohodit.");
            int mColSwap = int.Parse(Console.ReadLine()) - 1;

            for (int i = 0; i < map.GetLength(1); i++) //pres sloupce
            {
                int temp = map[i, nColSwap];
                map[i, nColSwap] = map[i, mColSwap];
                map[i, mColSwap] = temp;
            }

            for (int i = 0; i < map.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();

        }
        static void swapDiagonal(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0) / 2; i++) //pres radky/sloupce, je to jedno
            {
                int temp = map[i, i];
                int coordToSwap = map.GetLength(0) - 1 - i;
                map[i, i] = map[coordToSwap, coordToSwap];
                map[coordToSwap, coordToSwap] = temp;
            }

            for (int i = 0; i < map.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        static void swapAntidiagonal(int[,] map) 
        {
            for (int i = map.GetLength(0) - 1; i > map.GetLength(0) / 2; i--) //pres radky/sloupce, je to jedno
            {
                int j = map.GetLength(0) - 1 - i;
                int temp = map[i, j];
                map[i, j] = map[j, i];
                map[j, i] = temp;
            }

            for (int i = 0; i < map.GetLength(0); i++) //pres radky
            {
                for (int j = 0; j < map.GetLength(1); j++) //pres sloupce
                {
                    Console.Write($"{map[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        static int[,] mapGeneration(int operationInt)
        {
            int[,] map = new int[1, 1];
            int fillCounter = 1;
            switch (operationInt)
            {
                case 1:
                    Console.WriteLine("Potřebuji vědět velikost tvé chtěnné matice. Zadej, kolik chceš mít rozměr X");
                    int xLength = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nyní zadej rozměr Y");
                    int yLength = int.Parse(Console.ReadLine());

                    map = new int[xLength, yLength];

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
                    break;
                case 2:
                    string file = "input.in";
                    // Čtení ze souboru
                    string mapSizeString = File.ReadLines(file).First();
                    string secondLine = File.ReadLines(file).Skip(1).First();


                    string[] dimensions = mapSizeString.Split(' ');

                    // Parsování délky a výšky
                    int length = int.Parse(dimensions[0]);
                    int height = int.Parse(dimensions[1]);

                    // Vytvoření pole o dané délce a výšce
                    map = new int[length, height];

                    Console.WriteLine("Pole o délce {0} a výšce {1} bylo vytvořeno.", length, height);
                    /*
                    string[] startCoordinates = secondLine.Split(' ');

                    int Sx = int.Parse(startCoordinates[0]);
                    int Sy = int.Parse(startCoordinates[1]);
                    int Cx = int.Parse(startCoordinates[2]);
                    int Cy = int.Parse(startCoordinates[3]);
                    // Display Sx and Sy
                    Console.WriteLine("Sx " + Sx + ", Sy: " + Sy);
                    // Display Cx and Cy
                    Console.WriteLine("Cx: {0}, Cy: {1}", Cx, Cy);
                    */
                    for (int i = 0; i < length; i++)
                    {
                        string tempValues = File.ReadLines(file).Skip(i + 1).First(); // pokud budu implementovat i to z KSP tak je potřeba přepsat i+1 na i+2 (skopiju řádky v tom texťáku)
                        string[] valuesString = tempValues.Split(' ');
                        for (int j = 0; j < height; j++)
                        {
                            int value = int.Parse(valuesString[j]);

                            map[i, j] = value;
                            Console.Write(map[i, j] + " ");
                        }
                        // Filling the map with the value at the specified coordinates
                        Console.WriteLine();
                    }
                    break;
                // Displaying the map
                default:
                    break;
            }
            return map;
        }
        static void Main(string[] args)
        {
            int operationInt = 0;
            int mapGenerationInt = 0;


            Console.WriteLine("Chceš: " +
                "\n1 - vygenerovat pole podle tebou zadaných parametrů" +
                "\n2 - importovat pole z souboru s názvem input.in (na prvním řádku by měli být rozměry pole a na ostatních by měli být čísla, kterými má být naplněna na řádcích)"); 
            mapGenerationInt = int.Parse(Console.ReadLine());

            int[,] map = mapGeneration(mapGenerationInt);

            Console.WriteLine("Nyni si vyber operaci. Zadej pouze číslo. " +
                "\n1 - prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození" +
                "\n2 - prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození" +
                "\n3 - prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole" +
                "\n4 - otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení" +
                "\n5 - otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení" +
                "\n6" +
                "\n7" +
                "\n8");

            operationInt = int.Parse(Console.ReadLine());
            switch (operationInt)
            {
                case 1:
                    swapElement(map);
                    break;
                case 2:
                    swapRow(map);
                    break;
                case 3:
                    swapCollumn(map);
                    break;
                case 4:
                    swapDiagonal(map);
                    break;
                case 5:
                    swapAntidiagonal(map);
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}