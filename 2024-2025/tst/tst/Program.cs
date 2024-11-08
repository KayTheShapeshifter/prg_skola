namespace tst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char pookie = 'a';
            int mysak = 23;
            bool milujesMe = true;
            Random random = new Random();
            while (true)
            {
                int number1;
                int number2;
                int result;
                string input;
                Console.WriteLine("Co chceš za operaci? Sčítání, odčítání nebo faktoriál?");
                input = Console.ReadLine().ToLower();
                number1 = Convert.ToInt32(Console.ReadLine());
                number2 = Convert.ToInt32(Console.ReadLine());
                if (input == "sčítání")
                {
                    result = number1 + number2;
                    Console.WriteLine(result);
                }
                else if (input == "odčítání")
                {
                    result = number1 - number2;
                    Console.WriteLine(result);
                }
                else if (input == "faktoriál")
                {
                    for (int i = 0; i < number1; i++)
                    {
                        result = number1 * (number1 - 1);
                        number1 = number1 - 1;
                    }
                }

            }
            

      

        }
    }
}
