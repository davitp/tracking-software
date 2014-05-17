using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // device that will be built in car
    public class CarDevice : DALAble {

        // device identifier
        [DictionaryMember]
        public int Id { get; protected set; }

        // Sim number installed in device
        // this is unique number
        [DictionaryMember]
        public string SimNumber { get; protected set; }

        [DictionaryMember]
        public string DeviceModel { get; protected set; }

        // initialize object from plain dictionary
        internal CarDevice(IDictionary<string, object> plainCarDevice) {
            InitializeEntity(plainCarDevice);
        }

        // default constructor
        // needed for GenericRepository
        // constraint
        public CarDevice() {
        }

        
    }
}
