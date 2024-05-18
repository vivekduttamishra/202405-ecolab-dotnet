using ConceptArchitect.Collections.Utils;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    internal class Program
    {
        static void Main()
        {
            var list = new DblList<int>();

            for(int i = 0;i<5;i++)
                list.Add(i);

            list.AddMany(5, 6, 7, 8, 9);

            int a = 20;
            string name = "Vivek";

            a.Print();     //uses object's extension
            name.Print();
            SequenceUtils.Print(a); //uses sequece's extension

            list.Print();



        }
    }
}
