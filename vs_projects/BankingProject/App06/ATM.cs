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
        Bank bank;
        Input kb = new Input();
        int accountNumber;
        string password;

        public ATM(Bank bank)
        {
            this.bank = bank;
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
                try
                {

                    int choice = kb.ReadInt("1. Deposit 2. Withdraw 3. Show 4. Check Balance 5. Transfer 0. Exit?");
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

                        case 4:
                            ShowBalance();
                            break;

                        case 5:
                            TransferFundsScreen();
                            break;

                        default:
                            ShowError("Invalid Choice");
                            break;
                    }

                }
                catch(InvalidCredentialsException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
             }
        }

        private void TransferFundsScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var password = kb.ReadString("Password: ");
            var toAccount = kb.ReadInt("To Account: ");

            TransactionStatus result = bank.Transfer(accountNumber, amount, password, toAccount);
            if (result == TransactionStatus.SUCCESS)
            {
                ShowInfo($"Rs {amount} transferred to {toAccount}");
            }
            else
                ShowError(result.ToString().Replace("_", " "));
        }

        private void WithdrawScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var password = kb.ReadString("Password: ");

           
            var result = bank.Withdraw(accountNumber,amount, password);
            if (result == TransactionStatus.SUCCESS)
                DispenceCash(amount);
            else
                ShowError(result.ToString().Replace("_", " "));
            
        }

        private void ShowBalance()
        {
            
            var password= kb.ReadString("Password? ");
            var balance= bank.GetBalance(accountNumber, password);
            if (balance == -1)
                ShowError("Invalid Account Number");
            else if (balance == -2)
                ShowError("Invalid Credentials");
            else
                ShowInfo($"Your balance: {balance}");
        }

        private void ShowInfoScreen()
        {
            var password = kb.ReadString("Password? ");
            var info = bank.GetAccountInfo(accountNumber, password);
            if (info == null)
                ShowError("Invalid Account Number/Password");
            else
                ShowInfo(info);
        }

        private void DepositScreen()
        {
            var amount = kb.ReadInt("Amount: ");
           
           
           if (bank.Deposit(accountNumber,amount))
            {
                ShowInfo($"Amount Deposited {amount}");
            }
           else
            {
                ShowError("Invalid AccountNumber/Amount");
            }
        }

      

        private void DispenceCash(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Please collect your cash: {amount}");
            Console.ResetColor();
        }

        private void ShowInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( message);
            Console.ResetColor();
        }

        

        private void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
    }
}
