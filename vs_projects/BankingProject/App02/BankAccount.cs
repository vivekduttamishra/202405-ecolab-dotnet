﻿using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public enum TransactionStatus { SUCCESS, INVALID_CREDENTIALS, INVALID_AMOUNT, INSUFFICIENT_BALANCE}

    public class BankAccount
    {
        int accountNumber;
        string name;
        String password;
        double balance;
        double interestRate;

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
            if (amount <= 0)
                return TransactionStatus.INVALID_AMOUNT;
            else if (amount > balance)
                return TransactionStatus.INSUFFICIENT_BALANCE;
            else if (this.password != password)
                return TransactionStatus.INVALID_CREDENTIALS;
            else
            {
                balance -= amount;
                return TransactionStatus.SUCCESS;
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
    }
}
