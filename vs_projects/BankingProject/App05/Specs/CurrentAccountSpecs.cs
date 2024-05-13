using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    public class CurrentAccountSpecs
    {
        double amount = 15000;
        string password = "p@ss";
        

        CurrentAccount account;
        [SetUp]
        public void SetUp() 
        {
            account=new CurrentAccount(1,"User",password,amount);
           
            
        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void CurrenttIsATypeOfBankAccount()
        {
            Assert.That(account, Is.InstanceOf<BankAccount>());
        }

        

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void CreditInterestDoesntCreditInterest()
        {
            //Act
            double rate = 4;
            account.CreditInterest(rate);

            //Assert
            AssertBalanceUnchanged();
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
        public void AccountDescriptionIncludesWordCurrentAccount()
        {
            var info = account.Info();

            Assert.True(info.Contains("CurrentAccount"));
        }



        //Write Tests for all withdrawal and use cases
    }
}
