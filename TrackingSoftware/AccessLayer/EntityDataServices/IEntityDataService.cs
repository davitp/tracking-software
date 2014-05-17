using System;
using System.Collections.Generic;


namespace DataAccessLayer {
    public interface IEntityDataService {
        // get set of objects as returned value 
        // of "operation" with arguments "args"
        IList<IDictionary<string, object>> ExecuteSet(string operation, object[] args);
        
        // get single object as returned value
        // of "operation" with arguments "args"
        IDictionary<string, object> ExecuteScalar(string operation, object[] args);

        // insert object into DB with specified args
        bool Insert(IDictionary<string, object> toSave, object[] args);

        // delete object from DB by id having specified arguments
        bool DeleteById(int id, object[] args);
    }
}
