using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App06
{
    public class SavingsAccountTests
    {
        SavingsAccount account;
        string password = "p@ss";
        double amount = 20000;

        [SetUp]
        public void Setup()
        {
            account = new SavingsAccount(1, "User", password, amount);
        }

        [Test]
        public void WithdrawFailsForInvalidCredential()
        {
            try
            {
                account.Withdraw(1, "invalid password");
                //if we reach here --> exception was not thrown
                Assert.Fail($"InvalidCredentialException was not thrown");
            }
            catch(InvalidCredentialsException ex)
            {
                Assert.That(account.Balance, Is.EqualTo(amount));

            }
        }

        [Test]
        public void WithdrawFailsForNegativeAmount()
        {

            Assert.Throws<InvalidDenominationException>(() =>
            {
                account.Withdraw(-1,password);
            });

            Assert.That(account.Balance,Is.EqualTo(amount));
        }

        [Test]
        public void WithdrawFAilingForInsufficientBalanceIncludesProperDeficit()
        {
            var ex = Assert.Throws<InsufficientBalanceException>(() =>
            {
                account.Withdraw(account.EffectiveBalance + 1, password);
            });

            Assert.That(ex.Deficit, Is.EqualTo(1));

        }


    }
}
