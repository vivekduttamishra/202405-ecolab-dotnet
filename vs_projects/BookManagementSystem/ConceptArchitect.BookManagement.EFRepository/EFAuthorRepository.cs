using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public class EFAuthorRepository : IRepository<Author, string>
    {
        BooksContext context;
        public EFAuthorRepository(BooksContext context)
        {
            this.context = context;
        }
        public async Task<Author> Add(Author author)
        {
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }
        public async Task<IList<Author>> GetAll()
        {
            return await context.Authors.ToListAsync();
        }
       
        public Task<Author> GetById(string id)
        {
            id = id.ToLower();
            var author = context.Authors.FirstOrDefaultAsync(a => a.Id.ToLower() == id);
            if (author == null)
                throw new InvalidEntityException($"Invalid Author Id:'{id}'");
            return author;
        }
       
        public async Task<IList<Author>> GetAll(Func<Author, bool> criteria)
        {
            return (from author in context.Authors
                    
                    where criteria(author)
                    
                    select author).ToList();
        }

        public async Task Delete(string id)
        {
            var author = await GetById(id);
            context.Authors.Remove(author);
            //await context.SaveChangesAsync();
        }




        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Author> Update(Author entity)
        {
            var currentAuthor= await GetById(entity.Id);
            currentAuthor.Name = entity.Name;
            currentAuthor.Email = entity.Email;
            currentAuthor.Photograph=entity.Photograph;
            currentAuthor.Biography=entity.Biography;

            await context.SaveChangesAsync();
            return currentAuthor;
        }
    }
}
