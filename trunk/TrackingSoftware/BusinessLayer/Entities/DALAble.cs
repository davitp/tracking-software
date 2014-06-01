using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer {
    // class describe DALability of 
    // entity
    // that means that our entity can be converted
    // to Dictionary
    // and can be built from Directory
    abstract public class DALAble {
        // generic ToDictionary() method
        virtual internal IDictionary<string, object> ToDictionary() {
            IDictionary<string, object> result = new Dictionary<string, object>();
            // business entity name
            string bEntity = this.GetType().Name;

            Mapper entityMapper = new Mapper(bEntity);

            // trying to build list of members
            // that have attribute [DictionaryMember]
            // it means that we have add member into dictionary
            // or to initialize with that key
            // and fille info

            var properties = this.GetType().GetProperties();

            // check if attribute is defined
            foreach(var prop in properties) {
                // if property is [DictionaryMember]
                if(Attribute.IsDefined(prop, typeof(DictionaryMemberAttribute))) {
                    // get DAL name of property
                    var propName = entityMapper.MapParameter(prop.Name);
                    // fill dictionary from fields having [DictionaryMember]
                    // attribute

                    // add pair into dictionary
                    // Key: propName
                    // Value: this.{prop.GetValue(this)}
                    result.Add(propName, (object) prop.GetValue((object) this));
                }

            }

            return result;
        }


        // initialize field  with fields of Dictionary from DAL
        virtual internal void InitializeEntity(IDictionary<string, object> plainObj) {
            // business entity name
            string bEntity = this.GetType().Name;

            // initialize mapper
            Mapper entityMapper = new Mapper(bEntity);

            // trying to build list of members
            // that have attribute [DictionaryMember]
            // it means that we have add member into dictionary
            // or to initialize with that key
            // and fille info

            var properties = this.GetType().GetProperties();

            // check if attribute is defined
            foreach(var prop in properties) {
                // if property is [DictionaryMember]
                if(Attribute.IsDefined(prop, typeof(DictionaryMemberAttribute))) {
                    // get DAL name of property
                    var propName = entityMapper.MapParameter(prop.Name);
                    // set value of this.{prop.Name} member = plainObj[propName]
                    // and converting value as needed
                    // Converting plainObj[propName] object to prop.GetType() type
                    // and set parameter value :)
                    prop.SetValue((object) this,
                        Convert.ChangeType(plainObj[propName], prop.GetType()));
                }
            }
        }


    }
}
