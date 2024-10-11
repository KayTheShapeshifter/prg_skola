using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Freetype
    {
        public static List<string> CalcConvertInput(string userInput) // kvůli tomuhle lze psát input s mezerami
        {
            userInput = userInput.Replace("(", " ( ").Replace(")", " ) ").Trim();

            List<string> userInputList = userInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            userInputList = CalcOperatorPrecedence(userInputList);

            return userInputList;
        }

        public static string CalcOperation(List<string> variables)
        {
            string operation = null;
            List<double> numericVariables = new List<double>();

            foreach (var variable in variables)
            {
                if (double.TryParse(variable, out double num))
                {
                    numericVariables.Add(num);
                }
                else if (operation == null)
                {
                    operation = variable; // The first non-numeric should be the operation
                }
            }
            if (numericVariables.Count == 0)
            {
                Console.WriteLine("Operation error, maybe you haven't input the correct sequence?");
                return null;
            }
            double result = numericVariables[0]; // Start with the first number

            // Calculate based on the operation
            for (int i = 1; i < (numericVariables.Count); i++)
            {
                switch (operation)
                {
                    case "+":
                        result += numericVariables[i];
                        break;

                    case "-":
                        result -= numericVariables[i];
                        break;

                    case "*":
                        result *= numericVariables[i];
                        break;

                    case "/":
                        if (numericVariables[i] != 0)
                            result /= numericVariables[i];
                        else
                            throw new DivideByZeroException("Cannot divide by zero.");
                        break;

                    default:
                        throw new ArgumentException("Unsupported operation.");
                }
            }
            return Convert.ToString(result);
        }
        private static List<string> CalcOperatorPrecedence(List<string> tokens)
        {
            List<string> output = new List<string>();
            for (int i = 1; i < tokens.Count; i += 2)
            {
                string token = tokens[i]; 

                if (token == "*" || token == "/") //koukam, zda existuje nasobeni/deleni protoze operator precedence
                {
                    if (i > 0 && i < tokens.Count - 1 && // cisla na obou stranach?
                        double.TryParse(tokens[i - 1], out _) &&
                        double.TryParse(tokens[i + 1], out _))
                    {
                        // Add parentheses around the multiplication or division
                        output.Add("(");
                        output.Add(tokens[i - 1]); // Left operand
                        output.Add(token); // Operator
                        output.Add(tokens[i + 1]); // Right operand
                        output.Add(")");

                        // Skip the next token as it is already processed
                        i++;
                    }
                    //tokens.RemoveAt(i - 2);
                }
                else
                {
                    output.Add(tokens[i - 1]); // Regular token, just add it
                    output.Add(token);
                }
            }

            return output;
        }

        public static string CalcTree(List<string> tokens) 
        {
            Stack<string> operations = new Stack<string>();
            Stack<List<string>> operands = new Stack<List<string>>();

            operands.Push(new List<string>());

            for (int i = 0; i < tokens.Count - 1; i++) //kdy6 tam je -1 tak funguje nasobeni a kdyz ne tak scitani
            {
                string token = tokens[i];

                if (token == "(")
                {
                    operands.Push(new List<string>());
                }
                else if (token == ")")
                {
                    List<string> subExpr = operands.Pop();
                    string subResult = CalcOperation(subExpr);
                    operands.Peek().Add(subResult); // Add the result to the upper level
                }
                else
                {
                    operands.Peek().Add(token); // Add number/operator to current list
                }
            }

            return CalcOperation(operands.Pop());
        }

        public string CalcMain(string userInput)
        {
            return CalcTree(CalcConvertInput(userInput));
        }
    }
}
