using ConceptArchitect.Banking;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    public class ATM
    {
        BankAccount []accounts ;
        Input kb = new Input();
        int accountNumber;
        string password;

        public ATM()
        {
            accounts = new BankAccount[]
            {
                null,
                new BankAccount(1,"Vivek","p@ss",10000,12),
                new BankAccount(2,"Sanjay","p@ss",10000,12),
            };
        }

        public void Start()
        {
            LoginScreen();
        }

        void LoginScreen()
        {
            while (true)
            {
                Console.WriteLine("Welcome to ATM");
                accountNumber = kb.ReadInt("Insert Card (account number): ");
                OptionsScreen();
            }
        }

        private void OptionsScreen()
        {
            while (true)
            {
                int choice = kb.ReadInt("1. Deposit 2. Withdraw 3. Info 0. Exit?");
                switch (choice)
                {
                    case 0:
                        return; //back to login

                    case 1:
                        DepositScreen();                        
                        break;

                    case 2:
                        WithdrawScreen();
                        break;

                    case 3:
                        ShowInfoScreen();
                        break;

                    default:
                        ShowError("Invalid Choice");
                        break;
                }
            }
        }

        private void ShowInfoScreen()
        {
            var account = GetAccount(accountNumber);
            if (account == null)
            {
                ShowError("Invalid Account Number");
                return; //back to login
            }
            else {
                account.Show();
            }
        }

        private void DepositScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var account = GetAccount(accountNumber);
            if (account == null)
            {
                ShowError("Invalid Account Number");
                return; //back to login
            }
            else if (account.Deposit(amount))
            {
                ShowInfo($"Amount Deposited {amount}");
            }
        }

        private void WithdrawScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var password=kb.ReadString("Password: ");
            
            var account = GetAccount(accountNumber);
            if (account == null)
            {
                ShowError("Invalid Account Number");
                return; //back to login
            }
            else             {
                var result = account.Withdraw(amount, password);
                if (result == TransactionStatus.SUCCESS)
                    DispenceCash(amount);
                else
                    ShowError(result.ToString().Replace("_"," "));
            }
        }

        private void DispenceCash(int amount)
        {
            Console.WriteLine($"Please collect your cash: {amount}");
        }

        private void ShowInfo(string message)
        {
            Console.WriteLine( message);
        }

        private BankAccount GetAccount(int accountNumber)
        {
            if (accountNumber < 0 || accountNumber > accounts.Length)
                return null;
            else 
                return accounts[accountNumber];
        }

        private void ShowError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
