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
        INSUFFICIENT_BALANCE,
        INVALID_ACCOUNT
    }
    
    public abstract class BankAccount
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

        //static double interestRate;
        //public static double InterestRate { 
            
        //    get { return interestRate; }

        //    set
        //    {
        //        var delta = interestRate / 10;
        //        var diff = Math.Abs(interestRate - value);
        //        if (diff <= delta)
        //            interestRate = value;
        //    }

        //}

       

        int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
            internal set { accountNumber = value; }
        }

       

        protected double balance;
        public double Balance
        {
            get { return balance; }
            //no setter provided.
        }




        public BankAccount(int accountNumber, string name, string password, double balance)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.balance = balance;
            //this.interestRate = interestRate;

        }

        public virtual bool Deposit(double amount)
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

        public abstract double EffectiveBalance { get; }

        public virtual TransactionStatus Withdraw(double amount, string password)
        {
            
            if (amount <= 0)
                return TransactionStatus.INVALID_AMOUNT;

            if (amount > EffectiveBalance)
                return TransactionStatus.INSUFFICIENT_BALANCE;
            
            if (!Authenticate(password))
                return TransactionStatus.INVALID_CREDENTIALS;
            
            balance-= amount;
            return TransactionStatus.SUCCESS;
            
        }
        
        public virtual void CreditInterest(double interestRate)
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
           // Console.WriteLine($"Interest Rate : {interestRate}");
            Console.WriteLine( "-----------------------------------------");
            Console.WriteLine();
        }

        public virtual string Info()
        {
            return  $"{GetType().Name}Account Number: {accountNumber}" +
                    $"\nName          : {name}" +            
                    $"\nBalance       : {balance}" ;
           
        }

        //What Values Should be accessable outside


        //no standard get/set for password.

        //alternative for get
        public bool Authenticate(string password)
        {
            if (this.password != password)
                return false;
            else
                return true;
        }

        //alternative of set
        public bool ChangePassword(string oldPassword,  string newPassword)
        {
            if (Authenticate(oldPassword))
            {
                password = newPassword;
                return true;
            }
            else { return false; }

        }

    }
}
