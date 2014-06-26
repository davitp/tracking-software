 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer {
    static public class ConnectionContext {
        // connection string
        public static string ConnectionString { get; private set; }

        // connection
        public static IDbConnection CreateConnection() {
            return new SqlConnection(ConnectionString);
        }

        // command
        public static IDbCommand CreateCommand() {
            return new SqlCommand();
        }

        public static SqlParameter CreateParameter() {
            return new SqlParameter();
        }

        static ConnectionContext() {
            ConnectionString = "Data Source=ADMIN-PC\\SQLEXPRESS; Initial Catalog=TrackingSoftwareDB;Integrated Security=SSPI";
        }
           
    }
}
