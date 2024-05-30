using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementConsole01
{
    public  class DefaultConnectionFactory
    {
        string connectionString;
        Type connectionType;
        public DefaultConnectionFactory(string connectionStringName) 
        {
            connectionString = AppSettings.I[connectionStringName];
            
            var connectionTypeName = AppSettings.I["connection_type"];
            connectionType= Type.GetType(connectionTypeName);
        }

        public DbConnection Factory()
        {

            DbConnection connection =(DbConnection) Activator.CreateInstance(connectionType);
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }
    }
}
