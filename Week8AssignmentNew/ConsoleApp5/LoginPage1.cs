using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5;
using OpenQA.Selenium;

namespace Automation2
{
    public class LoginPage1
    {
        IWebDriver driver;

        //Find the Login field
        By elementLogin = By.XPath("(//div[@class='dHGf8H'])[2]");
        By elementUserName = By.XPath("//div[@class='_1XBjg- row']//form//input[@type='text']");
        By elementPassword = By.XPath("//div[@class='_1XBjg- row']//form//input[@type='password']");
        By elementSubmit = By.XPath("//div[@class='_1XBjg- row']//form//button[@type='submit']");

        public LoginPage1(IWebDriver d)
        {
            driver = d;

        }
        public void SetUserName()
        {
            driver.FindElement(elementUserName).SendKeys("7498328220");
        }
        public void SetPassword()
        {
            driver.FindElement(elementPassword).SendKeys("flipkart123");
        }
        public void ClickSubmit()
        {
            driver.FindElement(elementSubmit).Click();
        }
    }
}

