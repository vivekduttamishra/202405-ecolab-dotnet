using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App04
{
    public class BankAccountTests
    {
        string password = "p@ss";
        double amount = 10000;

        [Test]
        public void EachNewAccountShouldHaveUniqueIncrementingAccountNumber()
        {
            var a1 = new BankAccount("User1", password, amount);
            var a2 = new BankAccount("User2", password, amount);
            Assert.AreEqual(a1.AccountNumber+1, a2.AccountNumber);
        }


        [Test]
        public void InterestRateAppliesSameToEachAccount()
        {
            var a1 = new BankAccount("User1", password, amount);
            var a2 = new BankAccount("User2", password, amount);

            //Assert.AreEqual()
        }

        [Test]
        public void BankAccountInfoIncludesBalance()
        {
            var a1 = new BankAccount("User1", password, amount);

            Assert.GreaterOrEqual(a1.Info().IndexOf(amount.ToString()),0);
        }



        [Test]
        public void BankAccountInfoDoesntIncludesPassword()
        {
            var a1 = new BankAccount("User1", password, amount);

            Assert.False(a1.Info().Contains(password));

            
        }

    }
}
