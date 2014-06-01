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
            // parameter 0: getting by "SimNumber"
            object[] parameters = { (object) "SimNumber" };

            var retrive = dataService.ExecuteScalar("GetBy", parameters);

            return new CarDevice(retrive);
        }
        #endregion
    }
}
