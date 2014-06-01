using System;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer {
    public class EntityDataService {

        // doing operation on this unit
        //      unit is DAL based name of entities
        protected string unit;

        // file path of current unit operations
        protected string unitFile;

        // private nsMgr
        protected XmlNamespaceManager nsMgr;

        // unit mapper data
        // this dictionary maps unit name to
        // file name describing operations
        protected static string unitMapperFile;

        // path of mapper files for unit mapping
        protected static string unitMappingPath;

        //static constructor for unitMapper init.
        static EntityDataService() {
            // init. mapping path
            unitMappingPath = @"MappingResources\SQLUnitMapping\";
            unitMapperFile = "UnitMapper.xml";
        }

        // initializing unit
        public EntityDataService(string unit_) {
            unit = unit_;

            XmlDocument doc = new XmlDocument();
            doc.Load(unitMappingPath + unitMapperFile);

            XmlNode node = doc.SelectSingleNode("/Root/Add[@Unit='" + unit + "']");

            unitFile = node.Attributes["File"].Value;
        }

       

        // get set of objects as returned value 
        // of "operation" with arguments "args"
        public virtual IList<IDictionary<string, object>> ExecuteSet(string operation, IDictionary<string, object> args) {
            var opNode = GetNodeOfOperation(operation);
            IList<IDictionary<string, object>> result = new List<IDictionary<string, object>>();
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);
            DataTable reader = (DataTable) dbOperation.PerformOperation();
            for(int i = 0; i < reader.Rows.Count; i++ ) {
                IDictionary<string, object> singleResult = new Dictionary<string, object>();
                for(int j = 0; j < reader.Columns.Count; j++)
                    singleResult.Add(reader.Columns[j].ColumnName, reader.Rows[i][j]);
                result.Add(singleResult);
            }
            return result;
        }
        
        // get single object as returned value
        // of "operation" with arguments "args"
        public virtual IDictionary<string, object> ExecuteScalar(string operation, IDictionary<string, object> args) {
            var opNode = GetNodeOfOperation(operation);
            IDictionary<string, object> result = new Dictionary<string, object>();
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);
            IDataReader reader = (IDataReader) dbOperation.PerformOperation();
            reader.Read();
            for(int i = 0; i < reader.FieldCount; i++)
                result.Add(reader.GetName(i), reader[i]);
            return result;
        }

        // Exequting non query that returns integer
        public virtual int ExecuteNonQuery(string operation, IDictionary<string, object> args) {
            var opNode = GetNodeOfOperation(operation);
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);

            int result;
            result = (int) dbOperation.PerformOperation();

            return result;
        }

        
        // get XmlNode of specified Operation
        private XmlNode GetNodeOfOperation(string operation) {
            // init doc
            XmlDocument doc = new XmlDocument();
            doc.Load(unitMappingPath + unitFile);

            // init namespace
            nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("ns", "http://www.w3schools.com");

            // doing query
            string xQuery = "/ns:Unit/ns:Operation[@Name='" + operation + "']";
            XmlNode operationNode = doc.SelectSingleNode(xQuery, nsMgr);
            if(operationNode == null)
                throw new Exception("Invalide Operation: " + operation);

            return operationNode;
        }
    }
}
