using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentBookService
    {
        IRepository<Book,string> bookRepository;

        public async Task<Book> AddBook(Book book)
        {
            if(string.IsNullOrEmpty(book.Id)) 
            {
                book.Id= string.Join("-", book.Title.ToLower().Split()); 
            }
            else
            {
                book.Id = book.Id.ToLower();
            }
            return await bookRepository.Add(book);  
        }

        public async Task<Book> GetBookById(string id)
        {
            return await bookRepository.GetById(id);
        }

        public async Task<IList<Book>> GetAllBooks()
        {
            return await bookRepository.GetAll();
        }

        public async Task<IList<Book>> GetBooksByAuthor(string authorId)
        {
            authorId=authorId.ToLower();
            return await bookRepository.GetAll(book => book.Author.Id == authorId);
        }

        public async Task<IList<Book>> Search(string q)
        {
            q=q.ToLower();
            return await bookRepository.GetAll( book => book.Title.ToLower().Contains(q) || 
                                                        book.Author.Name.ToLower().Contains(q) ||
                                                        book.Description.ToLower().Contains(q)
                                              );
        }

        public async Task<IList<Book>> Search(Func<Book, bool> predicate)
        {
            return await bookRepository.GetAll(predicate);
        }

        public async Task<Book> UpdateAuthor(Book book)
        {
            return await bookRepository.UpdateOnly(book.Id, book, "Title", "Price", "Description", "CoverPhoto");
        }
     }
}
