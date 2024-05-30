using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo01
{
    enum TransactionStatus
    {
        Success,
        InsufficientBalance=32,
        InvalidCredentials=41,
        UnknownFailure
    }

    enum HttpStatus
    {
        Success=200,
        NotFound=404,
        BadRequest=400
    }

    internal class Program
    {
        static void Main(string []args)
        {
            var thread = Thread.CurrentThread; //returns current running thread
            Console.WriteLine($"Name:{thread.Name}");
            Console.WriteLine($"Priority:{thread.Priority} => {(int)thread.Priority}");
            Console.WriteLine($"Id:{thread.ManagedThreadId}");

           

            var t = TransactionStatus.InsufficientBalance;

            Console.WriteLine(t);
            Console.WriteLine((int)t);
        }
    }
}
