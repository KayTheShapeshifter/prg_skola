using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes1
{
    internal class Program
    {
        public class human
        {
            public int age;
            public int height;
            public int weight;
            public string name;
            public string skinColor;
            public human partner;
            public human(int age, int height, int weight, string name) 
            {
                this.age = age;
                this.height = height;
                this.weight = weight;
                this.name = name;
            }  
            public human()
            {

            }
            public void introduceHuman()
            {
                Console.WriteLine("Jmenuji se " + name + ", vážím " + weight + ", měřím " + height + ", je mi " + age); 
            }
            public float BMI()
            {
                float bmi = weight / (height/100) * (height / 100);
                return BMI();
            }
            public static human makeChild(human human1, human human2)
            {
                if (human1.partner == human2 && human2.partner == human1)
                {
                    human child = new human();
                    child.age = 0;
                    child.height = (human1.height + human2.height) / 2;
                    child.weight = (human1.weight + human2.weight) / 2;
                    child.name = human1.name + " " + human2.name;
                    child.partner = null;
                    return child;
                }
                else
                {
                    Console.WriteLine("Je to bastard");
                    return null;
                }
            }
        }
        static void Main(string[] args)
        {
            human human1 = new human();
            human1.age = 32;
            human1.height = 180;
            human1.weight = 120;
            human1.name = "Pepa";
            human1.introduceHuman();
            float bmi = human1.BMI();
            Console.WriteLine("Bmi je " + bmi);
            


            human1.skinColor = "pink";

            human human2 = new human(40, 130, 95, "Honza");
            human2.skinColor = "red";
            human1.partner = human2;
            human2.partner = human1;

            Console.ReadKey();
        }
    }
}
