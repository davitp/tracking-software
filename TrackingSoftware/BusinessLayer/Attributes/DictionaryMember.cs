using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer {
    // this attribute says 
    // that a member noted by [DictionaryMember]
    // need to be included to DAL Dictionary
    internal class DictionaryMemberAttribute : Attribute {
        
    }
}
