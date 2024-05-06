using App02;
using ConceptArchitect.Banking;

namespace ConceptArchitect.Banking
  {
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATM();
            atm.Start();
        }
    }
}
