using ConceptArchitect.Utils.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConceptArchitect.BookManagement.EFRepository.Tests
{
    public class EFRepositoriesTests
    {
        Author[] authors =
        {
            new Author { Id = "vivek", Name = "Vivek Dutta Mishra", Biography = "The Author of The Lost Epic Series", Photograph= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCFlHW7IBctOZc9PQG0fojV04Rzt4iHzxE8A&s" },
            new Author { Id = "dinkar", Name = "Ramdhari Singh Dinkar", Biography = "The National Poet of India",Photograph= "https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg" }

        };

        Author newAuthor = new Author
        {
            Id="new-id",
            Name = "New Name",
            Biography = "New Biography",
            Email = "new@email.com",
            Photograph = "New Photograph"
        };

        DbManager manager = new DbManager(() =>
        {
            var connection = new SqlConnection()
            {
                ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = books_test_db; Integrated Security = True; Pooling = False; Encrypt = False;"
            };
            connection.Open();
            return connection;
        });



        EFAuthorRepository repository;

        [SetUp]
        public void Setup()
        {
            SeedDatabase();
            SetupRepository();
        }

        private void SetupRepository()
        {
            //how do I tell Context which connection string to use?
            var contextBuilder = new DbContextOptionsBuilder<BooksContext>();
            contextBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=books_test_db;Integrated Security=True;Pooling=False;Encrypt=False;");
            var context = new BooksContext(contextBuilder.Options);   //connection string is currently hardcoded.
            repository = new EFAuthorRepository(context);
        }

        [TearDown]
        public void Teardown()
        {
            manager.ExecuteUpdate("DROP TABLE IF EXISTS Authors");
        }

        private void SeedDatabase()
        {

            manager.ExecuteCommand(command =>
            {
                command.CommandText = "CREATE TABLE Authors(" +
                    "id VARCHAR(255) PRIMARY KEY," +
                    "name VARCHAR(255) NOT NULL," +
                    "biography VARCHAR(2500)," +
                    "photograph VARCHAR(500)," +
                    "email VARCHAR(250) default('')" +
                    ")";

                command.ExecuteNonQuery();


                foreach (var author in authors)
                {
                    author.Biography = $"Biography of {author.Name}";
                    author.Photograph = $"{author.Id}.jpg";
                    author.Email = $"{author.Id}@booksweb.com";
                    command.CommandText = $"insert into Authors " +
                        $"values('{author.Id}','{author.Name}','{author.Biography}','{author.Photograph}','{author.Email}')";
                    command.ExecuteNonQuery();
                }

                return 0;
            });
        }


        [Test]
        public void GetAllCanGetAllAuthors()
        {
            var result = repository.GetAll().Result;

            Assert.That(result.Count(), Is.EqualTo(authors.Length));
        }

        [Test]
        public async Task GetByIdSucceedsForValidId()
        {
            var author = await repository.GetById(authors[0].Id);

            Assert.That(author,Is.Not.Null);
            Assert.That(author.Name, Is.EqualTo(authors[0].Name));
        }



        [Test]
        public async Task GetByIdThrowsInvalidEntityExceptionForInvalidId()
        {
            Assert.ThrowsAsync<InvalidEntityException>(  () =>  repository.GetById("invalid-id"));
        }



        [Test]
        public async Task DeleteThrowsInvalidEntityExceptionForInvalidId()
        {

           
            Assert.ThrowsAsync<InvalidEntityException>(  () =>  repository.Delete("invalid-id"));
        }

        [Test]
        public async Task DeletesAuthorWithValidId()
        {
            await repository.Delete(authors[0].Id);

            Assert.ThrowsAsync<InvalidEntityException>(  () =>  repository.GetById(authors[0].Id));
        }

        [Test]
        public async Task AddCanAddNewAuthor()
        {
            var author = await repository.Add(newAuthor);

            var dbAuthor= await repository.GetById(author.Id);

            Assert.That(dbAuthor.Id,Is.EqualTo(author.Id));

        }
    }
}
