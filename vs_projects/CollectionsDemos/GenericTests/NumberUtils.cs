using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTests
{
    public static class NumberUtils
    {
        public static bool IsPrime(this int number)
        {
            if (number < 2)
                return false;

            for (var i = 2; i < number; i++)
                if (number % i == 0)
                    return false;


            return true;
        }

        public static DblList<int> FindEvens(this DblList<int> numbers)
        {
            var result = new DblList<int>();
            for(int i=0;i<numbers.Count; i++)
            {
                if (numbers[i] %2==0)
                    result.Add(numbers[i]);
            }

            return result;
        }

        public static DblList<int> FindPrimes(this DblList<int> numbers)
        {
            var result = new DblList<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (IsPrime(numbers[i]))
                    result.Add(numbers[i]);
            }

            return result;
        }

        public static DblList<int> FindDivisibleBy3Or5(this DblList<int> numbers)
        {
            var result = new DblList<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i]%3==0 || numbers[i]%5==0)
                    result.Add(numbers[i]);
            }

            return result;
        }
    }
}
