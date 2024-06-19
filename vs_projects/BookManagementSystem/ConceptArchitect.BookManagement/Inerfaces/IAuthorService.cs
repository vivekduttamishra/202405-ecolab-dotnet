using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IAuthorService
    {
        Task<Author> AddAuthor(Author author);
        Task<IList<Author>> GetAuthors();
        Task DeleteAuthor(string id);
        Task<Author> GetAuthorById(string id);
        Task<Author> UpdateAuthor(Author author);
        Task Save();
    }
}
