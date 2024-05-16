using App02;
using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05
{
    internal class Program
    {
        static void Main()
        {
            Bank bank = GetBank();
            ATM atm =new ATM(bank);

            atm.Start();
        }

        private static Bank GetBank()
        {
            Bank bank = new Bank() { InterestRate = 12, Name = "IDFC First" };

            bank.OpenAccount("savings", "Sanjay", "p@ss", 10000);
            bank.OpenAccount("current", "Chetan", "p@ss", 10000);
            bank.OpenAccount("overdraft", "Om", "p@ss", 10000);
            return bank;
        }
    }
}
