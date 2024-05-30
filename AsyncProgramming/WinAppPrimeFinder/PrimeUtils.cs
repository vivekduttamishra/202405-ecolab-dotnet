using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPrimeFinder
{
    public partial  class PrimeUtils
    {
        public  bool IsPrime( int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        public  List<int> FindPrimes(int min,int max)
        {
            var result=new List<int>();
            for(int i=min; i<=max; i++) 
                if(IsPrime(i))
                    result.Add(i);

            return result;
        }
    }
}
