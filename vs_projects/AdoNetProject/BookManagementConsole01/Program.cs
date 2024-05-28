using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public class Program
    {
        static void Main()
        {
            var repsitory = new AuthorRepository();

            var authors = repsitory.GetAllAuthors();

            foreach(var author in authors)
            {
                Console.WriteLine($"{author.Name}\n\t{author.Biography}");
            }
        }
    }
}
