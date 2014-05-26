using System.Collections.Generic;

namespace BusinessLayer {
    // rope of user
    public class UserRole : DALAble {
        #region Properties
        // id of role
        [DictionaryMember]
        public int RoleId { get; protected set; }

        // name of role
        [DictionaryMember]
        public string RoleName { get; protected set; }

        #endregion

        // initializer-constructor
        internal UserRole(IDictionary<string, object> dalObj){
            InitializeEntity(dalObj);
        }

        // default constructor
        public UserRole() {
        }
    }
}
