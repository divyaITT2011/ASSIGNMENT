using AventStack.ExtentReports;
using ConsoleApp5;
using NUnit.Framework;
using OpenQA.Selenium;
using Xamarin.Essentials;
//using OpenQA.Selenium.Firefox.Testing.Utility.DriverFactory;

namespace ConsoleApp5
{
    [TestFixture]
    public class BaseTest
    {
        // Initializing parameters
        protected ExtentReports extentReports;
        private ExtentTest testStatus;
        private IWebDriver driver;
        public ExtentReports extentReport;

        // One time setup of extent report
        [OneTimeSetUp]
        protected void Setup()
        {
            ScreenshotExtentReport extentReports = new ScreenshotExtentReport();
            extentReport = extentReports.SetUpExtentReport();
        }

        // One time tear down of extent report
        [OneTimeTearDown]
        protected void TearDown()
        {
            extentReport.Flush();
        }

        // Setup of browser
        [SetUp]
        //public void BeforeTest()
        //{
        //    Coypu.DriverFactory driverFactory = new DriverFactory();
        //    driver = driverFactory.GetWebDriver((Browser)Browser.Firefox);
        //    testStatus = extentReport.CreateTest(TestContext.CurrentContext.Test.Name);
        //}

        // Tear down after the test is executed.
        [TearDown]
        public void AfterTest()
        {
            ScreenshotExtentReport tearDown = new ScreenshotExtentReport();
            tearDown.StatusAfterTest(testStatus, extentReport, driver);
        }

        // Returning the web driver to test method.
        public IWebDriver GetDriver()
        {
            return driver;
        }

    }
}
