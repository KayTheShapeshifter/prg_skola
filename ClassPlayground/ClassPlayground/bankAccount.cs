using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace ClassPlayground
{
    internal class bankAccount
    {
        public long accountNum;
        public int balance;
        public string holderName;
        public string currency;
        public bankAccount(string holderName, string currency)
        {
            Random rndAccNum = new Random();
            this.accountNum = rndAccNum.Next(100000000, 1000000000);
            this.balance = 0;
            this.holderName = holderName;
            this.currency = currency;
        }

        public void deposit()
        {
            Console.WriteLine("kolik chceš vložit");
            balance = balance + int.Parse(Console.ReadLine());
        }
        public void withdraw()
        {
            Console.WriteLine("kolik chceš vybrat");
            if (balance - int.Parse(Console.ReadLine())<0)
            {
                balance = balance - int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("jsi chudej haha (nedostatek peněz)");
                balance = 0;
            }
            
        }
        public void tranfer(bankAccount bankAccount1, bankAccount bankAccount2)
        {
            Console.WriteLine("kolik chceš poslat");
            if (bankAccount1.balance - int.Parse(Console.ReadLine()) < 0)
            {
                bankAccount1.balance = bankAccount1.balance - int.Parse(Console.ReadLine());
                bankAccount2.balance = bankAccount2.balance + int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("jsi chudej haha (nedostatek peněz)");
                bankAccount2.balance = bankAccount2.balance + bankAccount1.balance;
                bankAccount1.balance = 0;
            }
        }
    }
}
