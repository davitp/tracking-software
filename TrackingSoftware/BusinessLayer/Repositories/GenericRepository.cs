using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // T: Type of entity
    // K: Type of DataService
    // example:
    //    T = Car
    //    K = CarDataService
    public class GenericRepository <T, K>  : IDisposable
        where K: EntityDataService, new() 
        where T: DALAble, new() {

        // dal-based name of entity 
        protected string entityMappedName;

        // initialize entityMappedName
        public GenericRepository() {
            string entityName = typeof(T).Name;
            // get mapped name
            entityMappedName = DataService.Mapper.MapEntity(entityName);
        }


        #region Generic Repository Methods
        IList<T> GetAll() {
            // retrive result from DAL as list of 
            // key-value pair dictionaries
            K dataService = new K();                               
            // calling "GetAll" operation 
            // which will return all T entities
            // represented as List of dictionaries
            
            object[] parameters = { (object) entityMappedName };

            IList<IDictionary<string, object>> retriveData 
                = dataService.ExecuteSet("GetAll", parameters);



            // fill a new list from retrived data
            IList<T> result = new List<T>();
            foreach(var dalObj in retriveData) {
                var newObj = new T();
                newObj.InitializeEntity(dalObj);
                result.Add(newObj);
            }

            return result;
        }

        T GetById(int id) {
            // dataservice
            K dataService = new K();                               

            IDictionary<string, object> retrive;
        
            // preparing argumenst for ExecuteScalar
            
            object[] args = { (object) entityMappedName, (object) id };


            // call "GetById" operation with specified
            // arguments
            retrive = dataService.ExecuteScalar("GetById", args);

            var newObj = new T();
            newObj.InitializeEntity(retrive);
            return newObj;
        }


        bool Save(T entity) {
            K dataService = new K();
            object[] parameters = { (object) entityMappedName };       
            IDictionary<string, object> toSave = entity.ToDictionary();

            // passing as argument only entity name
            return dataService.Insert(toSave, parameters);
        }



        bool DeleteById(int id) {
            K dataService = new K();
            object[] parameters = { (object) entityMappedName };                
            // delete car object from db 
            // with only parameter - entity name
            return dataService.DeleteById(id, parameters);
        }
        #endregion

        #region Implementation of Dispose
        void IDisposable.Dispose() {

        }
        #endregion

    }
}
