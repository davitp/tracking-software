using System;
using System.Collections.Generic;


namespace DataAccessLayer {
    public class EntityDataService {

        // doing operation on this unit
        //      unit is DAL based name of entities
        protected string unit;

        // initializing unit
        public EntityDataService(string unit_) {
            unit = unit_;
        }

        // get set of objects as returned value 
        // of "operation" with arguments "args"
        public virtual IList<IDictionary<string, object>> ExecuteSet(string operation, object[] args) {
            throw new NotImplementedException();
        }
        
        // get single object as returned value
        // of "operation" with arguments "args"
        public virtual IDictionary<string, object> ExecuteScalar(string operation, object[] args) {
            throw new NotImplementedException();
        }

        // update object into DB with specified args
        public virtual bool Update(IDictionary<string, object> toSave, object[] args) {
            throw new NotImplementedException();
        }

        // delete object from DB by id having specified arguments
        public virtual bool DeleteById(int id, object[] args) {
            throw new NotImplementedException();
        }
        
        // creation of entity
        public virtual IDictionary<string, object> Create(object[] args){
            throw new NotImplementedException();
        }
    }
}
