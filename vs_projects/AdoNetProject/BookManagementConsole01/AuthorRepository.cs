using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public class AuthorRepository
    {
        public List<Author> GetAllAuthors()
        {         
        
            //1. Get a provider factory to get connection and other objects
            DbProviderFactory factory = null;
            DbConnection connection = null;

            try 
            {
                
                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ecolab202405;Integrated Security=True;Encrypt=False";
                connection.Open(); //makes connection to database

                //if we reach here we are connected.

                //3. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();
                command.CommandText = "select * from authors";
            

                //4. execute the command to get the result
                DbDataReader reader = command.ExecuteReader();

                //5. now loop through reader to get the results
                var authors = new List<Author>();
                while(reader.Read())
                {
                    var author = new Author();

                    author.Id = reader["id"].ToString();
                    author.Name = reader["name"].ToString();
                    author.Biography = reader["biography"].ToString();
                    author.Email= reader["email"].ToString();
                    author.Photograph = reader["photograph"].ToString();

                    authors.Add(author);
                }
                
                return authors;

            }
            catch(Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            finally
            {
                if (connection!=null)
                {
                    connection.Close();
                }
            }


            

           
            

        }
   
    
        public Author GetAuthorById(string id)
        {
            return null;
        }

        public void AddAuthor(Author author)
        {

        }

        public void UpdateAuthor(Author author)
        {

        }

        public void DeleteAuthor(Author author)
        {

        }
    
    }
}
