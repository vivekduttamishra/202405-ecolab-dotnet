

using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        BankAccount[] accounts = new BankAccount[100]; 

        public  double InterestRate { get; internal set; }
        public string Name { get; internal set; }
        int lastId = 0;
        public int OpenAccount(string type, string name, string password, double amount)
        {
            
            BankAccount account = null;

            if (type == "savings")
                account = new SavingsAccount(0, name, password, amount);
            else if (type == "current")
                account = new CurrentAccount(0, name, password, amount);
            else if(type=="overdraft")
                account = new OverdraftAccount(0, name, password, amount);


            lastId++;
            account.AccountNumber = lastId;
            accounts[lastId] = account;
            return lastId;
        }

        public double GetBalance(int accountNumber, string password)
        {
            var account = GetActiveAccount(accountNumber);

            account.Authenticate(password); 
            
            return account.Balance;
        }

        BankAccount GetActiveAccount(int accountNumber)
        {
            if (accountNumber <= 0)
                throw new InvalidAccountException(accountNumber, "Invalid Account Number Format");

            if (accountNumber > lastId)
                throw new InvalidAccountException(accountNumber, "Invalid Account Number");


            var account=accounts[accountNumber];

            if (account == null)
                throw new ClosedAccountException(accountNumber);

            return account;
        }

        internal void Deposit(int accountNumber, double amount)
        {
            var account= GetActiveAccount(accountNumber);
            
            account.Deposit(amount);
        }

        public void Withdraw(int accountNumber, int amount, string password)
        {
            var account = GetActiveAccount(accountNumber);
            account.Withdraw(amount, password);
        }

        internal string GetAccountInfo(int accountNumber, string password)
        {
            var account = GetActiveAccount(accountNumber);
            account.Authenticate(password);
            return account.Info();
        }

        public void Transfer(int accountNumber, int amount, string password, int toAccount)
        {
            var source = GetActiveAccount(accountNumber);
           
            var target=GetActiveAccount(toAccount);

            source.Withdraw(amount, password);
            target.Deposit(amount);
        }
    }
}