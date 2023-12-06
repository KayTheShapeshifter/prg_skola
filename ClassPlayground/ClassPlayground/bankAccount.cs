using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class bankAccount
    {
        public int accountNum;
        public int balance;
        public string holderName;
        public string currency;
        public void deposit()
        {
            Console.WriteLine("kolik chceš vložit");
            balance = balance + int.Parse(Console.ReadLine());
        }
        public void withdraw()
        {
            Console.WriteLine("kolik chceš vybrat");
            balance = balance - int.Parse(Console.ReadLine());
        }

    }
}
