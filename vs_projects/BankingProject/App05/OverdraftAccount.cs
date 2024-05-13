using ConceptArchitect.Banking;

namespace App05
{
    public class OverdraftAccount : BankAccount
    {
        public OverdraftAccount(int accountNumber, string name, string password, double balance) : base(accountNumber, name, password, balance)
        {
            OdLimit = balance / 10;
        }

        public double OdLimit { get; internal set; }

        public override TransactionStatus Withdraw(double amount, string password)
        {
            if (amount <= 0)
                return TransactionStatus.INVALID_AMOUNT;

            if (!Authenticate(password))
                return TransactionStatus.INVALID_CREDENTIALS;

            if (amount > balance+OdLimit)
                return TransactionStatus.INSUFFICIENT_BALANCE;

           

            balance -= amount;
            if (balance < 0)
                balance += (balance / 100);

            return TransactionStatus.SUCCESS;
        }
    }
}