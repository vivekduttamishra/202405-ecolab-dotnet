
namespace ConceptArchitect.BookManagement
{
    public interface IUserService
    {
        Task AddToShelf(string email, BookShelfItem book);
        Task<User> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string email);
        Task<User> Login(string email, string password);
        Task RemoveUser(string email);
        Task Save();
        Task<User> UpdateUser(string email, User user);
    }
}