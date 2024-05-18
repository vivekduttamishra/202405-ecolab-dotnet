using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsDemo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Type?");
            string name = Console.ReadLine();

            var type = Type.GetType(name);
            if (type == null)
            {
                Console.WriteLine($"Invalid Type {name}. Please provide full name");
                return;
            }

            type.InvokeAllMethods();
        }

        static void Main1()
        {
            Console.WriteLine( "Welcome to Animal Kingdom ");
            Animal[] animals =
            {
                new Tiger(),
                new Camel(),
                new Horse(),
                new Crocodile(),
                new Eagle(),
                new Snake(),
                new Camel(),
                new Parrot(),
                new Leopard()
            };

            foreach(var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.Eat());
                Console.WriteLine(animal.Move());
                Console.WriteLine(animal.Breed());

                //Console.WriteLine(animal.Hunt());

                //Console.WriteLine(animal.Fly());


                Console.WriteLine("\n\n");
            }
        }
    }
}
