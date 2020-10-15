using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomateGmail
{
    public class BasicOperations
    {
        protected IWebDriver driver;
        int waitTime = 30;

        protected BasicOperations(IWebDriver webDriver)
        {
            if (driver == null)
            {
                driver = webDriver;
            }
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public string Text(By locator)
        {
           return driver.FindElement(locator).Text;
        }

        public void ExplicitWait(int waitTime, By locater)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(ExpectedConditions.ElementExists(locater));
        }
       

        public void SendKeys(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            driver.FindElement(locator).SendKeys(text);
        }

        public void WaitUntilElementVisible(By locater)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException), typeof(TimeoutException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locater));                     
        }

        public void WaitUntilElementIsClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException), typeof(TimeoutException));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
       
    }
}