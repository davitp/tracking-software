using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;


namespace DAL_Unit_Tests {
    [TestClass]
    public class DAL_UnitTest {
        [TestMethod]
        public void Tets_Entity_Mapper() {

            Mapper mapper = new Mapper("Car");
            Assert.AreEqual("car", mapper.MappedEntityName);

        }

        [TestMethod]
        public void Tets_Parameter_Mapper() {
            Mapper mapper = new Mapper("Car");
            Assert.AreEqual("id", mapper.MapParameter("Id"));
        }
    }
}
