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

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.flipkart.com");

            //Maximize the window
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
                                   
            //Find the Login field
            IWebElement eleLogin = driver.FindElement(By.XPath("(//div[@class='dHGf8H'])[2]"));
            IWebElement eleUN = driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//input[@type='text']"));
            eleUN.SendKeys("7498328220");
            IWebElement elePW=driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//input[@type='password']"));
            elePW.SendKeys("flipkart123");
            IWebElement eleSubmit=driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//button[@type='submit']"));
            eleSubmit.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            driver.Navigate().Refresh();
            //Waiting for the header to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[2]/div[1]")));
            
            //Adding 1st item in the wishlist
            IWebElement electronics = driver.FindElement(By.XPath("//span[contains(text(),'Electronics')]"));
            Thread.Sleep(2000);            
            electronics.Click();        
            IWebElement eleVivo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Vivo')]")));
            // clicking for product's page
            eleVivo.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[1]")));
            IWebElement addToWishList1 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[2]"));
            addToWishList1.Click();

            //Adding item 2nd in the wishlist
            IWebElement eleMen = driver.FindElement(By.XPath("//span[contains(text(),'Men')]"));
            Thread.Sleep(2000);
            eleMen.Click();
            IWebElement eleTrou = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Casual Trousers')]")));
            // clicking for product's page
            eleTrou.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]")));
            IWebElement addToWishList2 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]"));
            addToWishList2.Click();

            //Adding item 3rd in the wishlist
            IWebElement eleBabyKids = driver.FindElement(By.XPath("//span[contains(text(),'Baby & Kids')]"));
            Thread.Sleep(2000);
            eleBabyKids.Click();
            IWebElement eleSoftToys = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(text(),'Soft Toys')]")));
            // clicking for product's page
            eleSoftToys.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[3]")));
            IWebElement addToWishList3 = driver.FindElement(By.XPath("(//div/*[namespace-uri()='http://www.w3.org/2000/svg']/*[@fill-rule='evenodd'])[2]"));
            addToWishList3.Click();

            //Moving on to the user and checking the wishlisted elements count
            IWebElement user = driver.FindElement(By.XPath("//body/div/div/div/div/div/div[3]/div[1]"));
            String Check = driver.FindElement(By.XPath("//div[@id='container']//div//div//div//div//div//div//div//div//div//div//div[contains(text(),'2')]")).Text;
            if (Check == "3")
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
