using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // T: Type of entity
    // K: Type of DataService
    // example:
    //    T = Car
    //    K = CarDataService
    abstract public class GenericRepository <T, K> 
        where K: IEntityDataService, new() 
        where T: DALAble, new() {

        // an instanse of CarDataService
        // that allows to operate with DAL 
        protected K dataService;

        // default constructor, that
        // initializes dataService object
        public GenericRepository() {
            dataService = new K();
        }

        #region Generic Repository Methods
        IList<T> GetAll() {
            // retrive result from DAL as list of 
            // key-value pair dictionaries

            // calling "All" operation 
            // which will return all T entities
            // represented as List of dictionaries
            // no need to pass additional arguments
            IList<IDictionary<string, object>> retriveData 
                = dataService.ExecuteSet("All", null);

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
            IDictionary<string, object> retrive;
        
            // preparing argumenst for ExecuteScalar
            // method of CarDataService
            object[] args = new object[1];
            // passing car id as first paramenter
            args[0] = (object) id;

            // call "GetById" operation with specified
            // arguments
            retrive = dataService.ExecuteScalar("GetById", args);

            var newObj = new T();
            newObj.InitializeEntity(retrive);
            return newObj;
        }


        bool Save(T entity) {

            IDictionary<string, object> toSave = entity.ToDictionary();
            // saving without arguments
            return dataService.Insert(toSave, null);
        }



        bool DeleteById(int id) {
            // delete car object from db without parameters
            return dataService.DeleteById(id, null);
        }
        #endregion

    }
}
