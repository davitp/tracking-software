using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // Driver is a BL entity that provides 
    // information about car drivers 
    // (id, name, tel ... etc... )
    public class Driver : DALAble {
        #region Properties
        // unique id to identify Driver
        [DictionaryMember]
        public int DriverId { get; protected set; }

        // Name Parameter of Driver
        [DictionaryMember]
        public string Name { get; protected set; }

        // Cellphone number of driver
        [DictionaryMember]
        public string Tel { get; protected set; }

        // Salary of driver (per month)
        [DictionaryMember]
        public decimal Salary { get; protected set; }
        #endregion
        // internal constructor to build Driver object from dictionary
        internal Driver(IDictionary<string, object> plainDriver) {
            InitializeEntity(plainDriver);    
        }

        // default constructor
        public Driver(){
        }

  


     



    }
}