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

        private void ValidateAmount(double amount)
        {
            if (amount <= 0)
                throw new InvalidDenominationException(accountNumber, "Amount must be positive");
        }

        public virtual void  Deposit(double amount)
        {
            ValidateAmount(amount);
            
            balance += amount;
        }

      

        public abstract double EffectiveBalance { get; }

        public virtual void Withdraw(double amount, string password)
        {

            Authenticate(password);
            
            ValidateAmount(amount);

            if (amount > EffectiveBalance)
                throw new InsufficientBalanceException(accountNumber, amount-EffectiveBalance,"Insufficient Funds.");
            
            balance-= amount;
            
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
        public void Authenticate(string password)
        {
            if (this.password != password)
                //throw new Exception("Invalid Credentials"); //return false;
                throw new InvalidCredentialsException(accountNumber, "Invalid Credentials");           
        }

        //alternative of set
        public void ChangePassword(string oldPassword,  string newPassword)
        {
            Authenticate(oldPassword);
            password = newPassword;
            
        }

    }
}
