
using System.Data.SqlClient;

namespace BookManagementConsole01
{
    public class AuthorRepositoryTests
    {
        AuthorRepository authorRepository;

        Author[] authorList =
        {
            new Author(){ Id="vivek", Name="Vivek Dutta Mishra"},
            new Author{ Id="dinkar",Name="Ramdhari Sing Dinkar"}
        };

        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=books_test_db;Integrated Security=True;Pooling=False;Encrypt=False;";

        [SetUp  ]
        public void Setup()
        {
            authorRepository = new AuthorRepository(connectionString);
            SeedDatabase();
        }

        [TearDown ] public void Teardown()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "DROP TABLE IF EXISTS Authors";
                command.ExecuteNonQuery();
            }
        }

        private void SeedDatabase()
        {
                using(var connection=new SqlConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    var command = connection.CreateCommand();
                    //command.CommandText = "DROP TABLE IF EXISTS Authors";
                    //command.ExecuteNonQuery();

                    command.CommandText = "CREATE TABLE Authors(" +
                        "id VARCHAR(255) PRIMARY KEY," +
                        "name VARCHAR(255) NOT NULL," +
                        "biography VARCHAR(2500)," +
                        "photograph VARCHAR(500)," +
                        "email VARCHAR(250) default('')" +
                        ")";

                    command.ExecuteNonQuery();

                    foreach(var author in authorList)
                    {
                        author.Biography = $"Biography of {author.Name}";
                        author.Photograph = $"{author.Id}.jpg";
                        author.Email = $"{author.Id}@booksweb.com";
                        command.CommandText=$"insert into Authors " +
                            $"values('{author.Id}','{author.Name}','{author.Biography}','{author.Photograph}','{author.Email}')";
                        command.ExecuteNonQuery();
                    }

                }
        }

        [Test]
        public void GetAllAuthorReturnsAllAuthors()
        {
            var authors= authorRepository.GetAllAuthors();
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
            var newAuthor = new Author()
            {
                Id = "new-author",
                Name = "New Author",
                Biography = "Biography of New Author",
                Photograph = "new-author.jpg",

            };
            authorRepository.AddAuthor(newAuthor);

            var a = authorRepository.GetAuthorById(newAuthor.Id);

            Assert.IsNotNull (a);
        }
        [Test]
        public void DeleteCanDeleteAuthorWithValidId()
        {
            authorRepository.DeleteAuthor(authorList[0].Id);

            Assert.Throws< InvalidIdException<string>>(() =>
            {
                authorRepository.GetAuthorById(authorList[0].Id);
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