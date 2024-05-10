using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    public class BankSpecs
    {
        Bank bank;
        string bankName = "IDFC Bank";
        double interestRate = 4;
        string name = "User1";
        string password = "p@ss";
        double amount = 10000;
        int lastAccountNumber, accountNumber;

        [SetUp]
        public void Init()
        {
            bank = new Bank();
            accountNumber = bank.OpenAccount(name, password, amount);
            lastAccountNumber=accountNumber;
        }

        void AssertBalance(int accountNumber, double balance)
        {
            var actualBalance = bank.GetBalance(accountNumber, password);
            Assert.That(actualBalance, Is.EqualTo(balance));
            bank.
        }

        void AssertBalanceUnchanged(int accountNumber)
        {
            AssertBalance(accountNumber, amount);

            
        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void BankHasAName()
        {
            bank.Name = bankName;
            Assert.That(bank.Name, Is.EqualTo(bankName));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void BankHasAnInterestRate()
        {
            bank.InterestRate=interestRate;

            Assert.That(bank.InterestRate,Is.EqualTo(interestRate));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OpenAccountShouldTakeNameAmountPasswordAndReturnsNewAccountNumber()
        {
            var result = bank.OpenAccount(name, password, amount);

            Assert.That(result, Is.TypeOf<int>());
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OpenAccountReturnsAccountNumberInIncreasingOrderFrom1()
        {
            int expected = lastAccountNumber;
            for(var i = 0; i < 10; i++)
            {
                var a = bank.OpenAccount(name, password, amount);
                expected++;
                Assert.That(a , Is.EqualTo(expected));
                
            }
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void GetBalanceFailsForInvalidAccountNumber()
        {
            

            //Act
            var result = bank.GetBalance(lastAccountNumber+1,password);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void GetBalanceFailsForInvalidCredentials()
        {
            
            //Act
            var result = bank.GetBalance(accountNumber, "wrong-password");
            
            //Assert
            Assert.That(result, Is.EqualTo(-2));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void GetBalanceReturnsTheBalanceOfValidAuthenticatedAccount()
        {
           

            //Act
            double result = bank.GetBalance(accountNumber, password);
            
            //Assert
            Assert.That(result, Is.EqualTo(amount));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void DepositFailsForInvalidAccountNumber()
        {
            var result = bank.Deposit(lastAccountNumber + 1, 1);

            Assert.IsFalse(result);
        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void DepositFailsForInvalidAmount()
        {
            var result = bank.Deposit(accountNumber, -1);
            Assert.IsFalse(result);
            AssertBalanceUnchanged(accountNumber);
        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void DepositSucceedsInHappyPath()
        {
            var result = bank.Deposit(accountNumber, 1);
            Assert.IsTrue(result);
            AssertBalance(accountNumber, amount + 1);
        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void WithdrawFailsForInvalidAccountNumber()
        {

        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void WithdrawFailsForInvalidAmount()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void WithdrawFailsForInvalidPassword()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void WithdrawFailsForInsufficientBalance()
        {

        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void WithdrawSucceedsInHappyPath()
        {

        }




        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferFailsForInvalidSourceAccountNumber()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferFailsForInvalidTargetAccountNumber()
        {

        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferFailsForInvalidAmount()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferFailsForInvalidPassword()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferFailsForInsufficientBalance()
        {

        }


        [Test]
        [Ignore("Not Yet Implemented")]
        public void TransferSucceedsInHappyPath()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CreditInterestCreditsInterestToAllAccount()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void ChangePasswordFailsForInvalidAccountNumber()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void ChangePasswordFailsForInvalidPassword()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void ChangePasswordChangesPasswordInHappyPath()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CloseAccountFailsForInvalidAccountNumber()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CloseAccountFailsForInvalidPassword()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CloseAccountFailsForInsufficientFunds()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CloseAccountReturnsBalanceOnSuccess()
        {

        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void CloseAccountClosesTheAccountOnSuccess()
        {

        }


    }
}
