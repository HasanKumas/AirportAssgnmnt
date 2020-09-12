using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirportAssgnmnt.Models.Tests
{
    [TestClass()]
    public class AirportTests
    {    
        private Airport airport;
        private Airplane airplane1;
        private Airplane airplane2;

        [TestInitialize]
        public void PrepForArrange()
        {
            airport = new Airport("Amsterdam");
            airplane1 = airport.RequestPlane("ABC123");
            airplane2 = airport.RequestPlane("PLA166");
        }

        [TestMethod()]
        public void AddAirplanePlaneTest()
        {
            airport.AddAirplane("TTT111", AirplaneTypes.CARGO);
            airplane1 = airport.RequestPlane("TTT111");

            Assert.AreEqual(airplane1.PlaneIdentification, "TTT111");
        }
        [TestMethod()]
        public void RequestPlaneTest()
        {
            airplane1 = airport.RequestPlane("SPC777");
            airplane2 = airport.RequestPlane("TTT111");

            Assert.AreEqual(airplane1.PlaneIdentification, "SPC777");
            Assert.IsNull(airplane2);
        }
    }

    [TestClass()]
    public class AirplaneTests
    {    
        private Airport airport;
        private Airplane airplane1;

        [TestInitialize]
        public void PrepForArrange()
        {
            airport = new Airport("Amsterdam");
            airplane1 = airport.RequestPlane("ABC123");
        }

        [TestMethod()]
        public void TakeOffTest()
        {
            airplane1.TakeOff();

            Assert.AreEqual(airplane1.IsCurrentlyFlying, true);
        }
        [TestMethod()]
        public void LandTest()
        {
            airplane1.TakeOff();
            airplane1.Land();

            Assert.AreEqual(airplane1.IsCurrentlyFlying, false);
        }
    }
    [TestClass()]
    public class CargoPlaneTests
    {
        [TestMethod()]
        public void LoadTest()
        {
            CargoPlane airplane1 = new CargoPlane("EEE123");
            airplane1.Load(50);

            Assert.AreNotEqual(airplane1.CurrentAmountOfCargo, 50);
            Assert.AreEqual(airplane1.CurrentAmountOfCargo, 20);
        }
        [TestMethod()]
        public void UnLoadTest()
        {
            CargoPlane airplane1 = new CargoPlane("EEE123");
            airplane1.Unload();

            Assert.AreEqual(airplane1.CurrentAmountOfCargo, 0);
        }
        [TestMethod()]
        public void HasRoomsTest()
        {
            CargoPlane airplane1 = new CargoPlane("EEE123");
            airplane1.Load(10);

            Assert.IsTrue(airplane1.HasRooms());
        }
        [TestMethod()]
        public void HasNoRoomsTest()
        {
            CargoPlane airplane1 = new CargoPlane("EEE123");
            airplane1.Load(50);

            Assert.IsFalse(airplane1.HasRooms());
        }
    }
}