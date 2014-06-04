using System;
using System.Collections.Generic;
using DataAccessLayer;
using BusinessLayer;

namespace BusinessLayer{
    // Car class is a business entity
    // that describes car objects, having
    // id, driverid, car device and etc.
    public class Car : DALAble {

        #region Properties 
        // identify car
        [DictionaryMember]
        public int Id { get; protected set; }

        // Colors
        [DictionaryMember]
        public string Color { get; protected set; }

        [DictionaryMember]
        public string Manufacturer { get; protected set; }

        [DictionaryMember]
        public string Model { get; protected set; }

        #endregion

        // internal constructor that initializes 
        // car from DAL object
        internal Car(IDictionary<string, object> plain) {
            InitializeEntity(plain);
        }

        // default constructor
        public Car() {
        }
    }
}