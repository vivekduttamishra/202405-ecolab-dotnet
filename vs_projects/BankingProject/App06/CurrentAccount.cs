using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(int accountNumber, string name, string password, double balance) : base(accountNumber, name, password, balance)
        {
        }

        public override double EffectiveBalance => Balance;

        public override void CreditInterest(double interestRate)
        {
            //INTENTIONALLY LEFT EMPTY
            //NO INTEREST SHALL BE CREDITED
        }
    }
}