using System;
using System.Collections.Generic;
using System.Configuration;


namespace DataAccessLayer {
    public static class DataService {

        #region Mapping mechanism
        // reading XML file
        // which describes business entites and 
        // their names in DAL 
        public static class Mapper {

            // entity mapper file relative path
            private static string entityMapperFile;

            // static initializer
            static Mapper() {
                entityMapperFile = ConfigurationManager.AppSettings["EntityMapper"];
                Console.WriteLine("Mapper is initialized with file: " + entityMapperFile);
            }

            // returns DAL name of given entitie's field
            public static string
             MapParameter(string businessEntityName, string field){
                 return "OK_String1";
            }
            
            // returns DAL name of given business entity
            // for example Car entity can have name car or car_table
            public static string MapEntity(string businessEntity) {
                return "OK_String2";
            }
        }
        #endregion


    }
}
