using ConceptArchitect.Banking;

namespace App05
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(int accountNumber, string name, string password, double balance) : base(accountNumber, name, password, balance)
        {
        }

        public override void CreditInterest(double interestRate)
        {
            //INTENTIONALLY LEFT EMPTY
            //NO INTEREST SHALL BE CREDITED
        }
    }
}