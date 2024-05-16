using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int accountNumber, string name, string password, double balance) 
            : base(accountNumber, name, password, balance)
        {
        }

        public override double EffectiveBalance
        {
            get { return Balance - MinBalance; }
        }

       
        public int MinBalance { get; } = 5000;

        
    }
}