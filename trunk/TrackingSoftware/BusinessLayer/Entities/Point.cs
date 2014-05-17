using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // BL entity Location to describe position of units
    public class Point : DALAble {

        // latitude 
        [DictionaryMember]
        public double Latitude { get; protected set; }
        // longitude
        [DictionaryMember]
        public double Longitude { get; protected set; }

        // direct construction
        public Point(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        // default constructor
        public Point() {
        }

        internal Point(IDictionary<string, object> plain) {
            InitializeEntity(plain);
        }

        public Point(string data) {
            data = data.Trim();
            var latlong = data.Split(new String[] { ", " }, StringSplitOptions.None);
            latlong[0].Remove(0, 1);
            latlong[1].Remove(latlong[0].Length - 1, 1);

            Latitude = Convert.ToDouble(latlong[0]);
            Longitude = Convert.ToDouble(latlong[1]);
            
        }

        public override string ToString() {
            string result = "{";
            result += Latitude.ToString();
            result += ", ";
            result += Longitude.ToString();
            result += "}";
            // {Lat, Long}
            return result;
        }

     
    }
}
