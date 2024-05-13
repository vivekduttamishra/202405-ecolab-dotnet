using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int accountNumber, string name, string password, double balance) 
            : base(accountNumber, name, password, balance)
        {
        }

        public override TransactionStatus Withdraw(double amount, string password)
        {
            //New condition
            if (amount > Balance-MinBalance)
                return TransactionStatus.INSUFFICIENT_BALANCE;

            //Reuse remaining old logic
            return base.Withdraw(amount, password);
        }

        

        public int MinBalance { get; } = 5000;
    }
}