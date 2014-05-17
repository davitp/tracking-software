using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer {
    public class CarDataService : IEntityDataService {
        #region IEntityDataService implemetation
        // get set of objects as returned value 
        // of "operation" with arguments "args"
        public IList<IDictionary<string, object>> ExecuteSet(string operation, object[] args) {
            throw new NotImplementedException();
        }

        // get single object as returned value
        // of "operation" with arguments "args"
        public IDictionary<string, object> ExecuteScalar(string operation, object[] args) {
            throw new NotImplementedException();
        }

        // insert object into DB with specified args
        public bool Insert(IDictionary<string, object> toSave, object[] args) {
            throw new NotImplementedException();
        }

        // delete object from DB by id having specified arguments
        public bool DeleteById(int id, object[] args) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
