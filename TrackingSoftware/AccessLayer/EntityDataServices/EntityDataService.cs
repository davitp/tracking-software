using System;
using System.Collections.Generic;


namespace DataAccessLayer {
    public class EntityDataService {
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

        // insert object into DB with specified args
        public virtual bool Insert(IDictionary<string, object> toSave, object[] args) {
            throw new NotImplementedException();
        }

        // delete object from DB by id having specified arguments
        public virtual bool DeleteById(int id, object[] args) {
            throw new NotImplementedException();
        }
    }
}
