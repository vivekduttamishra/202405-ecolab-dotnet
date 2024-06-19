using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public class EFBookRepository : IRepository<Book, string>
    {
        BooksContext context;
        public EFBookRepository(BooksContext context)
        {
            this.context = context;
        }
        public async Task<Book> Add(Book Book)
        {
            context.Books.Add(Book);
            await context.SaveChangesAsync();
            return Book;
        }
        public async Task<IList<Book>> GetAll()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetById(string id)
        {
            id = id.ToLower();

            var Book=await context.Books.FirstOrDefaultAsync(a => a.Id.ToLower() == id); 
            
            if (Book == null)
                throw new InvalidEntityException($"Invalid Book Id:'{id}'");
            return Book;
        }

        public async Task<IList<Book>> GetAll(Func<Book, bool> criteria)
        {
            return (from Book in context.Books

                    where criteria(Book)

                    select Book).ToList();
        }

        public async Task Delete(string id)
        {
            var Book = await GetById(id);
            context.Books.Remove(Book);
            //await context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        
    }




}
