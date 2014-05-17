using System;
using System.Collections.Generic;


namespace DataAccessLayer {
    public static class DataService {

        #region Mapping mechanism
        // reading XML file
        // which describes business entites and 
        // their names in DAL 
        public static class Mapper {
            // returns DAL name of given entitie's field
            public static string
             MapParameter(string businessEntityName, string field){
                throw new NotImplementedException();
            }
            
            // returns DAL name of given business entity
            // for example Car entity can have name car or car_table
            public static string MapEntity(string businessEntity) {
                throw new NotImplementedException();
            }
        }
        #endregion


    }
}
