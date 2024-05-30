using BookManagementConsole01.Tests;
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
        DbManager manager;
        string connectionString;
        public AuthorRepository(DbManager manager)
        {
            this.manager = manager;
        }

        private Author AuthorFactory(DbDataReader reader)
        {
            var author = new Author();
            author.Id = reader["id"].ToString();
            author.Name = reader["name"].ToString();
            author.Biography = reader["biography"].ToString();
            author.Email = reader["email"].ToString();
            author.Photograph = reader["photograph"].ToString();
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            var qry = "select * from authors";

            return manager.Select(qry, AuthorFactory);

        }
   
    
        public Author GetAuthorById(string id)
        {

            var author= manager.FirstOrDefault($"select * from authors where id='{id}'", AuthorFactory);
            if(author==null)
                throw new InvalidIdException<string>(id,$"Invalid Author: '{id}'");
            return author;
        }

        public void AddAuthor(Author author)
        {
            var qry = $"insert into Authors(id,name,biography,photograph,email)" +
                    $"values ('{author.Id}','{author.Name}','{author.Biography}'," +
                    $"        '{author.Photograph}','{author.Email}')";

            try
            {

                manager.ExecuteUpdate(qry);

            }catch(SqlException ex)
            {
                throw new DuplicateIdException<string>(author.Id, $"Duplicate id: {author.Id}",ex);
            }

           

        }

        public void UpdateAuthor(Author author)
        {

            var qry = $"update Authors " +
                                      $"set name='{author.Name}',biography='{author.Biography}'," +
                                      $"    photograph='{author.Photograph}', email='{author.Email}' " +
                                      $"where id='{author.Id}'";

            var result= manager.ExecuteUpdate(qry);
            if (result == 0)
                throw new InvalidIdException<string>(author.Id, $"No author with id :{author.Id}");

 
           

        }

        public void DeleteAuthor(string id)
        {
            var result =manager.ExecuteUpdate($"delete from Authors where id='{id}'");

            if (result == 0)
                throw new InvalidIdException<string>(id, $"Author Id:{id} Not found");
        }

    }
}
