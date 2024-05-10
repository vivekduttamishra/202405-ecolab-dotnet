

using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        BankAccount[] accounts = new BankAccount[100]; 

        public  double InterestRate { get; internal set; }
        public string Name { get; internal set; }
        int lastId = 0;
        public int OpenAccount(string name, string password, double amount)
        {
            lastId++;
            var account = new BankAccount(lastId,name, password, amount);
            accounts[lastId] = account;
            return lastId;
        }

        public double GetBalance(int accountNumber, string password)
        {
            if (accountNumber <= 0 ||accountNumber>lastId)
                return -1;

            var account = accounts[accountNumber];

            if(!account.Authenticate(password)) 
                return -2;


            return account.Balance;
        }

        internal bool Deposit(int accountNumber, double amount)
        {
            if (accountNumber <= 0 || accountNumber > lastId)
                return false;
            if (amount <= 0)
                return false;
            return true;
        }
    }
}