using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Services
{
    public class PersistentBookService : IBookService
    {
        IRepository<Book, string> repository;
        public PersistentBookService(IRepository<Book,string> repository)
        {
            this.repository = repository;
        }

        public async Task<Book> AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Id))
            {
                book.Id = string.Join("-", book.Title.ToLower().Split());
            }
            else
            {
                book.Id = book.Id.ToLower();
            }
            return await repository.Add(book);
        }

        public async Task<Book> GetBookById(string id)
        {
            return await repository.GetById(id);
        }

        public async Task<IList<Book>> GetAllBooks()
        {
            return await repository.GetAll();
        }

        public async Task<IList<Book>> GetBooksByAuthor(string authorId)
        {
            authorId = authorId.ToLower();
            return await repository.GetAll(book => book.Author.Id == authorId);
        }

        public async Task<IList<Book>> Search(string q)
        {
            q = q.ToLower();
            return await repository.GetAll(book => book.Title.ToLower().Contains(q) ||
                                                        book.Author.Name.ToLower().Contains(q) ||
                                                        book.Description.ToLower().Contains(q)
                                              );
        }

        public async Task<IList<Book>> Search(Func<Book, bool> predicate)
        {
            return await repository.GetAll(predicate);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await repository.UpdateOnly(book.Id, book, "Title", "Price", "Description", "CoverPhoto");
        }

        public async Task Save()
        {
            await repository.Save();
        }
    }
}
