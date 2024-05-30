using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public static class PrimeUtils
    {
        public static bool IsPrime(this int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;
            return true;
        }
    }

    public class PrimeFinder
    {
        public List<int> FindPrimes(int min, int max)
        {
            var result = new List<int>();
            for (int i = min; i <= max; i++)
                if (i.IsPrime())
                    result.Add(i);

            return result;
        }

        public void FindPrimesAsync(int min, int max, Action<List<int>> resultProcessor)
        {
            var result = new List<int>();
            for (int i = min; i <= max; i++)
                if (i.IsPrime())
                    result.Add(i);

            //return result;
            resultProcessor(result);
        }


        public IEnumerable<int> FindPrimesRange(int min, int max)
        {
            for (int i = min; i <= max; i++)
                if (i.IsPrime())
                    yield return i;


        }

    }

}
