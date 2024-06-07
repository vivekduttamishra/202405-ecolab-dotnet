using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentAuthorService : IAuthorService
    {
        IRepository<Author, string> repository;
        public PersistentAuthorService(IRepository<Author,string> repository)
        {
            this.repository = repository;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            if(string.IsNullOrEmpty(author.Id))
            {
                author.Id= string.Join('-', author.Name.ToLower().Split());
            }

            author=await  repository.Add(author);
            await repository.Save();
            return author;
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

        public async Task<Author> UpdateAuthor(Author author)
        {
            author=await repository.Update(author);
            await repository.Save();
            return author;
        }
    }
}
