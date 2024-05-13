using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Specs
{
    public class SavingsAccountSpecs
    {
        double amount = 15000;
        string password = "p@ss";
        int minBalance;

        SavingsAccount account;
        [SetUp]
        public void SetUp()
        {
            account = new SavingsAccount(1, "User", password, amount);
            minBalance = account.MinBalance;

        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void SavingsAccountIsATypeOfBankAccount()
        {
            Assert.That(account, Is.InstanceOf<BankAccount>());
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void SavingsAccountHasMinimumBalance()
        {
            Assert.That(account.MinBalance, Is.EqualTo(minBalance));
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void SavingsAccountGetsStandardInterest()
        {
            //Act
            double rate = 4;
            account.CreditInterest(rate);

            //Assert
            var expectedNewBalance = amount + amount * rate / 1200;

            Assert.That(account.Balance, Is.EqualTo(expectedNewBalance));
        }

        void AssertBalance(double balance)
        {
            Assert.That(account.Balance, Is.EqualTo(balance));
        }

        void AssertBalanceUnchanged()
        {
            AssertBalance(amount);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void WithdrawFailsWithInsufficientBalanceIfMinBalanceCriterialIsNot()
        {
            //act
            var result = account.Withdraw(account.Balance - account.MinBalance + 1, password);

            //Assert
            Assert.That(result, Is.EqualTo(TransactionStatus.INSUFFICIENT_BALANCE));
            AssertBalanceUnchanged();

        }
        [Test]
        public void WithdrawalFailsForInvalidCredentials()
        {
            //act
            var result = account.Withdraw(1, "wrong-password");
            Assert.That(result, Is.EqualTo(TransactionStatus.INVALID_CREDENTIALS));

            AssertBalanceUnchanged();
        }

        [Test]
        public void WithdrawalSucceedsForHappyPath()
        {
            //act
            var result = account.Withdraw(amount - minBalance - 1, password);
            Assert.That(result, Is.EqualTo(TransactionStatus.SUCCESS));

            AssertBalance(minBalance + 1);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void SavingsAccountDescriptionIncludesWordSavingsAccount()
        {
            var info = account.Info();

            Assert.True(info.Contains("SavingsAccount"));
        }



        //Write Tests for all withdrawal and use cases
    }
}
