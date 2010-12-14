using WebsiteGPS.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Data;

namespace WebsiteGPS.Library.UTest
{
    
    
    /// <summary>
    ///This is a test class for ReadXMLTest and is intended
    ///to contain all ReadXMLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ReadXMLTest
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
        ///A test for ReadXML Constructor
        ///</summary>
        [TestMethod()]
        public void ReadXMLConstructorTest()
        {
            ReadXML target = new ReadXML();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for SelectNode
        ///</summary>
        [TestMethod()]
        public void SelectNodeTest()
        {
            ReadXML target = new ReadXML(); // TODO: Initialize to an appropriate value
            string pXMLURL = "D:\\Projects\\GPSServer\\GPSWebsite\\WebsiteGPS\\WebsiteGPS\\App_Data\\ErrorCode.xml"; // TODO: Initialize to an appropriate value
            string pNode = "ErrorCode/Error"; // TODO: Initialize to an appropriate value
            string pStringNode = "Code"; // TODO: Initialize to an appropriate value
            string pValueNode = "en-US"; // TODO: Initialize to an appropriate value
            string pName = "401"; // TODO: Initialize to an appropriate value
            string expected = "Unauthorized!User failed to provide a valid user name / password required for access to file / directory."; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.SelectNode(pXMLURL, pNode, pStringNode, pValueNode, pName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SelectNode
        ///</summary>
        [TestMethod()]
        public void SelectNodeTest1()
        {
            ReadXML target = new ReadXML(); // TODO: Initialize to an appropriate value
            string pXMLURL = "D:\\Projects\\GPSServer\\GPSWebsite\\WebsiteGPS\\WebsiteGPS\\App_Data\\WebConfig.xml"; // TODO: Initialize to an appropriate value
            string pNode = "Website.config/Config"; // TODO: Initialize to an appropriate value
            string pStringNode = "Theme"; // TODO: Initialize to an appropriate value
            string pName = "name"; // TODO: Initialize to an appropriate value
            string[] expected = { "_default", "_default/_default.template" }; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.SelectNode(pXMLURL, pNode, pStringNode, pName);
            CollectionAssert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
