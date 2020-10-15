using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomateGmail
{
    class DriverprogramGmail
    {
        public static void Main(string[] args)
        {
            Screenshot screenshots = new Screenshot();
            ExtentReports extentReport = ExtentManager.getInstance();
            ExtentTest test;

            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver("C:\\ChromeDriver");

            //Navigate to gmail page and Entering the login credentials
            test = extentReport.CreateTest("Login");
            LoginPageGmail LoginPage = new LoginPageGmail(driver);
            LoginPage.NavigateToUrl();
            LoginPage.LoadHeader();
            LoginPage.AddUserEmail();
            screenshots.CaptureScreenshot(driver, "AddedUserName");
            LoginPage.AddUserPassword();
            screenshots.CaptureScreenshot(driver, "Login");

            //Displaying the body of the mail
            HomepageGmail Homepage = new HomepageGmail(driver);
            Homepage.DisplayMailBody();
            screenshots.CaptureScreenshot(driver, "HomePage");

            //Composing a mail and sending it
            ComposeMail ComposeAMail = new ComposeMail(driver);
            ComposeAMail.SendMail();
            screenshots.CaptureScreenshot(driver, "SentMail");
            ComposeAMail.VerifyMailSent();

            //Closing
            driver.Quit();
        }
    }
}