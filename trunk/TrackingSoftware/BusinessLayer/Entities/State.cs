using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // State object to describe car
    // state (fuel level, oil and etc.)
    public class State : DALAble {
        // Fuel percentage 
        [DictionaryMember]
        public double FuelLevel { get; protected set; }

        // When car was in this state
        [DictionaryMember]
        public DateTime When { get; protected set; }

        // need to change oil
        [DictionaryMember]
        public Boolean NeedToChangeOil { get; protected set; }

        /// <summary>
        /// coordiantes
        /// </summary>
        [DictionaryMember]
        public double Latitude { get; protected set; }

        [DictionaryMember]
        public double Longitude { get; protected set; }

        // car speed (km/h)
        [DictionaryMember]
        public int Speed { get; protected set; }

        



        // initialize from Dictionary
        internal State(IDictionary<string, object> statePlain) {
            InitializeEntity(statePlain);
        }

        // default constructor
        public State() {
        }

    }
}
