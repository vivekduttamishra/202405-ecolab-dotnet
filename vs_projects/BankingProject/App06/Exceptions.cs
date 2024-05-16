using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class BankingException:Exception
    {
        public int AccountNumber { get; set; }

        public BankingException(int accountNumber, string message="Some Banking Problem"):base(message) 
        { 
            AccountNumber = accountNumber;
        }        
    }


    public class InvalidCredentialsException : BankingException
    {
        public InvalidCredentialsException(int accountNumber, string message = "Invalid Credentials") :
            base(accountNumber, message)
        {
        }
    }

    public class InvalidAccountException : BankingException
    {
        public InvalidAccountException(int accountNumber, string message = "Account Number is Invalid") :
            base(accountNumber, message)
        {
        }
    }

    public class ClosedAccountException : InvalidAccountException
    {
        public ClosedAccountException(int accountNumber, string message = "Account is Already Closed") :
            base(accountNumber, message)
        {
        }
    }

    public class InvalidDenominationException : BankingException
    {
        public InvalidDenominationException(int accountNumber, string message = "Invalid Denomination") :
            base(accountNumber, message)
        {
        }
    }

    public class InsufficientBalanceException : BankingException
    {
        public double Deficit { get; set; }
        public InsufficientBalanceException(int accountNumber, double deficit, string message = "Insufficieint Balance") :
            base(accountNumber, message)
        {
            Deficit = deficit;
        }
    }
}
