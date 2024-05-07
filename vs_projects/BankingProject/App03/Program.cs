using App02;
using ConceptArchitect.Banking;
using ConceptArchitect.Banking.Tests;

namespace ConceptArchitect.Banking
  {
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductionRelease();

            var tester = new BankAccountTester2();
            tester.Test();
        }

        private static void ProductionRelease()
        {
            var atm = new ATM();
            atm.Start();
        }
    }
}
