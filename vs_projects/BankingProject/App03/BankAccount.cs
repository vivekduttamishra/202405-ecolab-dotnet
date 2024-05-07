using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public enum TransactionStatus 
    { 
        SUCCESS, 
        INVALID_CREDENTIALS, 
        INVALID_AMOUNT, 
        INSUFFICIENT_BALANCE
    }
    
    public class BankAccount
    {
      
        
        String password;
       
        string name;
        
        public string Name
        {
            get { return name; }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
            }
        }

        double interestRate;
        public double InterestRate { 
            
            get { return interestRate; }

            set
            {
                var delta = interestRate / 10;
                var diff = Math.Abs(interestRate - value);
                if (diff <= delta)
                    interestRate = value;
            }

        }
        
       

        int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; }
        }

       

        double balance;
        public double Balance
        {
            get { return balance; }
            //no setter provided.
        }




        public BankAccount(int accountNumber, string name, string password, double balance, double interestRate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.balance = balance;
            this.interestRate = interestRate;

        }

        public bool Deposit(double amount)
        {

            if (amount > 0)
            {
                balance += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        //public string Withdraw(double amount, string password)
        //{
        //    if (amount <= 0)
        //        return "Error: Invalid Amount";
        //    else if (amount > balance)
        //        return "Error: Insufficient Balance";
        //    else if (this.password != password)
        //        return "Error: Invalid Credentials";
        //    else
        //    {
        //        balance -= amount;
        //        return "Please collect your cash!";
        //    }
        //}

        public TransactionStatus Withdraw(double amount, string password)
        {
            //if (amount <= 0)
            //    return TransactionStatus.INVALID_AMOUNT;

            if (amount > balance)
                return TransactionStatus.INSUFFICIENT_BALANCE;
            
            if (this.password != password)
                return TransactionStatus.INVALID_CREDENTIALS;
            
            balance -= amount;
            return TransactionStatus.SUCCESS;
            
        }
        
        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
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
    
        //What Values Should be accessable outside

        
    }
}
