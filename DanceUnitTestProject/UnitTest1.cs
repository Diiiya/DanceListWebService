using DanceDLL;
using DanceWebServiceListAndTesting.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DanceUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly DancesController _controller = new DancesController();

        [TestInitialize] // run before each method
        public void Init()
        {
            _controller.ReInitialize();
            Microsoft.VisualStudio.TestTools.UnitTesting.Logging.Logger.LogMessage("HEY");
        }


        [TestMethod]
        public void TestGet()
        {
            IEnumerable<Dance> dances = _controller.Get();
            Assert.AreEqual(3, dances.Count());

            Dance dance = _controller.Get(1);
            Assert.AreEqual("Salsa", dance.DName);

            dance = _controller.Get(100);
            Assert.IsNull(dance);

        }

        [TestMethod]
        public void TestDelete()
        {
            int howMany = _controller.Delete(100);
            Assert.AreEqual(0, howMany);

            howMany = _controller.Delete(1);
            Assert.AreEqual(1, howMany);

            IEnumerable<Dance> dances = _controller.Get();
            Assert.AreEqual(2, dances.Count());
        }

        [TestMethod]
        public void TestPost()
        {
            Dance newDance = new Dance
            {
                DName = "Samba",
                DDescription = "...",
                Photo = "",
                Country = "Unknown",
                TimeAppeared = 1800,
                DType = "Latino",
                AddedDate = new System.DateTime()
            };
            Dance newD = _controller.Post(newDance);
            Assert.AreEqual(4, newD.Id);
        }

        [TestMethod]
        public void TestPut()
        {
            Dance newDance = new Dance
            {
                DName = "Rumba",
                DDescription = "...",
                Photo = "",
                Country = "Unknown",
                TimeAppeared = 1800,
                DType = "Latino",
                AddedDate = new System.DateTime()
            };
            Dance d = _controller.Put(3, newDance);
            Assert.AreEqual("Rumba", d.DName);
            Dance d2 = _controller.Get(3);
            Assert.AreEqual("Rumba", d2.DName);
        }
    }

}
