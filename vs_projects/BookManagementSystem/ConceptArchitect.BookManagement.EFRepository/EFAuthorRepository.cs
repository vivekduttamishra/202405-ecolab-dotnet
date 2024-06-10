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

        public async Task<Author> GetById(string id)
        {
            id = id.ToLower();

            var author=await context.Authors.FirstOrDefaultAsync(a => a.Id.ToLower() == id); 
            
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

        public async Task<Author> Update(Author newData, Action<Author, Author> mergeOldNew)
        {
            var existing = await GetById(newData.Id);
            if (mergeOldNew != null)
                mergeOldNew(existing, newData);
            else
                existing.Copy(newData, "Id");

            await context.SaveChangesAsync();
            return existing;
        }

        public async Task<Author> Update(Author newData, Func<Task<Author>> getOldData, Action<Author, Author> mergeOldNew)
        {
            var existing = await getOldData();
            mergeOldNew(existing, newData);
            await context.SaveChangesAsync();
            return existing;
        }
    }




}
