using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public class BooksContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
    }
}
