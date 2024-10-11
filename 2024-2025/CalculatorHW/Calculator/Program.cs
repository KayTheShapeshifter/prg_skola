using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Help()
        {
            if (Console.ReadLine() == "help")
            {
                Console.WriteLine("Did you really think I was gonna be helpful?????" +
                    "\nThe instructions later on are quite clear." +
                    "\n");
                Thread.Sleep(1000);
                ProcessStartInfo psi = new ProcessStartInfo(); // credit https://tpforums.org/forum/archive/index.php/t-1524.html and others
                psi.CreateNoWindow = true;
                psi.UseShellExecute = true;
                psi.FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(psi);
            }
        }
        static string ReadOperation(string type)
        {
            string operation = Console.ReadLine();
            while (true)
            {
                if (operation == "addition" || operation == "subtraction" || operation == "multiplication" || operation == "division" || operation == "power" || operation == "root" || operation == "logarithm")
                {
                    return operation;
                }
                else
                {
                    if (type == "a")
                    {
                        Console.WriteLine("Never gonna give you up, but you gotta give me a valid operation.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Never gonna let you down, but that input lets me down. Try again!");
                        operation = Console.ReadLine();
                    }
                }
            }
        }
        static Dictionary<string, double> Vars()
        {
            Dictionary<string, double> varPairs = new Dictionary<string, double>();
            Console.WriteLine("Write the name of the variable. If you want me to give it up type \"stop\", if you want to continue press enter.");

            while (Console.ReadLine() != "stop")
            {

                string key;
                double value = 0;
                Console.WriteLine("Never gonna make you cry... IF you give me a name for your custom variable. Cannot be a number.");
                key = Console.ReadLine();
                while (Double.TryParse(key, out value) || string.IsNullOrWhiteSpace(key))
                {
                    Console.WriteLine("Invalid variable name. It cannot be a number or empty. Please try again.");
                    key = Console.ReadLine();
                }

                Console.WriteLine("Write its value.");
                value = 0;
                while (!Double.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("Invalid value. Please enter a valid number.");
                }
                if (!varPairs.ContainsKey(key))
                {
                    varPairs.Add(key, value);
                }
                else
                {
                    Console.WriteLine("A variable with the same name already exists");
                }
                Console.WriteLine("Write the name of the variable. If you want me to give it up type \"stop\", if you want to continue press enter.");
                if (Console.ReadLine().ToLower() == "stop")
                {
                    break;
                }

            }
            return varPairs;
        }

        static double Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "addition":
                    return num1 + num2;
                case "subtraction":
                    return num1 - num2;
                case "multiplication":
                    return num1 * num2;
                case "division":
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Never gonna make you cry, but dividing by zero will.");
                        Console.ReadKey();
                        return 0;
                    }
                case "power":
                    return Math.Pow(num1, num2);
                case "root":
                    Console.WriteLine("You know the root, but so di I");
                    return Math.Pow(num1, 1 / num2);
                case "logarithm":
                    return Math.Log(num1, num2);
                default:
                    Console.WriteLine("Never gonna say goodbye, but this operation isn't right.");
                    return 0;
            }
        }

        static string ConvertToBase(double result, string type)
        {
            int baseNumber;

            Console.WriteLine("Your heart's been aching, but you're too shy to say it ... But which base should we use? (2 to 36)");

            string baseInput = Console.ReadLine();

            while (!int.TryParse(baseInput, out baseNumber) || baseNumber > 36 || baseNumber < 2)
            {
                if (type == "a")
                {
                    Console.WriteLine("Never gonna run around and desert you, but you gotta give a valid base.");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Never gonna tell a lie, but that base is wrong. Try again.");
                    baseInput = Console.ReadLine();
                }
            }

            long integerPart = (int)result;
            double fractionalPart = result - integerPart;

            StringBuilder resultBuilder = new StringBuilder();

            while (integerPart > 0)
            {
                long digit = integerPart % baseNumber;
                char digitChar = (char)((digit < 10) ? ('0' + digit) : ('A' + digit - 10));
                resultBuilder.Insert(0, digitChar);
                integerPart /= baseNumber;
            }

            if (fractionalPart > 0)
            {
                resultBuilder.Append(".");

                for (int i = 0; i < 16; i++)
                {
                    fractionalPart *= baseNumber;
                    int digit = (int)fractionalPart;
                    char digitChar = (char)((digit < 10) ? ('0' + digit) : ('A' + digit - 10));
                    resultBuilder.Append(digitChar);
                    fractionalPart -= digit;
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
            string type;
            string runAgain;
            string baseConversion;
            string convertedResult;
            Dictionary<string, double> vars = new Dictionary<string, double>();

            Console.WriteLine("If you need help, type \"help\". Otherwise press enter.");
            Help(); 

            Console.WriteLine("A full commitment's what I'm thinking of... but should we:\n" +
                "a) Quit on bad input \n" +
                "b) Never let you down and keep asking until it's right? \n" +
                "Type 'a' or 'b'.");
            type = Console.ReadLine();
            while (true) 
            {
                if (type != "a" & type != "b")
                {
                    Console.WriteLine("Never gonna make you cry, but you gotta give me a valid input.");
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
            }

            do
            {
                Console.WriteLine("We've known eachother for so long... but do you want to add variables? If so, type \"yes\"");
                if (Console.ReadLine() == "yes")
                {
                    vars = Vars();
                }
                Console.WriteLine("We're no strangers to numbers. What's the first one?");
                input1 = Console.ReadLine();

                while (!double.TryParse(input1, out num1))
                {
                    if (vars.ContainsKey(input1))
                    {
                        num1 = vars[input1];
                        break;
                    }
                    else if (type == "a")
                    {
                        Console.WriteLine("Never gonna say goodbye, but that first number's wrong.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else if (type == "b")
                    {
                        Console.WriteLine("Never gonna tell a lie, but that first number needs to be right. Try again.");
                        input1 = Console.ReadLine();
                    }
                }

                Console.WriteLine("First number is " + num1 + ", now what's the second?");
                input2 = Console.ReadLine();

                while (!double.TryParse(input2, out num2))
                {
                    if (vars.ContainsKey(input2))
                    {
                        num2 = vars[input2];
                        break;
                    }
                    else if (type == "a")
                    {
                        Console.WriteLine("Never gonna make you cry, but that second number ain't it.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else if (type == "b")
                    {
                        Console.WriteLine("Never gonna run around, but let's run that second number again.");
                        input2 = Console.ReadLine();
                    }
                }

                Console.WriteLine("Second number is " + num2 + ". Now pick an operation: addition, subtraction, multiplication, division, power, root, logarithm");
                result = Calculate(num1, num2, ReadOperation(type));

                if (result != 69)
                {
                    Console.WriteLine("Gotta make you understand... your result is: " + result + ".");
                }
                else
                {
                    Console.WriteLine("Nice.");
                }

                Console.WriteLine("Don't tell me you're too blind to see... that a base conversion could give us extacy. If yes, type \"yes\". Otherwise, press enter.");
                baseConversion = Console.ReadLine();

                if (baseConversion == "yes")
                {
                    convertedResult = ConvertToBase(result, type);
                    Console.WriteLine("Converted result: " + convertedResult);
                }

                Console.WriteLine("Fancy another calculation? Type \"yes\" to do it all again, or press enter to end.");
                runAgain = Console.ReadLine();

            } while (runAgain == "yes");
        }
    }
}
