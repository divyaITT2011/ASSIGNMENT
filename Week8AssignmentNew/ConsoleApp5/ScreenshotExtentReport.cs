using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using com.sun.xml.@internal.rngom.parse.host;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using sun.nio.ch;

namespace ConsoleApp5
{
    [TestClass]
    public class ScreenshotExtentReport : Base
    {
        protected ExtentReports extent;
        public static ExtentTest test;

        // Method to create the extent report.
        public ExtentReports SetUpExtentReport()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "DS");
            return extent;
        }

        // Method to store the status of the test once the test is executed.
        public void StatusAfterTest(ExtentTest _testStatus, ExtentReports extentReport, IWebDriver driver)
        {
            var status = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(NUnit.Framework.TestContext.CurrentContext.Result.StackTrace)
            ? ""
: string.Format("{0}", NUnit.Framework.TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;

                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = CaptureScreenshot(driver, fileName);
                    _testStatus.Log(Status.Fail, "Fail");
                    _testStatus.Log(Status.Fail, "Snapshot below: " + _testStatus.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _testStatus.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extentReport.Flush();
            driver.Quit();
        }

        [Test]
        public void LoginTest()
        {
            test = extent.CreateTest("Passing test");
            driver.Navigate().GoToUrl("http://www.flipkart.com");

            try
            {
                Assert.IsTrue(true);
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        [Test]
        public void filterAppliedTest()
        {
            test = extent.CreateTest("FilterAppliedTest");


            try
            {
                Assert.IsTrue(header.contains("Divya"));               
                test.Pass("Assertion passed");
            }
            catch (AssertionException)
            {
                test.Fail("Assertion failed");
                throw;
            }
        }

        public void FailingTest()
        {
            test = extent.CreateTest("Failing test");

            driver.Navigate().GoToUrl("http://www.flipkart.com");

            try
            {
                Assert.IsFalse(true);
                test.Fail("Assertion failed");
            }
            catch (AssertionException)
            {

                test.Pass("Assertion passed");
                throw;
            }
        }
        // Method to capture the screenshot.
        public string CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot takeScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takeScreenshot.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}