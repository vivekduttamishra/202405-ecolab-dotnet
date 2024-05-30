using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public class AuthorRepositoryV2
    {
        string connectionString;
        public AuthorRepositoryV2(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Author> GetAllAuthors()
        {         
        
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try 
            {
                
                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
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
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try
            {

                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open(); //makes connection to database

                //if we reach here we are connected.

                //3. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"select * from authors where id='{id}'";


                //4. execute the command to get the result
                DbDataReader reader = command.ExecuteReader();

                //5. now loop through reader to get the results

                if (reader.Read())
                {
                    var author = new Author();

                    author.Id = reader["id"].ToString();
                    author.Name = reader["name"].ToString();
                    author.Biography = reader["biography"].ToString();
                    author.Email = reader["email"].ToString();
                    author.Photograph = reader["photograph"].ToString();

                    return author;
                }
                else
                    throw new InvalidIdException<string>(id,$"Invalid Author Id:{id}");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


        }

        public void AddAuthor(Author author)
        {
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try
            {

                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open(); //makes connection to database

                //if we reach here we are connected.

                //3. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"insert into Authors(id,name,biography,photograph,email)" +
                                      $"values ('{author.Id}','{author.Name}','{author.Biography}',"+
                                      $"        '{author.Photograph}','{author.Email}')";


                //4. execute the command to get the result
                var result = command.ExecuteNonQuery();

                //5. now loop through reader to get the results
                //return result == 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


        }

        public void UpdateAuthor(Author author)
        {
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try
            {

                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open(); //makes connection to database

                //if we reach here we are connected.

                //3. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"update Authors " +
                                      $"set name='{author.Name}',biography='{author.Biography}'," +
                                      $"    photograph='{author.Photograph}', email='{author.Email}' " +
                                      $"where id='{author.Id}'";


                //4. execute the command to get the result
                var result = command.ExecuteNonQuery();

                //5. now loop through reader to get the results
                //return result == 1;
                if (result == 0)
                    throw new InvalidIdException<string>(author.Id, $"No author with id :{author.Id}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


        }

        public void DeleteAuthor(string id)
        {
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try
            {

                //2. Get the connection object
                connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open(); //makes connection to database

                //if we reach here we are connected.

                //3. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();
                command.CommandText = $"delete from Authors where id='{id}'";


                //4. execute the command to get the result
                var result = command.ExecuteNonQuery();

                //5. now loop through reader to get the results
                if (result == 0)
                    throw new InvalidIdException<string>(id, $"Author Id:{id} Not found");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }


        }

    }
}
