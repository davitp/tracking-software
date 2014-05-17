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
            // parameter 0: filtering criteria - name
            object[] parameters = new object[1];
            parameters[0] = (object) "name";


            var retrive = dataService.ExecuteSet("Filter", parameters);

            foreach(var r in retrive)
                result.Add(new Driver(r));

            return result;
        }
        #endregion
    }
}
