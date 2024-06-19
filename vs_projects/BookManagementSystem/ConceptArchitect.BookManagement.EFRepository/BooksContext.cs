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
        public BooksContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
    
        public DbSet<BookShelfItem> BookShelfItems { get; set;}

        public DbSet<BookNote> BookNotes { get; set; }
    }
}
