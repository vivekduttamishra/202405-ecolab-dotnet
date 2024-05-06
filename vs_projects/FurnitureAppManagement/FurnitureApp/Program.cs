using ConceptArchitect.Data;
using ConceptArchitect.Furnitures;

namespace FurnitureApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chair = new Chair();
            Console.WriteLine($"The price of {chair} is {chair.Price}");

            var list = new List();
            for (var i = 0; i < 5; i++)
                list.Add();
        }
    }
}
