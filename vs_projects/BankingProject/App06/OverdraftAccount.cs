using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class OverdraftAccount : BankAccount
    {
        public OverdraftAccount(int accountNumber, string name, string password, double balance) : base(accountNumber, name, password, balance)
        {
            OdLimit = balance / 10;
        }

        public double OdLimit { get; internal set; }

        public override double EffectiveBalance => Balance + OdLimit;

        public override bool Deposit(double amount)
        {
            var result = base.Deposit(amount);
            AdjustOdLimit();
            return result;
        }

        public override void CreditInterest(double interestRate)
        {
            base.CreditInterest(interestRate);
            AdjustOdLimit();
        }

        private void AdjustOdLimit()
        {
            if(OdLimit<Balance/10)
                OdLimit = Balance / 10;
        }

        public override TransactionStatus Withdraw(double amount, string password)
        {
            var result = base.Withdraw(amount, password);
            if (result ==TransactionStatus.SUCCESS)
            {
                if( Balance<0)
                {
                    var odFee = Balance / 100;
                    balance += odFee;
                }

            }

            return result;
        }
    }
}