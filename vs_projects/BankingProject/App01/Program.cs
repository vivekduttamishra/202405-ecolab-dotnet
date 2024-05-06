using ConceptArchitect.Banking;

namespace App01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var password = "p@ss";
            var amount = 10000;
            var account1 = new BankAccount(1, "Vivek", password, amount, 12);

            account1.Show();

            account1.Deposit();

            account1.Withdraw();

            account1.Show();
        }
    }
}
