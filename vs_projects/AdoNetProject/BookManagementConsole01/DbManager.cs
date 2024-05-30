using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public delegate DbConnection ConnectionFactory();

    public delegate T CommandExecutor<T>(DbCommand command);

    public class DbManager
    {
        ConnectionFactory connectionFactory;
        public DbManager(ConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public T ExecuteCommand<T>(CommandExecutor<T> executor)
        {
            //1. Get a provider factory to get connection and other objects
            DbConnection connection = null;

            try
            {
                //1. Get the connection object
                connection = connectionFactory();

                //2. Create a command that we execute on connection
                DbCommand command = connection.CreateCommand();


                //3. Now Let use use the command and return something.
                //user logic here
                return executor(command);
                
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
