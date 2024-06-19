using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public class EFUserRepository : IRepository<User, string>
    {
        BooksContext context;
        public EFUserRepository(BooksContext booksContext) 
        {
            this.context = booksContext;
        }
        public async Task<User> Add(User entity)
        {
            var result= context.Users.Add(entity);
            await Save();
            return result.Entity;

        }

        public async Task Delete(string id)
        {
            var user = await GetById(id);
            context.Users.Remove(user);
            await Save();
        }

        public async Task<IList<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<IList<User>> GetAll(Func<User, bool> criteria)
        {
            return await (from user in context.Users
                    where criteria(user)
                    select user).ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            id = id.ToLower();
            var user =await context.Users.FirstOrDefaultAsync(u=>u.Email.ToLower()==id);
            if(user == null)
            {
                throw new InvalidEntityException($"No User with id : {id}");
            }
            if (user.BookShelf == null)
                user.BookShelf = new List<BookShelfItem>();
            return user;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
