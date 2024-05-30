using Demo03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo02
{
    internal class Program
    {
        static void Main()
        {
            var c1 = new CountDown();
            var c2 = new CountDown();

            var t1 = new Thread(c1.Count);

            t1.Start();

            var t2=new Thread(new ParameterizedThreadStart(c2.CountDownFrom));

            t2.Start(200); //pass actual parameter to the Start function


            var c3 = new CountDown2(400);
            var t3 = new Thread(c3.CountDown);
            t3.Start();

            Console.WriteLine("Main Ends");
            
        }

    }
}

