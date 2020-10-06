using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using com.sun.org.apache.xml.@internal.resolver.helpers;
using ConsoleApp5;
using java.lang;
using java.lang.management;
using Lucene.Net.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Wmhelp.XPath2;
using String = System.String;


namespace Automation2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Create a driver instance for chromedriver
            IWebDriver driver = new FirefoxDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
            java.lang.Thread.sleep(3000);

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.flipkart.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                      
            
            //Entering the login credentials
            LoginPage1 LoginPage = new LoginPage1(driver);
            LoginPage.SetUserName();
            LoginPage.SetPassword();
            LoginPage.ClickSubmit();

            ArrayList ListOfProducts = new ArrayList();
            ArrayList ListOfProductsPrice = new ArrayList();
            
            //Waiting for the header to load
            void LoadingHeader()
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));
                java.lang.Thread.sleep(3000);
            }

            //Entering the item that needs to be searched
            HomePage1 HomePage = new HomePage1(driver);
            HomePage.EnterSearchItem();
            LoadingHeader();

            //Setting the minimun range
            HomePage.SelectMinDropdownElement();
            LoadingHeader();            

            //Applying the filter for availability
            HomePage.SettingAvailibilityFilter();
            LoadingHeader();
            HomePage.SettingExcludeOutOfStockFilter();
            LoadingHeader();
                        
            //Adding products to cart
            HomePage.AddToCart();

            //Displaying the total cost
            Console.WriteLine("Total cost of the products are:" + HomePage.TotalPriceOfProducts());                      

            //Verify count of product
            HomePage.FinalCountOfProduct();

            //Display product name and product price
            HomePage.PrintProductNameAndPrice();


        }
    }
}

            


                 
        