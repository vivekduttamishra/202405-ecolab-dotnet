using ConceptArchitect.Banking;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.Tests
{
    internal class BankAccountTester
    {
        public void Test()
        {
            var password = "p@ss";
            var amount = 20000;
            var rate = 12;
            var name = "Vivek";
            var account = new BankAccount(1, name, password, amount, rate);

            account.Name = null;
            Console.WriteLine(account.Name);

            account.Name = "Sanjay";
            Console.WriteLine(account.Name);

            account.InterestRate = 15;
            Console.WriteLine(account.InterestRate);
            account.InterestRate = 11;
            Console.WriteLine(account.InterestRate);
            
            var result = account.Deposit(-1);
            Console.WriteLine(result);

            var result2=account.Deposit(1);
            Console.WriteLine(result2);

            account.CreditInterest();
            Console.WriteLine(account.Balance);

            var kb = new Input();
            var withdrawAmount = kb.ReadInt("Amount to withdraw? ");
            var challengePassword = kb.ReadString("Password? ");
            var withdrawResult = account.Withdraw(withdrawAmount, challengePassword);
            Console.WriteLine(withdrawResult);



        }
    }
}
