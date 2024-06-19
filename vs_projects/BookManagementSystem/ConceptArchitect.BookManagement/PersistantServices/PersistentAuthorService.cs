using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Services
{
    public class PersistentAuthorService : IAuthorService
    {
        IRepository<Author, string> repository;
        public PersistentAuthorService(IRepository<Author, string> repository)
        {
            this.repository = repository;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            if (string.IsNullOrEmpty(author.Id))
            {
                author.Id = string.Join('-', author.Name.ToLower().Split());
            }
            try
            {

                author = await repository.Add(author);
                await repository.Save();
                return author;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                    throw new DuplicateIdException($"Duplication Author Id: {author.Id}");
                else
                    throw;
            }
        }

        public async Task DeleteAuthor(string id)
        {
            await repository.Delete(id);
            await repository.Save();
        }

        public async Task<Author> GetAuthorById(string id)
        {
            return await repository.GetById(id);
        }

        public async Task<IList<Author>> GetAuthors()
        {
            return await repository.GetAll();
        }

        public async Task Save()
        {
            await repository.Save();
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            author = await repository.Update(author,
                async () => await GetAuthorById(author.Id),
                (o, n) => o.Copy(n, "Id", "Books")
                );
            return author;
        }
    }
}
