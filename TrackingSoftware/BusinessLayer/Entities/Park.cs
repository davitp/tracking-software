using System;
using System.Collections.Generic;
using DataAccessLayer;


namespace BusinessLayer {
    // Park is a polygon represented
    // as list of locations
    public class Park : DALAble {

        // to identify Park
        [DictionaryMember]
        public int ParkId { get; private set; }

        [DictionaryMember]
        public string GeoDataString {
            get {
                string data = "";
                for(int i = 0; i < Border.Count - 1; i++)
                    data += Border[i].ToString() + "; ";
                data += Border[Border.Count - 1].ToString(); 
                return data;
            }
            set {
                Border.Clear();
                string[] data = value.Split(new string[] { "; " }, StringSplitOptions.None);
                foreach(var d in data)
                    Border.Add(new Point(d));


            }
        }

        // precondition: List of Points can be 
        // border of Park if first and last locations are the same
        public List<Point> Border { get; set; }



        // internal constructor based on DAL park
        internal Park(IDictionary<string, object> park) {
            InitializeEntity(park);
        }



    }
}
