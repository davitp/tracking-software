using System;
using System.Collections.Generic;

namespace ListenerServer {
    public static class Protocol {


 
       
        public static IDictionary<string, object> ReciveData(string input) {
            // prepare result dictionary
            var result = new Dictionary<string, object>();


            // split by ';'
            var parameters = input.Split(new char[] {';'});
            /* starting protocol description */
            #region
            // carId - integer
            int carId = Convert.ToInt32(parameters[0].Trim());
            // fuelLevel
            double fuelLevel = Convert.ToDouble(parameters[1].Trim());
            // latitude and longitude
            double latitude = Convert.ToDouble(parameters[2].Trim());
            double longitude = Convert.ToDouble(parameters[3].Trim());
            // speed
            int speed = Convert.ToInt32(parameters[4].Trim());
            // need to change oil
            bool changeOil = Convert.ToBoolean(parameters[5].Trim());
            // state time
            DateTime stateTime = DateTime.FromBinary(
                Convert.ToInt64(parameters[6])
                );
            #endregion
            

            /* fill dictionary */
            result.Add("carId", carId);
            result.Add("fuelLevel", fuelLevel);
            result.Add("latitude", latitude);
            result.Add("longitude", longitude);
            result.Add("speed", speed);
            result.Add("changeOil", changeOil);
            result.Add("stateTime", stateTime);


            return result;
        }
    }
}
