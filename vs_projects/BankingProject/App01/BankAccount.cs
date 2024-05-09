using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class BankAccount
    {
        int accountNumber;
        string name;
        String password;
        double balance;
        double interestRate;
        Input kb = new Input();


        public BankAccount(int accountNumber, string name, string password, double balance, double interestRate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.balance = balance;
            this.interestRate = interestRate;

        }

        public void Deposit()
        {
            var amount = kb.ReadDouble("Amount? ");

            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine( "Amount Deposited");
            }
            else
            {
                Console.WriteLine( "Error: Negative Amount Not Allowed");
            }
        }

        public void Withdraw()
        {
            var amount = kb.ReadDouble("Amount? ");
            var password= kb.ReadString("Password? ");

            if (amount <= 0)
                Console.WriteLine("Error: Invalid Amount");
            else if (amount > balance)
                Console.WriteLine("Error: Insufficient Balance");
            else if (this.password != password)
                Console.WriteLine("Error: Invalid Credentials");
            else
            {
                Console.WriteLine("Please collect your cash!");
                balance -= amount;
            }
        }

        public void Show()
        {
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Name          : {name}");
            //Shouldn't show the password for security reason
            //Console.WriteLine($"Password      : {password}");
            Console.WriteLine($"Balance       : {balance}");
            Console.WriteLine($"Interest Rate : {interestRate}");
            Console.WriteLine( "-----------------------------------------");
            Console.WriteLine();
        }

        public void Authenticate(string password)
        {
            if (this.password == password)
                Console.WriteLine( "Authenticated");
            else
                Console.WriteLine("Authentication Failed");
        }

    }

    
}
