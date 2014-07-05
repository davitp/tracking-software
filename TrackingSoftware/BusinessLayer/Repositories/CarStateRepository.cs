using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    public class CarStateRepository {

        // dal-based name of entity 
        protected string entityMappedName;

        // data service 
        protected EntityDataService dataService;

        // mapper for this
        protected Mapper entityMapper;

        public CarStateRepository() {
            // get name of entity
            string entityName = typeof(CarState).Name;

            // initialize mapper
            entityMapper = new Mapper(entityName);

            // get mapped name
            entityMappedName = entityMapper.MappedEntityName;

            // initialize dataService, passign as unit: entityMappedName
            dataService = new EntityDataService(entityMappedName);
        }
        // get last known state of car by id
        public CarState GetLastState(int id){
            // prepare arguments
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("id", id);

            // retrive result
            IDictionary<string, object> retrive = dataService.ExecuteSingle("GetLastState", args);

            // return result
            return new CarState(retrive);
        }

        // get car state
        public IList<CarState> GetHistory(int id, DateTime start, DateTime end) {
            // arguments
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("id", id);
            args.Add("start", start);
            args.Add("end", end);

            var retrive = dataService.ExecuteSet("GetStateHistory", args);
            IList<CarState> result = new List<CarState>();
            foreach(var r in retrive) 
                result.Add(new CarState(r));

            return result;
        }
    }
}
