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

        static ConnectionContext() {
            ConnectionString = "Data Source=DAVIT-WIN7; Initial Catalog=TrackingSoftwareDB;Integrated Security=SSPI";
        }
           
    }
}
