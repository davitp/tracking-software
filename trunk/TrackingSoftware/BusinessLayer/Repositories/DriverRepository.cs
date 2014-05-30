using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // repository of Driver objects
    public class DriverRepository : GenericRepository<Driver, DriverDataService> {
    
        #region Driver-specific methods
        // method for filtering Drivers by name criteria
        IList<Driver> FilterByName(string name) {
            var result = new List<Driver>();

            // boxing parameters
            // operation name: Filter
            // parameter 0: entity name
            // parameter 1: filtering criteria - name
            object[] parameters = new object[2];
            parameters[0] = (object) entityMappedName;
            parameters[1] = (object) "name";

            DriverDataService dataService = new DriverDataService();
            var retrive = dataService.ExecuteSet("Filter", parameters);

            foreach(var r in retrive)
                result.Add(new Driver(r));

            return result;
        }
        #endregion
    }
}
