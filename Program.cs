using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Rohit", 10000);
            Console.WriteLine($"Account {account.Number}I was created for {account.Owner} with {account.Balance} balance");

            account.MakeWithdrawal(120, DateTime.Now, "Rohan");
            Console.WriteLine(account.Balance);

            // account.MakeDeposite(-100, DateTime.Now, "Staeling");

            //Test that the initial balances must be positive
            try
            {
                var invalidAccount = new BankAccount("Invalid", 3355);
            }
            catch (ArgumentOutOfRangeException e)
            {

                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            account.MakeWithdrawal(50, DateTime.Now, "Sid");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAcountHistory());

            Console.ReadLine();
        }
    }
}
