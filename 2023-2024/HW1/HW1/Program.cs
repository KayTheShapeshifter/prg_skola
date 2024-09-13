using System;
using System.Data.Common;

namespace HW1
{
    internal class Program
    {
        static int stepsIntMax = 2;
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };
        static List<(int, int)> pathMax = new List<(int, int)>();
        static void KSPtask(int[,] map) //Zdroje, které jsem použil na vytvoření této, findLongestPath a findLongestPathDown jsou chatgpt, geeksforgeeks, můj bratr
        {
            Console.WriteLine("Zadej X-ovou souřadnici začátku");
            int Sx = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadej Y-ovou souřadnici začátku");
            int Sy = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadej X-ovou souřadnici konce");
            int Cx = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadej Y-ovou souřadnici konce");
            int Cy = int.Parse(Console.ReadLine());
            //inicializace startovních a koncových bodů

            List<(int, int)> endpoints = new List<(int, int)>();
            Dictionary<(int, int), int> steps = new Dictionary<(int, int), int>();
            Dictionary<(int, int), List<(int, int)>> stepCoordinates = new Dictionary<(int, int), List<(int, int)>>();
            List<(int, int)> prevPath = new List<(int, int)>();
            List<(int, int)> path = new List<(int, int)>();

            FindLongestPath(map, Sx, Sy, endpoints, steps, 0, stepCoordinates, prevPath);

            foreach (var endpoint in endpoints)
            {
                FindLongestPathDown(map, endpoint.Item1, endpoint.Item2, 0, path, prevPath, Cx, Cy);
            }
            for (int i = 0; i < pathMax.Count; i++)
            {
                Console.WriteLine(pathMax[i].Item1 + " " + pathMax[i].Item2);
            }
            Console.WriteLine("Steps: " + (stepsIntMax+2) );//+ 2 protože to nepočítá první a posleldní krok
        }
        static void FindLongestPathDown(int[,] map, int Sx, int Sy, int stepsInt, List<(int, int)> path, List<(int, int)> prevPath, int Cx, int Cy)
        {
            bool hasLowerValueNeighbor = false;

            List<(int, int)> currentPath = new List<(int, int)>();
            if (prevPath.Count > 0)
            {
                foreach (var element in prevPath)
                {
                    currentPath.Add(element);
                }
            }
            currentPath.Add((Sx, Sy));

            for (int i = 0; i < 4; i++)
            {
                int newX = Sx + dx[i];
                int newY = Sy + dy[i];
                if (newX >= 0 && newY >= 0 && newX < map.GetLength(0) && newY < map.GetLength(1))
                {
                    if (Cx == Sx && Cy == Sy)
                    {
                        if (stepsInt > stepsIntMax)
                        {
                            pathMax = currentPath;
                            stepsIntMax = stepsInt;
                        }// Store the entire path

                        return;
                    }
                    int newValue = map[newY, newX];
                    int oldValue = map[Sy, Sx];
                    if (newValue < oldValue)
                    {
                        hasLowerValueNeighbor = true;
                        // Add the current coordinates to the current path

                        FindLongestPathDown(map, newX, newY, stepsInt + 1, path, currentPath, Cx, Cy);
                        if (stepsInt + 1 > map.Length)
                        {
                            Console.WriteLine("Something is fucky");
                        }
                    }
                }
            }
            if (hasLowerValueNeighbor != true)
            {
                return;
            }

        }
        static void FindLongestPath(int[,] map, int Sx, int Sy, List<(int, int)> endpoints, Dictionary<(int, int), int> steps, int stepsInt, Dictionary<(int, int), List<(int, int)>> stepCoordinates, List<(int, int)> prevPath)
        {
            bool hasHigherValueNeighbor = false;

            List<(int, int)> currentPath = new List<(int, int)>();
            if (prevPath.Count > 0)
            {
                foreach (var element in prevPath)
                {
                    currentPath.Add(element);
                }
            }
            currentPath.Add((Sx, Sy));
            for (int i = 0; i < 4; i++) //iteruju přes všechny č možné směry
            {
                int newX = Sx + dx[i]; // Sx a Sy jsou v tomto kontextu startovní body poslední iterace
                int newY = Sy + dy[i];
                if (newX >= 0 && newY >= 0 && newX < map.GetLength(0) && newY < map.GetLength(1))
                {
                    int newValue = map[newY, newX];
                    int oldValue = map[Sy, Sx];
                    if (newValue > oldValue)
                    {
                        hasHigherValueNeighbor = true;
                        // Add the current coordinates to the current path

                        FindLongestPath(map, newX, newY, endpoints, steps, stepsInt + 1, stepCoordinates, currentPath);
                    }
                }
            }
            if (!hasHigherValueNeighbor)
            {
                if (!endpoints.Contains((Sx, Sy)))
                {
                    endpoints.Add((Sx, Sy));
                    steps[(Sx, Sy)] = stepsInt;
                    // Store the entire path to this endpoint in the dictionary
                    stepCoordinates[(Sx, Sy)] = new List<(int, int)>(currentPath);
                }
                else if (steps[(Sx, Sy)] < stepsInt)
                {
                    steps[(Sx, Sy)] = stepsInt;
                    stepCoordinates[(Sx, Sy)] = new List<(int, int)>(currentPath);
                }
            }
        }
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
            writeArrayIntoConsole(map);
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
            writeArrayIntoConsole(map);
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
            writeArrayIntoConsole(map);
        }
        static void swapDiagonal(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0) / 2; i++) //lomeno 2 protože bych prohodil diagonálu spátky, kdyby to tam nebylo (nakonec by vypadala jako na začátku)
            {
                int temp = map[i, i];
                int coordToSwap = map.GetLength(0) - 1 - i; // iteruju tímhle přes diagonálu
                map[i, i] = map[coordToSwap, coordToSwap];
                map[coordToSwap, coordToSwap] = temp;
            }
            writeArrayIntoConsole(map);
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
            writeArrayIntoConsole(map);
        }
        static void arrayNumberMultiplication(int[,] map)
        {
            Console.WriteLine("Jakým číslem chceš matici vynásobit?");
            int multiplicationNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Chceš:" +
                "\n1 - vynásobit matici celou" +
                "\n2 - vynásobit pouze řádek" +
                "\n3 - vynásobit pouze sloupec");
                int operationType = int.Parse(Console.ReadLine());

            switch (operationType)
            {
                case 1:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            map[i, j] = map[i, j] * multiplicationNumber;
                        }
                    }
                    break; 
                case 2:
                    Console.WriteLine("Kolikátý řádek chceš vynásobit?");
                    int nRow = int.Parse(Console.ReadLine()) - 1;
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        map[nRow, i] = map[nRow, i] * multiplicationNumber;
                    }
                    break;
                case 3:
                    Console.WriteLine("Kolikátý sloupec chceš vynásobit?");
                    int nCollumn = int.Parse(Console.ReadLine()) - 1;
                    for (int j = 0; j < map.GetLength(0); j++)
                    {
                        map[nCollumn, j] = map[nCollumn, j] * multiplicationNumber;
                    }
                    break;
                default:
                    break;
            }
            writeArrayIntoConsole(map);
        }
        static void writeArrayIntoConsole(int[,] map) //z array playground
        {
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
        static int[,] mapGeneration()
        {
            int[,] map = new int[1, 1]; 
            Console.WriteLine("Chceš: " +
                "\n1 - vygenerovat pole podle tebou zadaných parametrů" +
                "\n2 - importovat pole z souboru s názvem input.in (na prvním řádku by měli být rozměry pole a na ostatních by měli být čísla, kterými má být naplněna na řádcích)");
            int mapGenerationInt = int.Parse(Console.ReadLine());
            
            switch (mapGenerationInt)
            {
                case 1:
                    int fillCounter = 1;
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
                case 2: //castecne geeksforgeeks a dalsi ruzny stranky a castecne chatgpt
                    string file = "input.in";
                    // Čtení ze souboru
                    string mapSizeString = File.ReadLines(file).First();
                    //string secondLine = File.ReadLines(file).Skip(1).First();


                    string[] dimensions = mapSizeString.Split(' ');

                    // Parsování délky a výšky
                    int length = int.Parse(dimensions[0]);
                    int height = int.Parse(dimensions[1]);

                    // Vytvoření pole o dané délce a výšce
                    map = new int[length, height];

                    Console.WriteLine("Pole o délce {0} a výšce {1} bylo vytvořeno.", length, height);

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
        static void arrayAdditionSubtraction(int[,] map) 
        {
            Console.WriteLine("Nyní potřebuji, abys vygeneroval druhou matici. Rozměry musí být stejné jako u první");
            int[,]map2 = mapGeneration();
            Console.WriteLine("Chceš: " +
                "\n1 - sčítat" +
                "\n2 - odečítat");
            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            map[i, j] = map[i, j] + map2[i, j];
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            map[i, j] = map[i, j] - map2[i, j];
                        }
                    }
                    break;
                default:
                    break;
            }
            writeArrayIntoConsole(map);
        }
        static void transposition(int[,] originalMap) 
        {
            int[,] map = new int[originalMap.GetLength(1), originalMap.GetLength(0)];
            for (int i = 0; i < originalMap.GetLength(0); i++)
            {
                for (int j = 0; j < originalMap.GetLength(1); j++)
                {
                    map[j, i] = originalMap[i, j];
                }
            }
            writeArrayIntoConsole(map);
        }
        static void arrayMultiplication(int[,] originalMap) //to do
        {

        }
        static void Main(string[] args)
        {
            int[,] map = mapGeneration();

            Console.WriteLine("Nyni si vyber operaci. Zadej pouze číslo. " +
                "\n1 - prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození" +
                "\n2 - prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození" +
                "\n3 - prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole" +
                "\n4 - otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení" +
                "\n5 - otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení" +
                "\n6 - vynásob prvky v matici číslem" +
                "\n7 - sčítání / odečítání matic" +
                "\n8 - transpozice podle hlavní diagonály" +
                "\n9 - násobení matice maticí (ještě nenaimplementováno)" +
                "\n10 - udělej úkol z KSP 36-1-3 výšlap. https://ksp.mff.cuni.cz/h/ulohy/36/zadani1.html#task-36-1-3");

            int operationInt = int.Parse(Console.ReadLine());
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
                case 6:
                    arrayNumberMultiplication(map);
                    break;
                case 7:
                    arrayAdditionSubtraction(map);
                    break;
                case 8:
                    transposition(map);
                    break;
                case 9:
                    arrayMultiplication(map); //to do
                    break;
                case 10:
                    KSPtask(map);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}