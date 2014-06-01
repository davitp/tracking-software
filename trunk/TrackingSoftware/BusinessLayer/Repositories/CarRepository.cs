using System;
using System.Collections.Generic;
using DataAccessLayer;
                   
namespace BusinessLayer {
    public class CarRepository : GenericRepository<Car> {

        #region Car-specific methods
        // get state of car with carId and atTime parameters
        State GetState(int carId, DateTime atTime) {
            // boxing parameters
            // parameter 0: carId
            // parameter 1: atTime
            object[] param = {(object) carId, (object) atTime };

            // retrive Scalar data
            IDictionary<string, object> retrive 
                = dataService.ExecuteScalar("GetState", param);

            return new State(retrive);
        }

        // get state history of car in range [start, end]
        IList<State> GetStateHistory(int carId, DateTime startTime, DateTime endTime) {
            IList<State> history = new List<State>();

            // boxing parameters
            // parameter 0: carId
            // parameter 1: start time
            // parameter 2: end time
            object[] parameters = {
                (object) entityMappedName,
                (object) carId,
                (object) startTime,
                (object) endTime
            };

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
