using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public class AuthorRepositoryV3
    {
        DbManager manager;
        string connectionString;
        public AuthorRepositoryV3(DbManager manager)
        {
            this.manager = manager;
        }
        public List<Author> GetAllAuthors()
        {
            return manager.ExecuteCommand(command =>
            {
                command.CommandText = "select * from authors";
                DbDataReader reader = command.ExecuteReader();
                var authors = new List<Author>();
                while (reader.Read())
                {
                    var author = new Author();

                    author.Id = reader["id"].ToString();
                    author.Name = reader["name"].ToString();
                    author.Biography = reader["biography"].ToString();
                    author.Email = reader["email"].ToString();
                    author.Photograph = reader["photograph"].ToString();

                    authors.Add(author);
                }

                return authors;
            });

        }
   
    
        public Author GetAuthorById(string id)
        {

            return manager.ExecuteCommand(command =>
            {
                command.CommandText = $"select * from authors where id='{id}'";
                DbDataReader reader = command.ExecuteReader();
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

            });
           
        }

        public void AddAuthor(Author author)
        {

            manager.ExecuteCommand(command =>
            {

                command.CommandText = $"insert into Authors(id,name,biography,photograph,email)" +
                                      $"values ('{author.Id}','{author.Name}','{author.Biography}',"+
                                      $"        '{author.Photograph}','{author.Email}')";


                var result = command.ExecuteNonQuery();

                return result;

            });

           

        }

        public void UpdateAuthor(Author author)
        {

            manager.ExecuteCommand(command =>
            {
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

                return true; //return anything to kill error
            });

           

        }

        public void DeleteAuthor(string id)
        {

            manager.ExecuteCommand(command =>
            {
                command.CommandText = $"delete from Authors where id='{id}'";


                //4. execute the command to get the result
                var result = command.ExecuteNonQuery();

                //5. now loop through reader to get the results
                if (result == 0)
                    throw new InvalidIdException<string>(id, $"Author Id:{id} Not found");

                return true; //return something.
            });
           


        }

    }
}
