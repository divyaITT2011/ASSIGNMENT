using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomateGmail
{
    class HomepageGmail : BasicOperations
    {
        IWebDriver driver;

        //Find the Login field
        string totalMailsPresent = "(//tr[@class='zA yO'])[{0}]";
        By _mailBody = By.XPath("//div[@class='gs']/div[3]");
        By _userPassword = By.XPath("//input[@type='password']");
        By _backToInboxButton = By.XPath("//a[@href='https://mail.google.com/mail/u/0/#inbox']");

        public HomepageGmail(IWebDriver webDriver) : base(webDriver)
        {
            driver = webDriver;
        }

        public void DisplayMailBody()
        {
            int mailCount = driver.FindElements(By.XPath("//tr[@class='zA yO']")).Count;
            for (int index = 1; index <= mailCount; index = index + 2)
            {
                try
                {
                    driver.FindElement(By.XPath(string.Format(totalMailsPresent, index))).Click();
                }
                catch (Exception e)
                {
                    driver.Close();
                }
                Thread.Sleep(1000);
                string bodyOfMail = Text(_mailBody);
                Console.WriteLine(bodyOfMail);
                ExplicitWait(10, _backToInboxButton);
                Click(_backToInboxButton);
            }
        }
    }
}