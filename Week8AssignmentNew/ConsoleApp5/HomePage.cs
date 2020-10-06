using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation2
{
    public class HomePage
    {
        IWebDriver driver;
        HomePage(IWebDriver d)
        {
            driver = d;
        }

        //Find the HomePge field
        By TextBox =By.XPath("//input[@title='Search for products, brands and more']");
        //Setting the minimun range
        By minDropdownElement = By.XPath("//span[text()='Price']/ancestor::section/*/following-sibling::*//select[contains(.,'Min')]");
        //Setting header
        By header = By.XPath("//body/div[@id='container']/div/div[1]/div[1]");
        By maxDropdownElement = By.XPath("//option[@value='Min']/../../following-sibling::div[not(contains(.,'to'))]/select");
       //Setting filter
        By availability = By.XPath("//div[contains(text(),'Availability')]");
        By excludeOutOfStockFilter = By.XPath("//div[contains(text(),'Exclude')]");
        //Scrolling through the pages
        By textPages = By.XPath("//div[@class='_2zg3yZ']/span[contains(text(),'Page')]");
        //Identifying the product
        By textproduct = By.XPath("//a[contains(@href,'apple-iphone-6')]/div[2]/div/div[contains(text(),'Apple iPhone 6')]");
        //Identifying the product price
        By textproductprice = By.XPath("//a[contains(@href,'apple-iphone-6')]/div[2]/div[2]/div[1]/div/div[1][contains(text(),'₹')]");
        //Storing the count of product displayed for a search
        By result = By.XPath("//span[contains(text(),'results')][1]");



        public void enter_search_item()
        {
            driver.FindElement(TextBox).SendKeys("iphone 6");
            driver.FindElement(TextBox).SendKeys(Keys.Enter);
        }

        public void select_minDropdownElement()
        {
            SelectElement min = new SelectElement(driver.FindElement(minDropdownElement));
             min.SelectByValue("4000"); 
            driver.FindElement(TextBox).SendKeys(Keys.Enter);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(header));
        }
        public void select_maxDropdownElement()
        {
            SelectElement max = new SelectElement(driver.FindElement(maxDropdownElement));
            max.SelectByValue("50000");
            driver.FindElement(TextBox).SendKeys(Keys.Enter);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(header));
        }

        public void setting_availibility_filter()
        {
            driver.FindElement(availability).Click();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(header));
        }

        public void setting_excludeOutOfStock_filter()
        {
            driver.FindElement(excludeOutOfStockFilter).Click();
        }

        public void Scrolling()
        {
            Console.WriteLine(textPages);
            string[] textPagesFooter = textPages.Split(' ');
            int l = textPagesFooter.Length;            
        }

        
        }
    }
