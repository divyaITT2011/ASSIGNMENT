using Amazon.Lambda;
using Amazon.SimpleEmail.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Net.Mail;
using System.Reflection;
using MailKit.Security;
using System.Net.Sockets;
using System.Web;
using AutoItX3Lib;

namespace AutomateGmail
{
    class ComposeMail : BasicOperations
    {
        IWebDriver driver;

        //Find the Login field
        By _composeMail = By.XPath("//div[contains(text(),'Compose')]");
        By _receipientsField = By.XPath(".//textarea[contains(@aria-label, 'To')]");
        By _subjectBox = By.Name("subjectbox");
        By _messageBody = By.XPath("(.//*[@aria-label='Message Body'])[2]");
        By _sendButton = By.XPath("//div[@class='dC']");
        By _attachmentOption = By.XPath("//div[@data-tooltip='Attach files']");
        string subjectOfMail = "Actions Required";
        By _verificationMail = By.XPath("//tr[@class='zA yO'][1]/preceding-sibling::tr");
        By _subjectOfVerificationMail = By.XPath("//div[@class='ha']/h2[@class='hP']");
        By _meTag = By.XPath("//span[@name='me']");
        string subjectBodyOfVerificationMail;

        public ComposeMail(IWebDriver webDriver) : base(webDriver)
        {
            driver = webDriver;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SendMail()
        {
            Click(_composeMail);
            Thread.Sleep(1000);
            Click(_receipientsField);
            SendKeys(_receipientsField,"divyasingh.ec2013@gmail.com");
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.Name("subjectbox"))).Click().Perform();
            SendKeys(_subjectBox,"subjectOfMail");
            Click(_messageBody);
            SendKeys(_messageBody,"This is an Auto-Generated mail");
            Click(_attachmentOption);
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\divya.singh\Desktop\UploadMe.txt");
            //Thread.Sleep(1000);
            autoIt.Send("{ENTER}");
            driver.FindElement(_sendButton).Click();
        }

        public void VerifyMailSent()
        {
            //Thread.Sleep(9000);
            //ExplicitWait(12, _verificationMail);
            //WaitUntilElementVisible(_meTag);
            try
            {
            WaitUntilElementVisible(_verificationMail);
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.XPath("//tr[@class='zA yO'][1]/preceding-sibling::tr"))).Click().Perform();
            subjectBodyOfVerificationMail = driver.FindElement(_subjectOfVerificationMail).Text;
                if (subjectBodyOfVerificationMail.Equals("subjectOfMail"))
                {
                    Console.WriteLine("Your message wasn't delivered");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Your message was successfully delivered");
            }         
            
        }
    }
}