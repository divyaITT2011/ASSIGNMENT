using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Automation2
{
   public class LoginPage
    {
        IWebDriver driver;

        //Find the Login field
        By elementLogin= By.XPath("(//div[@class='dHGf8H'])[2]");
        By elementUserName = By.XPath("//div[@class='_1XBjg- row']//form//input[@type='text']");
        By elementPassword = By.XPath("//div[@class='_1XBjg- row']//form//input[@type='password']");
        By elementSubmit = By.XPath("//div[@class='_1XBjg- row']//form//button[@type='submit']");

        LoginPage(IWebDriver d)
        {
            driver = d;
        }

        public void setUserName()
        {
            driver.FindElement(elementUserName).SendKeys("7498328220");
        }

        public void setPassword()
        {
            driver.FindElement(elementPassword).SendKeys("flipkart123");
        }

        public void clickSubmit()
        {
            driver.FindElement(elementSubmit).Click();
        }


    }
}
