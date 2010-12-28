using ListeningGPS.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListeningGPS.TestBLL
{
    
    
    /// <summary>
    ///This is a test class for GPSDataDAOTest and is intended
    ///to contain all GPSDataDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GPSDataDAOTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CutStrCoordinates
        ///</summary>
        [TestMethod()]
        public void CutStrCoordinatesTest()
        {
            GPSDataDAO target = new GPSDataDAO(); // TODO: Initialize to an appropriate value
            string pCoordinates = "1048.7359"; // TODO: Initialize to an appropriate value
            string pType = "latitude"; // TODO: Initialize to an appropriate value
            string expected = "10.8122650146484"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.CutStrCoordinates(pCoordinates, pType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConvertSpeed
        ///</summary>
        [TestMethod()]
        public void ConvertSpeedTest()
        {
            GPSDataDAO target = new GPSDataDAO(); // TODO: Initialize to an appropriate value
            string pSpeed = "1.25"; // TODO: Initialize to an appropriate value
            string expected = "2"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ConvertSpeed(pSpeed);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
