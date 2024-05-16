

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
            if (accountNumber <= 0 ||accountNumber>lastId)
                return -1;

            var account = accounts[accountNumber];

            if(!account.Authenticate(password)) 
                return -2;


            return account.Balance;
        }

        BankAccount GetAccount(int accountNumber)
        {
            if (accountNumber <= 0 || accountNumber > lastId)
                return null;

            return accounts[accountNumber];
        }

        internal bool Deposit(int accountNumber, double amount)
        {
            var account= GetAccount(accountNumber);
            if (account == null) return false;
            
            return account.Deposit(amount);
        }

        public TransactionStatus Withdraw(int accountNumber, int amount, string password)
        {
            var account = GetAccount(accountNumber);
            if (account == null)
                return TransactionStatus.INVALID_ACCOUNT;
            else
                return account.Withdraw(amount, password);
        }

        internal string GetAccountInfo(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            if (account == null)
                return null;
            else if (!account.Authenticate(password))
                return null;
            else
                return account.Info();
        }

        public TransactionStatus Transfer(int accountNumber, int amount, string password, int toAccount)
        {
            var source = GetAccount(accountNumber);
            if (source == null)
                return TransactionStatus.INVALID_ACCOUNT;

            var target=GetAccount(toAccount);
            if(target==null)
                return TransactionStatus.INVALID_ACCOUNT;

            var result = source.Withdraw(amount, password);
            if (result == TransactionStatus.SUCCESS)
                if (target.Deposit(amount))
                    return TransactionStatus.SUCCESS;
                else
                    return TransactionStatus.INVALID_AMOUNT;


            return result;
        }
    }
}