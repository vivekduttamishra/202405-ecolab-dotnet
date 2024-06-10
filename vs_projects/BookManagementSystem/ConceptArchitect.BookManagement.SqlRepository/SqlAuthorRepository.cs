using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Data;
using System.Data.Common;

namespace ConceptArchitect.BookManagement.SqlRepository
{
    public class SqlAuthorRepository : IRepository<Author, string>
    {
        DbManager db;
        public SqlAuthorRepository(DbManager db)
        {
            this.db = db;
        }

        public async Task<Author> Add(Author author)
        {
            try
            {
                db.ExecuteUpdate($"insert into Authors (id,name,biography,photograph,email) " +
                                 $"values('{author.Id}','{author.Name}','{author.Biography}','{author.Photograph}','{author.Email}')");


                return await GetById(author.Id);
            }
            catch(Exception ex)
            {
                throw new DuplicateIdException($"Error Adding Author: '{author.Id}':{ex.Message}", ex);
            }
        }

        public async Task Delete(string id)
        {
            await Task.CompletedTask;

            var rows = db.ExecuteUpdate($"delete from Authors where id='{id}'");
            if (rows == 0)
                throw new InvalidEntityException($"Invalid Author Id:'{id}'");
        }


        private Author AuthorFactory(DbDataReader reader)
        {
            return new Author
            {
                Id = reader["Id"].ToString(),
                Name = reader["Name"].ToString(),
                Biography = reader["Biography"].ToString(),
                Email = reader["Email"].ToString(),
                Photograph = reader["Photograph"].ToString()
            };
        }

        public async Task<IList<Author>> GetAll()
        {
            await Task.CompletedTask;
            return db.Select<Author>("select * from Authors", AuthorFactory);
        }

        public async Task<IList<Author>> GetAll(Func<Author, bool> criteria)
        {
            var authors = await GetAll();
            
            return (from a in authors
                    where criteria(a)
                    select a).ToList();
        }

        public async Task<Author> GetById(string id)
        {
            await Task.CompletedTask;

            var author = db.FirstOrDefault($"select * from authors where id='{id}'",AuthorFactory);
            if (author == null)
                throw new InvalidEntityException($"Invalid Author Id: '{id}'");

            return author;
        }

        public async Task Save()
        {
            await Task.CompletedTask;
        }

        public async Task<Author> Update(Author author)
        {
            db.ExecuteUpdate($"update Authors " +
                                $"set name='{author.Name}'," +
                                $"biography='{author.Biography}'," +
                                $"photograph='{author.Photograph}'," +
                                $"email='{author.Email}' " +
                                $"where id='{author.Id}'");


            return await GetById(author.Id);
        }

        public async Task<Author> Update(Author newData, Action<Author, Author> mergeOldNew)
        {
            var existing = await GetById(newData.Id);
            if (mergeOldNew == null)
                existing.Copy(newData);
            else
                mergeOldNew(existing, newData);

            await Update(existing);
            return existing;
            
        }

        public async Task<Author> Update(Author newData, Func<Task<Author>> getOldData, Action<Author, Author> mergeOldNew)
        {
            var existing = await getOldData();
            mergeOldNew(existing, newData);
            await Save();
            return existing;
        }
    }
}
