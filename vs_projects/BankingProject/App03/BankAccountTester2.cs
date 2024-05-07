using ConceptArchitect.Banking;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.Tests
{
    internal class BankAccountTester2
    {
        public void Test()
        {
            var password = "p@ss";
            var amount = 20000;
            var rate = 12;
            var name = "Vivek";
            var account = new BankAccount(1, name, password, amount, rate);

            TestWithdraw("Fails for wrong password", account, amount, "wrong-password", TransactionStatus.INVALID_CREDENTIALS);
            TestWithdraw("Fails for invalid amount", account, -1, password, TransactionStatus.INVALID_AMOUNT);
            TestWithdraw("Fails for insufficient balance", account, amount + 1, password, TransactionStatus.INSUFFICIENT_BALANCE);
            TestWithdraw("Succeeds for Happy Path", account, amount, password, TransactionStatus.SUCCESS);

        }

        void TestWithdraw(string description,BankAccount account, double amount, string password, TransactionStatus expected)
        {
            var actual = account.Withdraw(amount, password);

            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FAILED:\t{description}");
                Console.WriteLine($"\t EXPECTED:{expected}\tACTUAL:{actual}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"PASSED:\t{description}");
            }

            Console.WriteLine();
            Console.ResetColor();

        }
    }
}
