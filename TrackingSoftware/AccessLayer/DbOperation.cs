using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer {
    internal class DbOperation {

        private CommandType commandType;
        private string commandText;
        private IList<Tuple<string, object, DbType, int?>> parameters;
        private string returnType;

        public DbOperation(XmlNode opNode, XmlNamespaceManager ns, IDictionary<string, object> pValues) {
            parameters = new List<Tuple<string, object, DbType, int?>>();
            // initialize commandText
            commandText = opNode.SelectSingleNode("ns:CommandText", ns).InnerText;
            returnType = opNode.SelectSingleNode("ns:ReturnType", ns).InnerText;

            // initlialize commandtype
            Enum.TryParse<CommandType>(
                opNode.SelectSingleNode("ns:CommandType", ns).InnerText,
                out commandType);

            XmlNodeList args = opNode.SelectNodes("ns:Parameters/ns:Add", ns);
            if(args == null)
                return;
            foreach(XmlNode arg in args) {
                string pName = arg.Attributes["Name"].Value;
                object pValue = pValues[pName];
                DbType type = new DbType();
                Enum.TryParse<DbType>(arg.Attributes["DbType"].Value, out type);
                int? size = null;
                if(arg.Attributes["ParamSize"] != null)
                    size = Convert.ToInt32(arg.Attributes["ParamSize"].Value);
                parameters.Add(new Tuple<string, object, DbType, int?>(pName, pValue, type, size));

            }
        }

        public object PerformOperation() {
            object result;
            using(IDbConnection connection = ConnectionContext.CreateConnection()) {
                using(IDbCommand command = ConnectionContext.CreateCommand()) {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.CommandText = commandText;
                    if(parameters.Count > 0) {
                        foreach(var p in parameters) {
                            var newParam = command.CreateParameter();
                            newParam.DbType = p.Item3;
                            newParam.ParameterName = p.Item1;
                            newParam.Value = p.Item2;
                            if(p.Item4 != null)
                                newParam.Size = (int) p.Item4;
                        }
                    }

                    switch(returnType) {
                      
                        case "Set":
                            result = new DataTable();
                            var reader = command.ExecuteReader();
                            ((DataTable) result).Load(reader);
                            break;
                        case "Scalar":
                            result = command.ExecuteScalar();
                            break;
                        default:
                            result = command.ExecuteNonQuery();
                            break;
                    }

                }
            }
            return result;
        }


    }
}
