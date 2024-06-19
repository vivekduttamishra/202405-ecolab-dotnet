using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public static  class ObjectExtensions
    {
        static Random rnd = new Random();
        public static T GetRandom<T>(this T[] array)
        {
            return array[rnd.Next(0, array.Length)];
        }

        public static T GetRandom<T>(this IList<T> list)
        {
            return list[rnd.Next(0, list.Count)];
        }

        

        public static T GetRandom<T>() where T : Enum
        {
            var possibleValues = Enum.GetValues(typeof(T));
            var values = new List<T>();

            foreach(T value in possibleValues)
            {
                values.Add(value);
            }
            return values.GetRandom();
         }
    }
}
