using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenericTests
{
    public class GenericHelper
    {

        public static int GetId<T>(T value)
        {
            return value.GetHashCode();
        }

        public static string GetDescription<T>(T value)
        {
            return value.ToString();
        }

        public static bool Equals<X>(X a, X b)
        {
            return a.Equals(b);
        }




        public static T FindFirstInBudget<T>(int budget, params T[] values) where T : ISellable
        { 
                                                                           
            foreach (var item in values)
                if (item.Price <= budget)
                    return item;

            return default(T);
        }

        public static T CreateObject<T>() where T : new()
        {
            T t = new T();
            return t;
        }
    }
}
