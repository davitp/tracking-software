using System;
using System.Collections.Generic;
using System.Xml;
using System.Configuration;


namespace DataAccessLayer {


        public class Mapper {

            // entity mapper file path
            private static string entityMapperFile;

            // BL name of entity
            private string entityName;
            // DAL name of entity
            public string MappedEntityName { get; private set; }

            // (BL attr, name, DAL attr. name) dictionary
            private IDictionary<string, string> MappedAttributes;


            // static initializer
            static Mapper() {
                entityMapperFile = @"MappingResources\Entities.xml";
            }

            public Mapper(string _entityName) {
                // initialize entity name
                entityName = _entityName;

                // create dictionary 
                MappedAttributes = new Dictionary<string, string>();

                // load mapper xml file
                XmlDocument doc = new XmlDocument();
                doc.Load(entityMapperFile);

                // setting up namespace manager
                XmlNamespaceManager namespaceMgr = new XmlNamespaceManager(doc.NameTable);
                namespaceMgr.AddNamespace("ns", "http://www.w3schools.com");
                // setting up xpath query
                string xQuery = "/ns:Entities/ns:Entity[@BusinessName='" + entityName + "']";
                XmlNode node = doc.SelectSingleNode(xQuery, namespaceMgr);

                // for example: 
                //          for Car entity value will be "car"
                MappedEntityName = node.Attributes["PlainName"].Value;

                // add Property tag attributes in dictionary
                foreach(XmlNode chNode in node.ChildNodes) {
                    var businessName = chNode.Attributes["BusinessName"].Value;
                    var plainName = chNode.Attributes["PlainName"].Value;
                    MappedAttributes.Add(businessName, plainName);
                }
            }

            // returns DAL name of given entitie's field
            public string MapParameter(string field){
                return MappedAttributes[field];
            }
            

        }


    
}
