using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


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
            doc.Load(
                String.Format("{0}\\{1}{2}",
                Directory.GetCurrentDirectory(),
                unitMappingPath, unitMapperFile)
                );

            XmlNode node = doc.SelectSingleNode(
                String.Format("/Root/Add[@Unit='{0}']", unit)
                );

            unitFile = node.Attributes["File"].Value;
        }

       

        // get set of objects as returned value 
        // of "operation" with arguments "args"
        public virtual IList<IDictionary<string, object>> 
        ExecuteSet(string operation, IDictionary<string, object> args) {
            /* --------------------BODY--------------------------- */

            // load operation node from XML
            var opNode = GetNodeOfOperation(operation);
            // prepare result object (result list)
            IList<IDictionary<string, object>> result = new List<IDictionary<string, object>>();
            // prepare dbOperation object, passing node
            // nsManager and operation arguments
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);

            // perform operation and load result into DataTable
            DataTable reader = (DataTable) dbOperation.PerformOperation();

            // for each row in dataTable
            for(int i = 0; i < reader.Rows.Count; i++ ) {
                // convert single row to DAL entity (plain entity)
                IDictionary<string, object> singleResult = new Dictionary<string, object>();
                for(int j = 0; j < reader.Columns.Count; j++)
                    singleResult.Add(reader.Columns[j].ColumnName, reader.Rows[i][j]);
                // add entity to list
                result.Add(singleResult);
            }
            return result;
            /* ------------------END BODY------------------------- */
        }
        
        // get single object as returned value
        // of "operation" with arguments "args"
        public virtual IDictionary<string, object> 
        ExecuteSingle(string operation, IDictionary<string, object> args) {
            /* --------------------BODY--------------------------- */

            // load operation node from XML
            var opNode = GetNodeOfOperation(operation);
            // prepare result object
            IDictionary<string, object> result = new Dictionary<string, object>();
            // prepare dbOperation object, passing node
            // nsManager and operation arguments
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);

            // perform operation and load result into DataTable
            DataTable reader = (DataTable) dbOperation.PerformOperation();

            if(reader.Rows.Count != 1)
                throw new Exception("ExecuteSingle Operation returns wrong result");

            // i = 0 row present for shure
            for(int j = 0; j < reader.Columns.Count; j++)
                result.Add(reader.Columns[j].ColumnName, reader.Rows[0][j]);

            return result;
        }

        // Exequting non query that returns integer
        public virtual int 
        ExecuteNonQuery(string operation, IDictionary<string, object> args) {
            // prepare operation
            var opNode = GetNodeOfOperation(operation);
            DbOperation dbOperation = new DbOperation(opNode, nsMgr, args);

            // perform operation and get result
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
