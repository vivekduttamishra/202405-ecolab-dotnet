using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils.Data
{
    class ConnectionInfo
    {
        public string ConnectionString { get; set; }
        public string ConnectionType { get; set; }
    }

    public class DefaultConnectionFactory
    {
        ConnectionInfo info;
        Type connectionType;
        public DefaultConnectionFactory(IConfiguration config,string connectionStringName) 
        {
            info = new ConnectionInfo();
            config.Bind($"ConnectionStrings:{connectionStringName}", info);
            connectionType = Type.GetType(info.ConnectionType);
        }

        public DbConnection Factory()
        {

            DbConnection connection =(DbConnection) Activator.CreateInstance(connectionType);
            connection.ConnectionString = info.ConnectionString;
            connection.Open();
            return connection;
        }
    }
}
