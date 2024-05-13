using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05.Specs
{
    public class OdAccountSpecs
    {
        double amount = 20000;
        string password = "p@ss";
        

        OverdraftAccount account;
        [SetUp]
        public void SetUp()
        {
            account = new OverdraftAccount(1, "User", password, amount);
            

        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OverdraftAccountIsATypeOfBankAccount()
        {
            Assert.That(account, Is.InstanceOf<BankAccount>());
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OverdraftAccountHasOdLimitEqualTo10PercentofInitialBalance()
        {
            Assert.That(account.OdLimit, Is.EqualTo(account.Balance / 10));

        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OverdraftAccountGetsStandardInterest()
        {
            //Act
            double rate = 4;
            account.CreditInterest(rate);

            //Assert
            var expectedNewBalance = amount + amount * rate / 1200;

            Assert.That(account.Balance, Is.EqualTo(expectedNewBalance));
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
        public void WithdrawalFailsWithInsufficieintBalanceForAmountGreaterThanBalancePlusOdLimit()
        {
            //act
            var result = account.Withdraw(account.Balance+account.OdLimit+1, password);

            //Assert
            Assert.That(result, Is.EqualTo(TransactionStatus.INSUFFICIENT_BALANCE));
            AssertBalanceUnchanged();
        }

      

        [Test]
        public void WithdrawalSucceedsForHappyPath()
        {
            //act
            var result = account.Withdraw(1,password);
            Assert.That(result, Is.EqualTo(TransactionStatus.SUCCESS));
            AssertBalance(amount - 1);
        }

        [Test]
        public void WithdrawalMoreThanBalanceAttractsOdFeeOf1PC()
        {
            //act
            var od = account.OdLimit / 2;
            var odFee = od / 100;
            var amountToWithdraw = amount + od;
            var finalBalance = - od - odFee;

            var result = account.Withdraw(amountToWithdraw, password);
            Assert.That(result, Is.EqualTo(TransactionStatus.SUCCESS));
            AssertBalance(finalBalance);
        }

        [Test]
        public void OdLimitIncreasesOnDepositIfItCrossHistoricMaxBalance()
        {

        }


        [Test]
        public void OdLimitDoesntChangeOnDepositIfItDoesntCrossHistoricMaxBalance()
        {

        }


        [Test]
        public void OdLimitDoesntChangeOnWithdrawal()
        {

        }

        [Test]
        public void OdLimitIncreasesOnCreditInterestIfItCrossHistoricMaxBalance()
        {

        }


        [Test]
        public void OdLimitDoesntCreditInterestIfItDoesntCrossHistoricMaxBalance()
        {

        }




        [Test]
        //[Ignore("Not Yet Implemented")]
        public void OverdraftAccountDescriptionIncludesWordSavingsAccount()
        {
            var info = account.Info();

            Assert.True(info.Contains("OverdraftAccount"));
        }


        void AssertBalance(double balance)
        {
            Assert.That(account.Balance, Is.EqualTo(balance));
        }

        void AssertBalanceUnchanged()
        {
            AssertBalance(amount);
        }







        //Write Tests for all withdrawal and use cases
    }
}
