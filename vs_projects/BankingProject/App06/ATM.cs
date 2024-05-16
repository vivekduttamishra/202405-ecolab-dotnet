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
                catch (InsufficientBalanceException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}\t Your Deficit was {e.Deficit}");
                }
                catch(BankingException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
                catch(Exception e)
                {
                    ShowError($"Unknown Error occurred");
                }

            }
        }


        private void OptionsScreenV1()
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
                catch (InvalidCredentialsException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
                catch (InvalidDenominationException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
                catch (ClosedAccountException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
                catch (InvalidAccountException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}");
                }
                catch (InsufficientBalanceException e)
                {
                    ShowError($"Account: {e.AccountNumber} : Message: {e.Message}\t Your Deficit was {e.Deficit}");
                }
            }
        }


        private void TransferFundsScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var password = kb.ReadString("Password: ");
            var toAccount = kb.ReadInt("To Account: ");

            bank.Transfer(accountNumber, amount, password, toAccount);
            ShowInfo($"Rs {amount} transferred to {toAccount}");
        }

        private void WithdrawScreen()
        {
            var amount = kb.ReadInt("Amount: ");
            var password = kb.ReadString("Password: ");

           
            bank.Withdraw(accountNumber,amount, password);
            DispenceCash(amount);
            
        }

        private void ShowBalance()
        {
            
            var password= kb.ReadString("Password? ");
            var balance= bank.GetBalance(accountNumber, password);
            ShowInfo($"Your balance: {balance}");
        }

        private void ShowInfoScreen()
        {
            var password = kb.ReadString("Password? ");
            var info = bank.GetAccountInfo(accountNumber, password);
            ShowInfo(info);
        }

        private void DepositScreen()
        {
            var amount = kb.ReadInt("Amount: ");


            bank.Deposit(accountNumber, amount);
            ShowInfo($"Amount Deposited {amount}");
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
