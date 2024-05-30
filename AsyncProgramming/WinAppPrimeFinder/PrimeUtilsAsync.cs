using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPrimeFinder
{
    partial class PrimeUtils
    {










        public  async Task<List<int>> FindPrimesAsync(int min, int max)
        {
            await Task.Yield();

            return this.FindPrimes(min, max);  
        }
    }
}
