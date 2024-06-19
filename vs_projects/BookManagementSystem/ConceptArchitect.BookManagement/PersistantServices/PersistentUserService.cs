using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Services
{
    public class PersistentUserService : IUserService
    {
        IRepository<User, string> repository;
        public PersistentUserService(IRepository<User,string> repository)
        {
            this.repository = repository;
        }

        public async Task<User> AddUser(User user)
        {
            return await repository.Add(user);

        }

        public async Task Save()
        {
            await repository.Save();
        }

        private User NoPasswordUser(User user)
        {
            user.Password = string.Empty;
            return user;
        }

        public async Task<User> GetUserById(string email)
        {
            return await repository.GetById(email);
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await repository.GetById(email);
            if (user.Password == "password")
                return user;
            else
                throw new InvalidCredentialsException();
        }

        public async Task AddToShelf(string email, BookShelfItem book)
        {
            var user = await repository.GetById(email);
            user.BookShelf.Add(book);
            await repository.Save();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await repository.GetAll();
            return users.ToList();
        }

        public async Task RemoveUser(string email)
        {
            var user= await GetUserById(email);
            await repository.Delete(email);
            await repository.Save();
        }

        public async Task<User> UpdateUser(string email, User user)
        {
            var u = await repository.Update(email, user);
            return u;
        }
    }
}
