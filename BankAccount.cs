using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
            {
                get
                {
                    decimal balance = 0;
                    foreach (var item in allTransactions)
                    {
                        balance = balance + item.Amount;
                        // balance += item.Amount;
                    }
                    return balance;
                }
            }

        private List<Transaction> allTransactions= new List<Transaction>();


        private static int accountNumberSeed = 1234567;

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDeposite(initialBalance, DateTime.Now, "Initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        public void MakeDeposite(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposite must be positive");
            }
            var deposite = new Transaction(amount, date, note);
            allTransactions.Add(deposite);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance-amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this exception");
            }
            var Withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(Withdrawal);
        }

        public string GetAcountHistory()
        {
            //HEAD
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date.ToShortDateString()} {item.Amount} {item.Notes}");
            }
            return report.ToString();
        }

    }
}
