using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    public class BankAcc
    {
        int accountNumber;
        string holderName;
        string currency;
        uint balance;
        public BankAcc(int accountNumber, string holderName, string currency, uint balance) 
        {
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.currency = currency;
            this.balance = balance;
        }
        public static void Deposit(BankAcc acc)
        {
            uint depositAmount = 0;
            string depositAmountString;
            while (true)
            {
                try
                {
                    depositAmountString = Console.ReadLine();
                    if (!depositAmountString.Contains('.'))
                    {
                        Console.WriteLine("Transaction failed. No decimal point found");
                    } else
                    {
                        depositAmountString = depositAmountString.Replace(".", "");
                        if (uint.TryParse(depositAmountString, out depositAmount))
                        {
                            acc.balance += depositAmount;
                            Console.WriteLine("Successfuly completed transaction. Deposited " + Decimalise(Convert.ToString(depositAmount)) + " to bank account " + acc.accountNumber + ". The new total is " + Decimalise(Convert.ToString(acc.balance))) ;
                            break;
                        } else
                        {
                            Console.WriteLine("Transaction failed, incorrect input");
                            continue;
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Transaction failed. Check if you've tried to deposit negative numbers or an amount too high. Try again");
                    throw;
                }
            }
            
        }
        public static void Widthdraw(BankAcc acc)
        {
            uint widthdrawAmount = 0;
            string widthdrawAmountString;
            while (true)
            {
                try
                {
                    widthdrawAmountString = Console.ReadLine();
                    if (!widthdrawAmountString.Contains('.'))
                    {
                        Console.WriteLine("Transaction failed. No decimal point found");
                    }
                    else
                    {
                        widthdrawAmountString = widthdrawAmountString.Replace(".", "");
                        if (uint.TryParse(widthdrawAmountString, out widthdrawAmount))
                        {
                            acc.balance -= widthdrawAmount;
                            Console.WriteLine("Successfuly completed transaction. Widthdrew " + Decimalise(Convert.ToString(widthdrawAmount)) + " from bank account " + acc.accountNumber + ". The new total is " + Decimalise(Convert.ToString(acc.balance)));
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Transaction failed, incorrect input");
                            continue;
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Transaction failed. Check if you've tried to widthdraw negative numbers or an amount too high. Try again");
                    throw;
                }
            }

        }
        public static string Decimalise(string num)
        {
            return num.Insert(num.Length - 2, ".");
        }
    }
}
