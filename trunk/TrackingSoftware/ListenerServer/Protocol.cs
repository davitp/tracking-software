using System;
using System.Collections.Generic;
using System.Globalization;

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
            int carId = int.Parse(parameters[0]);
            // fuelLevel
            double fuelLevel = double.Parse(parameters[1]);
            // latitude and longitude
            double latitude = double.Parse(parameters[2]);
            double longitude = double.Parse(parameters[3]);
            // speed
            int speed = int.Parse(parameters[4]);
            // need to change oil
            bool changeOil = bool.Parse(parameters[5]);
            DateTime stateTime = DateTime.ParseExact(parameters[6], "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);

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
