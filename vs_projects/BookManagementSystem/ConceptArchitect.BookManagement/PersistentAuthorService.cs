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
            return await repository.Add(author);
        }

        public Task DeleteAuthor(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAuthorById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAuthors()
        {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
