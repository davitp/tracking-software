using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    public class CarDeviceRepository : GenericRepository<CarDevice> {
        #region Methods, that are specific for CarDevices
        // Get CarDevice having specified Sim Card number
        CarDevice GetBy(string simNumber) {

            // boxing parameters
            // operation name: GetBy
            // parameter getBy: getting by "SimNumber"
            // preparing argumenst for ExecuteScalar
            IDictionary<string, object> args = new Dictionary<string, object>();
            args.Add("filterBySim", "SimNumber");

            var retrive = dataService.ExecuteScalar("GetBy", args);

            return new CarDevice(retrive);
        }
        #endregion
    }
}
