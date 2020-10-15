using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AutomateGmail
{
    public class Screenshot
    {
        protected ExtentReports extent;        
       
        public string CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot takeScreenshot = (ITakesScreenshot)driver;
            OpenQA.Selenium.Screenshot screenshot = takeScreenshot.GetScreenshot();
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