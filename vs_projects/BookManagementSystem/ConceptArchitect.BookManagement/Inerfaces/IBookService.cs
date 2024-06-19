
namespace ConceptArchitect.BookManagement
{
    public interface IBookService
    {
        Task<Book> AddBook(Book book);
        Task<IList<Book>> GetAllBooks();
        Task<Book> GetBookById(string id);
        Task<IList<Book>> GetBooksByAuthor(string authorId);
        Task Save();
        Task<IList<Book>> Search(Func<Book, bool> predicate);
        Task<IList<Book>> Search(string q);
        Task<Book> UpdateBook(Book book);
    }
}