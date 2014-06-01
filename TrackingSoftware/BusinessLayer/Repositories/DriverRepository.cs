using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // repository of Driver objects
    public class DriverRepository : GenericRepository<Driver> {
    
        #region Driver-specific methods
        // method for filtering Drivers by name criteria
        IList<Driver> FilterByName(string name) {
            var result = new List<Driver>();

            // boxing parameters
            // operation name: Filter
            // parameter 0: filtering criteria - name
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("getByName", name);



            var retrive = dataService.ExecuteSet("Filter", args);

            foreach(var r in retrive)
                result.Add(new Driver(r));

            return result;
        }
        #endregion
    }
}
