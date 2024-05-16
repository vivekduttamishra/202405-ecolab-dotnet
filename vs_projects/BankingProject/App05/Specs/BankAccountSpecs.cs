using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Specs
{
    public class BankAccountSpecs
    {
        string password = "p@ss";
        double amount = 10000;
        BankAccount a1;

        [SetUp]
        public void Arrange()
        {
            //BankAccount.InterestRate = 12;
            a1 = new SavingsAccount(1, "User1", password, amount);

        }

        void AssertTransactionSuccess(TransactionStatus status, double newBalance)
        {
            Assert.That(status, Is.EqualTo(TransactionStatus.SUCCESS));
            Assert.That(a1.Balance, Is.EqualTo(newBalance));
        }

        void AssertTransactionFailed(TransactionStatus expectedFailure, TransactionStatus actual)
        {
            Assert.That(actual, Is.EqualTo(expectedFailure));
            Assert.That(a1.Balance, Is.EqualTo(amount));
        }


        [Test]
        [Ignore("Test is no longer relevant")]
        public void EachNewAccountShouldHaveUniqueIncrementingAccountNumber()
        {
            var a2 = new SavingsAccount(2, "User2", password, amount);
            Assert.AreEqual(a1.AccountNumber + 1, a2.AccountNumber);
        }

        [Test]
        [Ignore("Doesn't Apply Anymore and different Accounts may have different interest")]
        public void InterestRateAppliesSameToEachAccount()
        {
            //var a2 = new BankAccount(2,"User2", password, amount);
            //var expectedBalance = amount + amount * BankAccount.InterestRate / 1200;

            //a1.CreditInterest();
            //a2.CreditInterest();

            //Assert.That(a1.Balance, Is.EqualTo(a2.Balance));
            //Assert.That(a1.Balance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void BankAccountInfoIncludesBalance()
        {

            Assert.GreaterOrEqual(a1.Info().IndexOf(amount.ToString()), 0);
        }

        [Test]
        public void BankAccountInfoDoesntIncludesPassword()
        {
            Assert.False(a1.Info().Contains(password));

        }

        [Test]
        public void WithdrawShouldFailForInvalidPassword()
        {

            //var result = a1.Withdraw(1, "wrong-password");

            //Assert.AreEqual(TransactionStatus.INVALID_CREDENTIALS, result);

            AssertTransactionFailed(TransactionStatus.INVALID_CREDENTIALS,
              a1.Withdraw(1, "wrong-password"));
        }

        [Test]
        public void WithdrawShouldFailForInvalidAmount()
        {
            //var result = a1.Withdraw(-1,password);
            //Assert.AreEqual(TransactionStatus.INVALID_AMOUNT, result);


            AssertTransactionFailed(TransactionStatus.INVALID_AMOUNT,
                a1.Withdraw(-1, password));

        }

        [Test]
        public void WithdrawShouldFailInsufficientBalance()
        {

            //var result = a1.Withdraw(amount+1, password);
            //Assert.AreEqual(TransactionStatus.INSUFFICIENT_BALANCE, result);

            AssertTransactionFailed(TransactionStatus.INSUFFICIENT_BALANCE,
                a1.Withdraw(amount + 1, password)
                );
        }


        [Test]
        public void WithdrawShouldSucceedInHappyPath()
        {

            //var result = a1.Withdraw(amount-1, password);
            //Assert.AreEqual(TransactionStatus.SUCCESS, result);
            //Assert.That(a1.Balance, Is.EqualTo(1));

            AssertTransactionSuccess(a1.Withdraw(1, password), amount - 1);
        }



        //[Test]
        //public void PIShouldbe3_14()
        //{
        //    Assert.AreEqual(3.147, Math.PI,0.001);
        //}




    }
}
