using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public class Input
    {
        public string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int ReadInt(string prompt)
        {
            return int.Parse(ReadString(prompt));
        }
    }
}
