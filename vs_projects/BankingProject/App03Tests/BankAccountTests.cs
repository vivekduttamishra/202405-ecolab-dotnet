using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App03Tests
{
    public class BankAccountTests
    {
        string password = "p@ss";
        double amount = 10000;
        double interestRate = 12;

        [Test]
        public void WithdrawShouldFailForInvalidCredential()
        {
            var account = new BankAccount(1, "Vivek", password, amount, interestRate);
            var result = account.Withdraw(1, "wrong-password");
            Assert.AreEqual(TransactionStatus.INVALID_CREDENTIALS, result);
        }


        [Test]
        public void WithdrawShouldFailForInvalidAmount()
        {
            var account = new BankAccount(1, "Vivek", password, amount, interestRate);
            var result = account.Withdraw(-1, password);
            Assert.AreEqual(TransactionStatus.INVALID_AMOUNT, result);
        }
    }
}
