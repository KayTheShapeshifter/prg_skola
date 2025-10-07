using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cyslo; //32bit signed
            byte bajt; //8bit unsigned
            sbyte signedBajt; //8bit signed
            short maleCyslo; //16   
            ushort maleCysloBezZnamenka; //16bit unsigned
            uint cyslo9; //32bit unsigned
            ulong cyslo10; //64bit unsigned
            float cyslo11 = 11f; //32bit floating point, 7ish desetinkých míst
            double řeřicha; //64bit floating point, 12ish desetinkých míst

            Console.WriteLine("Zadejte celé číslo: ");
            cyslo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Zadal jsi " + cyslo); 

            Console.WriteLine("Zadejte desetinne číslo: ");
            if (double.TryParse(Console.ReadLine(), out řeřicha))
            {
                //cyslo = Convert.ToInt32(řeřicha);
                Console.WriteLine("Zadal jsi " + řeřicha); 
            }

            řeřicha = Math.PI; //3.14159265358979323846
            Console.WriteLine(řeřicha); //3.1415926535897931
            řeřicha = Math.E; //2.71828182845904523536
            Console.WriteLine(řeřicha); //2.7182818284590451
            cyslo = int.MaxValue; //2147483647
            Console.WriteLine(cyslo); //2147483647
            cyslo = int.MinValue; //-2147483648
            Console.WriteLine(cyslo); //-2147483648

            //double.MaxValue; //1.7976931348623157E+308
            //double.MinValue; //-1.7976931348623157E+308
            Console.WriteLine("4 na druhou je " + Math.Sqrt(4)); 
            Console.WriteLine("Log10 z 100 je " + Math.Log10(100));
      





            /*chyby 
             * - preteceni 
             * - nepresnost floating point matematiky - jsou to jen estimace cisel - pracuji na principu toho, ze mam nejakou numerickou cast a tu pak vynasobim nejakym exponencialnim cislem, abych posunul desetinnou caru
             * - preteceni - pokud je hodnota mimo rozsah, tak se to pretece a dostanu spatne cislo - nasledne se muze stat, ze menime uplne neco jineho v pameti
             * 
             
             
             
             
             
             
             
             */
        }
    }
}