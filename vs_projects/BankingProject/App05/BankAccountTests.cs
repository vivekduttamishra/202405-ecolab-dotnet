using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.Tests
{
    public class BankAccountTests
    {
        string password = "p@ss";
        double amount = 10000;
        BankAccount a1;

        [SetUp]
        public void Arrange()
        {
            a1 = new BankAccount("User1", password, amount);

        }

        [Test]
        public void WithdrawShouldFailForInvalidPassword()
        {
           
            var result = a1.Withdraw(1, "wrong-password");


            Assert.AreEqual(TransactionStatus.INVALID_CREDENTIALS, result);
        }

        [Test]
        public void EachNewAccountShouldHaveUniqueIncrementingAccountNumber()
        {
            var a2 = new BankAccount("User2", password, amount);
            Assert.AreEqual(a1.AccountNumber+1, a2.AccountNumber);
        }


        [Test]
        [Ignore("Not yet implemented")]
        public void InterestRateAppliesSameToEachAccount()
        {
            var a2 = new BankAccount("User2", password, amount);

            //Assert.AreEqual()

            Assert.Fail("Not yet implemented");
        }

        [Test]
        public void BankAccountInfoIncludesBalance()
        {
          
            Assert.GreaterOrEqual(a1.Info().IndexOf(amount.ToString()),0);
        }



        [Test]
        public void BankAccountInfoDoesntIncludesPassword()
        {  
            Assert.False(a1.Info().Contains(password));

        }

    }
}
