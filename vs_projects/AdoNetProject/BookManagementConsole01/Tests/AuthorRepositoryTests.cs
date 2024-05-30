
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BookManagementConsole01.Tests
{
    public class AuthorRepositoryTests
    {
        AuthorRepository authorRepository;
        DbManager manager;

        Author[] authorList =
        {
            new Author(){ Id="vivek", Name="Vivek Dutta Mishra"},
            new Author{ Id="dinkar",Name="Ramdhari Sing Dinkar"}
        };

        Author newAuthor = new Author()
        {
            Id = "new-author",
            Name = "New Author",
            Biography = "Biography of New Author",
            Photograph = "new-author.jpg",

        };

        //string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=books_test_db;Integrated Security=True;Pooling=False;Encrypt=False;";

        [SetUp]
        public void Setup()
        {
            //var configuration= new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())       
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration["connection_string_test"];

            //var connectionString = AppSettings.I["connection_string_test"];


            //manager = new DbManager(() =>
            //{
            //    var connection = new SqlConnection(connectionString);
            //    connection.Open();
            //    return connection;
            //});


            manager = new DbManager(new DefaultConnectionFactory("connection_string_test").Factory);

            authorRepository = new AuthorRepository(manager);

            SeedDatabase();
        }

        [TearDown]
        public void Teardown()
        {
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.ConnectionString = connectionString;
            //    connection.Open();

            //    var command = connection.CreateCommand();
            //    command.CommandText = "DROP TABLE IF EXISTS Authors";
            //    command.ExecuteNonQuery();
            //}

            //manager.ExecuteCommand(command =>
            //{
            //    command.CommandText = "DROP TABLE IF EXISTS Authors";
            //    return command.ExecuteNonQuery();
            //});

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


                foreach (var author in authorList)
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
        public void GetAllAuthorReturnsAllAuthors()
        {
            var authors = authorRepository.GetAllAuthors();
            Assert.That(authors.Count, Is.EqualTo(authorList.Length));
        }




        [Test]
        public void GetByIdCanReturnAuthorForValidId()
        {
            var author = authorRepository.GetAuthorById(authorList[0].Id);
            Assert.IsNotNull(author);
            Assert.That(author.Name, Is.EqualTo(authorList[0].Name));
        }


        [Test]
        public void GetByIdThrowsInvalidIdExceptionForInvalidId()
        {
            var id = "invalid id";

            var ex = Assert.Throws<InvalidIdException<string>>(() =>
            {
                authorRepository.GetAuthorById(id);
            });

            Assert.That(ex.Id, Is.EqualTo(id));
        }


        [Test]
        public void AddAuthorAddsAnAuthorSuccessfull()
        {

            authorRepository.AddAuthor(newAuthor);

            var a = authorRepository.GetAuthorById(newAuthor.Id);

            Assert.IsNotNull(a);
        }

        [Test]
        public void AddAuthorFailsForDuplicateIdWithDuplicateIdException()
        {
            var ex=Assert.Throws<DuplicateIdException<string>>(() =>
            {
                authorRepository.AddAuthor(authorList[0]);
            });

            Assert.That(ex.Id, Is.EqualTo(authorList[0].Id));
            Assert.That(ex.InnerException, Is.InstanceOf<SqlException>());
            Assert.That(ex.InnerException.Message.Contains("Violation of PRIMARY KEY"));
        }

        [Test]
        public void DeleteCanDeleteAuthorWithValidId()
        {
            authorRepository.DeleteAuthor(authorList[0].Id);

            Assert.Throws<InvalidIdException<string>>(() =>
            {
                authorRepository.GetAuthorById(authorList[0].Id);
            });
        }

        [Test]
        public void UpdateAuthorCanUpdateAuthorDetailsForValidAuthor()
        {
            var author = authorList[0];
            var expectedBiography = "Biography is updated";
            author.Biography = expectedBiography;
            authorRepository.UpdateAuthor(author);

            //Assert
            var author2 = authorRepository.GetAuthorById(author.Id);
            Assert.That(author2.Biography, Is.EqualTo(expectedBiography));

        }

        [Test]
        public void UpdateAuthorFailsForInvalidId()
        {
            var author = authorList[0];
            author.Id = "new_id";
            author.Biography = "new biography";

            //Assert
            Assert.Throws<InvalidIdException<string>>(() =>
            {
                authorRepository.UpdateAuthor(author);
            });

        }

        [Test]
        public void DeleteFailsDeleteAuthorWithInValidId()
        {


            Assert.Throws<InvalidIdException<string>>(() =>
            {
                authorRepository.DeleteAuthor("invalid-author");
            });
        }
    }
}