
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo07
{
    public class MathUtils
    {
        

        public  static async  Task<int> Permutation(int n,int r)
        {
                var fn = await Factorial(n);
                var fn_r = await Factorial(n - r);

                
                return fn / fn_r;

        }

        


        public static async  Task<int> Factorial(int n)
        {   
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
                await Task.Delay(1000);
            }
            return result;
        }

       
    }
}
