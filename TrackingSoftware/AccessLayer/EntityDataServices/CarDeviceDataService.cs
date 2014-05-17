using System;
using System.Collections.Generic;

namespace DataAccessLayer {
    public class CarDeviceDataService : IEntityDataService {

        #region Implementation of IEntityDataService
        public IList<IDictionary<string, object>> ExecuteSet(string operation, object[] args) {
            throw new NotImplementedException();
        }

        public IDictionary<string, object> ExecuteScalar(string operation, object[] args) {
            throw new NotImplementedException();
        }

        public bool Insert(IDictionary<string, object> toSave, object[] args) {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id, object[] args) {
            throw new NotImplementedException();
        }
        #endregion

    }
}
