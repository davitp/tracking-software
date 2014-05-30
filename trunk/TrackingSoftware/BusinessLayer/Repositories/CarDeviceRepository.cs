using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    public class CarDeviceRepository : GenericRepository<CarDevice, CarDeviceDataService> {
        #region Methods, that are specific for CarDevices
        // Get CarDevice having specified Sim Card number
        CarDevice GetBy(string simNumber) {

            // boxing parameters
            // operation name: GetBy
            // parameter 0: entity name
            // parameter 1: getting by "SimNumber"
            object[] parameters = new object[2];
            parameters[0] = (object) entityMappedName;
            parameters[1] = (object) "SimNumber";

            CarDeviceDataService dataService = new CarDeviceDataService();
            var retrive = dataService.ExecuteScalar("GetBy", parameters);

            return new CarDevice(retrive);
        }
        #endregion
    }
}
