using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLayer {
    // T: Type of entity
    // K: Type of DataService
    // example:
    //    T = Car
    //    K = CarDataService
    public class GenericRepository <T>  : IDisposable
        where T: DALAble, new() {

        // dal-based name of entity 
        protected string entityMappedName;

        // data service 
        protected EntityDataService dataService;

        // mapper for this
        protected Mapper entityMapper;


        // initialize entityMappedName
        public GenericRepository() {
            // get name of entity
            string entityName = typeof(T).Name;

            // initialize mapper
            entityMapper = new Mapper(entityName);

            // get mapped name
            entityMappedName = entityMapper.MappedEntityName;

            // initialize dataService, passign as unit: entityMappedName
            dataService = new EntityDataService(entityMappedName);
        }


        #region Generic Repository Methods
        public IList<T> GetAll() {
            // retrive result from DAL as list of 
            // key-value pair dictionaries
            // calling "GetAll" operation 
            // which will return all T entities
            // represented as List of dictionaries
            

            IList<IDictionary<string, object>> retriveData 
                = dataService.ExecuteSet("GetAll", null);



            // fill a new list from retrived data
            IList<T> result = new List<T>();
            foreach(var dalObj in retriveData) {
                var newObj = new T();
                newObj.InitializeEntity(dalObj);
                result.Add(newObj);
            }

            return result;
        }

        public T GetById(int id) {

            IDictionary<string, object> retrive;
        
            // preparing argumenst for ExecuteScalar
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("id", id);


            // call "GetById" operation with specified
            // arguments
            retrive = dataService.ExecuteScalar("GetById", args);

            var newObj = new T();
            newObj.InitializeEntity(retrive);
            return newObj;
        }

        // create default entity and return
        public T Create() {
            IDictionary<string, object> retrive = dataService.ExecuteScalar("Create", null);
            T newObj = new T();
            newObj.InitializeEntity(retrive);
            return newObj;
        }


        public bool Update(T entity) {
            IDictionary<string, object> toSave = entity.ToDictionary();

            // no args
            int retrive = dataService.ExecuteNonQuery("Update", toSave);
            return (retrive > 0);
        }



        public bool DeleteById(int id) {             
            // delete car object from db 
            // preparing argumenst for ExecuteScalar
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("id", id);
            int retrive = dataService.ExecuteNonQuery("DeleteById", args);
            return (retrive > 0);
        }
        #endregion

        #region Implementation of Dispose
        void IDisposable.Dispose() {

        }
        #endregion

    }
}
