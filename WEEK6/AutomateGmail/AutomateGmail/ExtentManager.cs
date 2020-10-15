using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Runtime.CompilerServices;

namespace AutomateGmail
{
    public class ExtentManager
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;
        private ExtentManager()
        {

        }
        public static ExtentReports getInstance()
        {
            if (extent == null)
            {
                string reportPath = @"C:\Users\divya.singh\Source\Repos\AutomateGmail\AutomateGmail\ExtentReport\Report.html";
                htmlReporter = new ExtentHtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Host Name", "Divya");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "DS");

                string extentConfigPath = @"C:\Users\divya.singh\Source\Repos\AutomateGmail\AutomateGmail\extent-config.xml";
                htmlReporter.LoadConfig(extentConfigPath);
            }
                return extent;
            }
        }
    }

