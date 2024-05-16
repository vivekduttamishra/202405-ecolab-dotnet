using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class InvalidCredentialsException:Exception
    {
        public int AccountNumber { get; set; }

        public InvalidCredentialsException(int accountNumber, string message="Invalid Credentials"):base(message) 
        { 
            AccountNumber = accountNumber;
        }        
    }
}
