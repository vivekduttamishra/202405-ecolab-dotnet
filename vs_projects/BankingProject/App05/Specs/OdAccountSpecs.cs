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
            var orginalOdLimit = account.OdLimit;
            account.Deposit(10000); //new historic max balance
            var newOdLimit = account.OdLimit;

            Assert.That(newOdLimit, Is.GreaterThan(orginalOdLimit));
        }


        [Test]
        public void OdLimitDoesntChangeOnDepositIfItDoesntCrossHistoricMaxBalance()
        {
            //Arrange: Make Historic Max balance
            account.Deposit(10000);
            var odLimitAtHistoricMaxBalance= account.OdLimit;
            //reduce the balance
            account.Withdraw(10000, password);

            //ACT:now deposit an amount that doesn't cross histroic max balance
            account.Deposit(1000);

            //Assert 
            Assert.That(account.OdLimit, Is.EqualTo(odLimitAtHistoricMaxBalance));


        }


        [Test]
        public void OdLimitDoesntChangeOnWithdrawal()
        {
            var originalOdLimit = account.OdLimit;
            //act
            account.Withdraw(amount/2, password);

            Assert.That(account.OdLimit, Is.EqualTo(originalOdLimit));   
        }

        [Test]
        public void OdLimitIncreasesOnCreditInterestIfItCrossHistoricMaxBalance()
        {
           

            //Act
            account.CreditInterest(12);

            var expectedOdLimit = account.Balance / 10;

            Assert.That(account.OdLimit, Is.EqualTo(expectedOdLimit));

        }


        [Test]
        public void OdLimitDoesntCreditInterestIfItDoesntCrossHistoricMaxBalance()
        {
            var odLimitAtHistroicMaxBalance=account.OdLimit;

            account.Withdraw(amount / 2, password); //withdrew 50%
            account.CreditInterest(12); //credited 1%

            Assert.That(account.OdLimit, Is.EqualTo(odLimitAtHistroicMaxBalance));
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
