using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automation
{
    class DriverProgram
    {
        public static void Main(string[] args)
        {
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.flipkart.com");
                                            
            //Find the Login field
            IWebElement eleLogin = driver.FindElement(By.XPath("//a[contains(.,'Login')]"));
            IWebElement eleUN = driver.FindElement(By.XPath("//span[contains(text(), 'Email')]"));
            eleUN.SendKeys("7498328220");
            IWebElement elePW=driver.FindElement(By.XPath("//span[contains(text(), 'Enter Password')]"));
            elePW.SendKeys("flipkart123");
            IWebElement eleSubmit=driver.FindElement(By.XPath("//button/span[contains(.,'Login')]"));
            eleSubmit.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            driver.Navigate().Refresh();
            //Waiting for the header to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[2]/div[1]")));
            
            //Adding 1st item in the wishlist
            IWebElement electronicsSection = driver.FindElement(By.XPath("//span[contains(text(),'Electronics')]"));
            Thread.Sleep(2000);            
            electronicsSection.Click();        
            IWebElement eleVivo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Vivo')]")));
            // clicking for product's page
            eleVivo.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[1]")));
            IWebElement addToWishList1 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[2]"));
            addToWishList1.Click();

            //Adding item 2nd in the wishlist
            IWebElement MenSection = driver.FindElement(By.XPath("//span[contains(text(),'Men')]"));
            Thread.Sleep(2000);
            MenSection.Click();
            IWebElement eleTrou = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Casual Trousers')]")));
            // clicking for product's page
            eleTrou.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]")));
            IWebElement addToWishList2 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]"));
            addToWishList2.Click();

            //Adding item 3rd in the wishlist
            IWebElement BabyKidsSection = driver.FindElement(By.XPath("//span[contains(text(),'Baby & Kids')]"));
            Thread.Sleep(2000);
            BabyKidsSection.Click();
            IWebElement eleSoftToys = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Soft Toys')]")));
            // clicking for product's page
            eleSoftToys.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]")));
            IWebElement addToWishList3 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[2]"));
            addToWishList3.Click();

            //Moving on to the user and checking the wishlisted elements count
            IWebElement user = driver.FindElement(By.XPath("//input[contains(@title, 'Search for products')]/ancestor::form/../following-sibling::div[1]"));
            String Check = driver.FindElement(By.XPath("//div[contains(text(),'Wishlist')]/following-sibling::*")).Text;
            int check = Int16.Parse(Check);

            if (check >= 3)
            {
                Console.WriteLine("Correct number of Items added");
            }
            else
            {
                Console.WriteLine("Incorrect number of Items added");
            }
                                   
            //Close the browser
            driver.Close();
        }
    }
}
