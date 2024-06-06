using ConceptArchitect.Utils;

namespace ConceptArchitect.BookManagement.SqlRepository
{
    public class SqlAuthorRepository : IRepository<Author, string>
    {
        public Task<Author> Add(Author entity)
        {
            //insert into
            //db.ExecuteUpdate("insert into")
            //db.Add(entity)
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAll(Func<Author, bool> criteria)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task<Author> Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
