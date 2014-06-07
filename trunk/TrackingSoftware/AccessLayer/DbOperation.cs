using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer {
    internal class DbOperation {
        // type of command
        // may be :
        // stored procedures or text queries
        private CommandType commandType;

        // name of stored procedure or query
        private string commandText;


        /// <summary>
        /// List of parameters
        /// each parameter consists of
        /// parameter name - Item1
        /// parameter
        /// </summary>
        private IList<Tuple<string, object, SqlDbType, int>> parameters;

        // return type of operation: Set, Scalar, NonQuery
        private string returnType;

        // prepare object for operation execution
        public DbOperation(XmlNode opNode, XmlNamespaceManager ns, IDictionary<string, object> pValues) {
            // prepare list of parameters
            parameters = new List<Tuple<string, object, SqlDbType, int>>();
            // initialize commandText
            // readin tag <CommandText> data </CommandText> from XML node
            commandText = opNode.SelectSingleNode("ns:CommandText", ns).InnerText;
            // initialize returnType
            // readin tag <ReturnType> data </ReturnType> from XML node
            returnType = opNode.SelectSingleNode("ns:ReturnType", ns).InnerText;


            // initlialize commandType
            // reading CommandType tag value from XML
            // and trying to parse it as CommandType enum
            Enum.TryParse<CommandType>(
                opNode.SelectSingleNode("ns:CommandType", ns).InnerText,
                out commandType);

            /* starting parameters initialization */

            // read arguments of command reprented as <Add> tags
            // <Parameters>
            //      <Add Name="paramName" DbType="varchar" ParamSize="20" />
            //      ........
            // </Parameters>

            XmlNodeList args = opNode.SelectNodes("ns:Parameters/ns:Add", ns);
            // if no parameters - just exit function
            if(args == null)
                return;

            // if command has parameters
            foreach(XmlNode arg in args) {
                if(pValues == null)
                    break;
                // get from Add tag Name parameter
                string pName = arg.Attributes["Name"].Value;
                // get value object from dictionary
                object pValue = pValues[pName];

                // parse DbType attribute as SqlDbType enumeration
                SqlDbType type = new SqlDbType();
                Enum.TryParse<SqlDbType>(arg.Attributes["DbType"].Value,       
                    out type);

                // parse ParamSize attribute
                // this attribute is optional
                // so size can be null
                int? size = null;
                if(arg.Attributes["ParamSize"] != null)
                    size =  Convert.ToInt32(arg.Attributes["ParamSize"].Value); ;

                if(size == null)
                    size = 0;

                // add to parameters list
                var newParameter = new Tuple<string, object, SqlDbType, int>(pName, pValue, type, (int) size);
                parameters.Add(newParameter);

            }
        }


        /* perform DB operation */
        public object PerformOperation() {
            // our operation returns object 
            // user need to cast result for his own
            // purposes.. Can be casted to 
            // int: for NonQuer
            // object: for scalar
            // DataTable: from Set
            object result;

            // autodisposing connection
            using(IDbConnection connection = ConnectionContext.CreateConnection()) {
                // autodisposing command
                using(IDbCommand command = ConnectionContext.CreateCommand()) {
                    // open connection
                    connection.Open();
                    // set connection specific properties
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.CommandText = commandText;

                    // if there is query-parameters to set 
                    foreach(var p in parameters) {
                        // create new parameter
                        var newParam = command.CreateParameter();
                        // set parameter type (int, varchar, ...)
                        newParam.DbType = (DbType) p.Item3;
                        // set parameter name
                        // for example we are passing id parameter
                        // we need to write here @id
                        newParam.ParameterName = "@" + p.Item1;
                        // assign parameter value 
                        newParam.Value = p.Item2;
                        // if there is size to assign
                        if(p.Item4 != 0)
                            newParam.Size = p.Item4;

                        // add parameter to command
                        command.Parameters.Add(newParam);
                    }
                    
                    // we need to know
                    // what we are expecting from
                    // this operation - Set, Scalar or an Integer
                    switch(returnType) {
                            // if we are expecting set
                            // perform command.ExecuteReader()
                            // and load reader into offline dataTable
                        case "Set":
                            result = new DataTable();
                            var reader = command.ExecuteReader();
                            ((DataTable) result).Load(reader);
                            break;

                            // if we are expecting scalar
                            // performing command.ExecuteScalar()
                        case "Scalar":
                            result = command.ExecuteScalar();
                            break;

                            // for other cases when we need only
                            // number of affected rows 
                            // performing command.ExecuteNonQuery()
                        default:
                            result = command.ExecuteNonQuery();
                            break;
                    } // switch case
                } // using command
            } // using connection

            return result;
        }


    }
}
