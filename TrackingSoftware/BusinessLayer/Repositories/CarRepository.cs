using System;
using System.Collections.Generic;
using DataAccessLayer;
                   
namespace BusinessLayer {
    public class CarRepository : GenericRepository<Car, CarDataService> {

        public string getDalName() {
            return DataService.Mapper.MapEntity("barev");
        }

        #region Car-specific methods
        // get state of car with carId and atTime parameters
        State GetState(int carId, DateTime atTime) {
            // boxing parameters
            // parameter 0: entity name
            // parameter 1: carId
            // parameter 2: atTime
            object[] param = new object[3];
            param[0] = (object) entityMappedName;
            param[1] = (object) carId;
            param[2] = (object) atTime;

            // retrive Scalar data
            CarDataService dataService = new CarDataService();
            IDictionary<string, object> retrive 
                = dataService.ExecuteScalar("GetState", param);

            return new State(retrive);
        }

        // get state history of car in range [start, end]
        IList<State> GetStateHistory(int carId, DateTime startTime, DateTime endTime) {
            IList<State> history = new List<State>();

            // boxing parameters
            // parameter 0: entity name
            // parameter 1: carId
            // parameter 2: start time
            // parameter 3: end time
            object[] parameters = new object[4];
            parameters[0] = (object) entityMappedName;
            parameters[1] = (object) carId;
            parameters[2] = (object) startTime;
            parameters[3] = (object) endTime;

            CarDataService dataService = new CarDataService();                         
            IList<IDictionary<string, object>> retrive 
                = dataService.ExecuteSet("GetStateHisory", parameters);

            // fill history list based on DAL answer
            foreach(var dalObj in retrive)
                history.Add(new State(dalObj));

            return history;
        }
        #endregion

    }
}
