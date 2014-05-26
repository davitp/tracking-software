using System.Collections.Generic;

namespace BusinessLayer {
    // user entity 
    // user will manipulate
    // data in of solution
    public class User : DALAble {
        #region Properties
        // unique id of user
        [DictionaryMember]
        public int UserId { get; protected set; }
        
        // username (login) of  user
        [DictionaryMember]
        public string Username { get; protected set; }

        // Password of user
        [DictionaryMember]
        public string Password { get; protected set; }

        // Role of user 
        [DictionaryMember]
        public int RoleId { get; protected set; }

        #endregion

        // initialize via constructor
        internal User(IDictionary<string, object> dalUser) {
            InitializeEntity(dalUser);
        }

        // default constructor
        public User() {
        }

    }
}
