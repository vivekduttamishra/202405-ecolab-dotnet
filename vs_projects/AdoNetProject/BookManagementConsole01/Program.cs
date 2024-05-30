using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookManagementConsole01
{
    public class Program
    {
        static void Main()
        {
            //string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ecolab202405;Integrated Security=True;Encrypt=False";
            //var repsitory = new AuthorRepositoryV2(connectionString);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())   
                .AddJsonFile("appsettings.json")
                .Build();
                                        
                
            var connectionString = configuration["connection_string"];

            Console.WriteLine("connection:"+connectionString);


            ConnectionFactory factory = () =>
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            };

            var repository = new AuthorRepository(new DbManager(factory));


            var authors = repository.GetAllAuthors();

            foreach(var author in authors)
            {
                Console.WriteLine($"{author.Name}\n\t{author.Biography}");
            }
        }
    }
}
