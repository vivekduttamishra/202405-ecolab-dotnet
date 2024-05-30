using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    //public delegate DbConnection ConnectionFactory();

    public delegate T CommandExecutor<T>(DbCommand command);

    //public delegate T ReaderExtractor<T>(DbDataReader reader); //Func<DbDataReader,T>

    public class DbManager
    {
        //ConnectionFactory connectionFactory;
        Func<DbConnection> connectionFactory;
        public DbManager(Func<DbConnection> connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        //public T ExecuteCommand<T>(CommandExecutor<T> executor)
        public T ExecuteCommand<T>(Func<DbCommand,T> executor)
        {
            

            try
            {
                //1. Get the connection object
                using (var connection = connectionFactory())
                {
                    //2. Create a command that we execute on connection
                    DbCommand command = connection.CreateCommand();


                    //3. Now Let use use the command and return something.
                    //user logic here
                    return executor(command);
                } //connection auto closed
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOG: {ex.Message}");
                throw; //throw same ex you received.    
            }
            
        }
    
        /// <summary>
        /// Executes a select query a returns a list of T
        /// </summary>
        /// <typeparam name="T">object type query returns</typeparam>
        /// <param name="qry">select query</param>
        /// <param name="factory">converts reader data to an object</param>
        /// <param name="take">max records to read. 0 means all</param>
        /// <returns></returns>
        public List<T> Select<T>(string qry, Func<DbDataReader,T> factory, int take=0) 
        {
            return ExecuteCommand(command =>
            {
                command.CommandText = qry;
                var reader=command.ExecuteReader();
                var list = new List<T>();
                int count = 0;
                while(reader.Read())
                {
                    var t= factory(reader);
                    list.Add(t);
                    count++;
                    if (take > 0 && count == take)
                        break;
                }
                
                return list;
            });
        }
    
        public T FirstOrDefault<T>(string qry, Func<DbDataReader,T> factory)
        {
            var result = Select<T>(qry, factory, 1);
            if (result.Count > 0)
                return result[0];
            else
                return default(T);
        }

        /// <summary>
        /// Used for firing insert/update/delete using ExecuteNonQuery
        /// </summary>
        /// <param name="qry">sql query</param>
        /// <returns>rows affected.</returns>
        public int ExecuteUpdate(string qry)
        {
            return ExecuteCommand(command =>
            {
                command.CommandText = qry;
                return command.ExecuteNonQuery();
            });
        }
    }
}
