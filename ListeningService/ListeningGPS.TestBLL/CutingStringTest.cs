using ListeningGPS.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Collections;
namespace ListeningGPS.TestBLL
{
    
    
    /// <summary>
    ///This is a test class for CutingStringTest and is intended
    ///to contain all CutingStringTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CutingStringTest
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


        ///// <summary>
        /////A test for CutingString Constructor
        /////</summary>
        //[TestMethod()]
        //public void CutingStringConstructorTest()
        //{
        //    CutingString target = new CutingString();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        /// <summary>
        ///A test for CutStringGPSData
        ///</summary>
        [TestMethod()]
        public void CutStringGPSDataTest()
        {
            string GPSData = "1012271731,0917667937,GPRMC,103119.509,A,1048.7359,N,10641.6280,E,0.75,57.42,271210,,,A*53,F, ,imei:354776036295647,105?";
            string[] value = {"GPRMC", "103119.509", "A", "1048.7359", "N", "10641.6280", "E", "0.75", "57.42", "271210", "", "", "A*53","imei:354776036295647"};
            ArrayList CutData = new ArrayList();
            CutData.AddRange(value);
            CutingString target = new CutingString(); // TODO: Initialize to an appropriate value
            string strGPSData = GPSData; // TODO: Initialize to an appropriate value
            ArrayList expected = CutData; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.CutStringGPSData(strGPSData,"GPRMC");
            CollectionAssert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
