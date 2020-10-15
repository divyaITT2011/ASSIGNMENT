using Amazon.S3.Model;
using AventStack.ExtentReports.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomateGmail
{
    public class LoginPageGmail : BasicOperations
    {
        IWebDriver driver;

        ReadConfigFile config = new ReadConfigFile();

        //Find the Login field
        By _userAccount = By.XPath("//div[contains(text(),'Use another account')]");
        By _userEmail = By.XPath("//input[@type='email']");
        By _userPassword = By.XPath("//input[@type='password']");
        By _header = By.XPath("//span[contains(text(),'Sign in')]");

        public LoginPageGmail(IWebDriver webDriver) : base(webDriver)
        {
            driver = webDriver;
        }
        public void LoadHeader()
        {
            ExplicitWait(10, _header);            
        }

        public void NavigateToUrl()
        {
            //Maximize the window
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            //Navigate to url
            driver.Navigate().GoToUrl("http:www.gmail.com");
        }

        public void AddUserEmail()
        {
            string email = config.GetEmailID();
            SendKeys(_userEmail, email);
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath("//span[contains(text(),'Next')]"))).Click().Perform();
            Thread.Sleep(2000);
        }
        public void AddUserPassword()
        {
            string password = config.GetPassword();
            SendKeys(_userPassword, password);
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath("//span[contains(text(),'Next')]"))).Click().Perform();
            Thread.Sleep(2000);
        }
    }
}