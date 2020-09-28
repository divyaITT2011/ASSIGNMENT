using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using java.lang;
using Lucene.Net.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Wmhelp.XPath2;
using String = System.String;


namespace Automation2
{
    class Program
    {
        private static object Main(string[] args)
        {
            // Create a driver instance for chromedriver
            IWebDriver driver = new FirefoxDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
            java.lang.Thread.sleep(3000);

            //Navigate to google page
            driver.Navigate().GoToUrl("http:www.flipkart.com");
                        
            ArrayList Listofproducts = new ArrayList();
            ArrayList Listofproductsprice = new ArrayList();
            String textproduct;
            String textproductprice;
            int product_price;
            int item_price;
            int total_cost=0;

            //Find the Login field
            IWebElement elementLogin = driver.FindElement(By.XPath("(//div[@class='dHGf8H'])[2]"));
            IWebElement elementUserName = driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//input[@type='text']"));
            elementUserName.SendKeys("7498328220");
            IWebElement elementPassword = driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//input[@type='password']"));
            elementPassword.SendKeys("flipkart123");
            IWebElement elementSubmit = driver.FindElement(By.XPath("//div[@class='_1XBjg- row']//form//button[@type='submit']"));
            elementSubmit.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));

            //driver.Navigate().Refresh();

            //Entering the item that needs to be searched
            IWebElement textBox = driver.FindElement(By.XPath("//input[@title='Search for products, brands and more']"));
            textBox.SendKeys("iphone 6");
            textBox.SendKeys(Keys.Enter);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));
            java.lang.Thread.sleep(3000);

            //Setting the minimun range
            SelectElement minDropdownElement = new SelectElement(driver.FindElement(By.XPath("//span[text()='Price']/ancestor::section/*/following-sibling::*//select[contains(.,'Min')]")));
            //minDropdownElement.SelectByIndex(9);
            minDropdownElement.SelectByValue("4000");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));
            java.lang.Thread.sleep(3000);

            //Setting the maximum range
            string maxDropdownElement = "//option[@value='Min']/../../following-sibling::div[not(contains(.,'to'))]/select";
            SelectElement max = new SelectElement(driver.FindElement(By.XPath(maxDropdownElement)));
            max.SelectByText("50000", true);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));

            //Applying the filter for availability
            IWebElement availability = driver.FindElement(By.XPath("//div[contains(text(),'Availability')]"));           
            IWebElement excludeOutOfStockFilter  = driver.FindElement(By.XPath("//div[contains(text(),'Exclude')]"));
            availability.Click();
            excludeOutOfStockFilter.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));

            //Scrolling to the pages
            String textPages = driver.FindElement(By.XPath("//div[@class='_2zg3yZ']/span[contains(text(),'Page')]")).Text;
            Console.WriteLine(textPages);
            String[] textPagesFooter = textPages.Split(' ');
            int l = textPagesFooter.Length;
            
            if (textPagesFooter[3] == textPagesFooter[1])
            {
                String total_items = driver.FindElement(By.XPath("//span[contains(text(),'Showing')]")).Text;
                String[] Total_items = total_items.Split(' ');
                int number_of_items_on_page = Int16.Parse(Total_items[3]);

                for (int j = 0; j < number_of_items_on_page; j++)
                {
                    //Adding All The Products To The Cart
                    IWebElement ItemUnavaialble = driver.FindElement(By.XPath("//img[contains(@alt,'Apple')]/ancestor::div/following-sibling::div/span)[j]"));
                    if (!ItemUnavaialble.Displayed) // if item available
                    {
                        //add to cart
                        IWebElement textprod = driver.FindElement(By.XPath("(//a[contains(@href,'apple-iphone-6')]/div[2]/div/div[1][contains(text(),'Apple iPhone ')])[j]"));
                        textprod.Click();
                        IWebElement add_to_cart = driver.FindElement(By.XPath("//button[text()='ADD TO CART']"));
                        add_to_cart.Click();
                    }
                }
                    
            }

            else
            {               
                for (int i = 1; i <= l; i++)
                {
                    String total_items = driver.FindElement(By.XPath("//span[contains(text(),'Showing')]")).Text;
                    String[] Total_items = total_items.Split(' ');
                    int number_of_items_on_page = Int16.Parse(Total_items[3]);

                    for (int j = 0; j < number_of_items_on_page; j++)
                    {
                        //Adding All The Products To The Cart
                        IWebElement ItemUnavaialble = driver.FindElement(By.XPath("//img[contains(@alt,'Apple')]/ancestor::div/following-sibling::div/span)[j]"));
                        if (!ItemUnavaialble.Displayed) // if item available
                        {
                            //add to cart
                            IWebElement textprod = driver.FindElement(By.XPath("(//a[contains(@href,'apple-iphone-6')]/div[2]/div/div[1][contains(text(),'Apple iPhone ')])[j]"));
                            textprod.Click();
                            IWebElement add_to_cart = driver.FindElement(By.XPath("//button[text()='ADD TO CART']"));
                            add_to_cart.Click();
                        }
                    }

                    //Fetching All The Products
                    textproduct = driver.FindElement(By.XPath("//a[contains(@href,'apple-iphone-6')]/div[2]/div/div[contains(text(),'Apple iPhone 6')]")).Text;
                    Listofproducts.Add(textproduct);
                    java.lang.Thread.sleep(3000);
                    textproductprice = driver.FindElement(By.XPath("//a[contains(@href,'apple-iphone-6')]/div[2]/div[2]/div[1]/div/div[1][contains(text(),'₹')]")).Text;
                    Listofproductsprice.Add(textproductprice);

                    //Calculating the total cost
                    item_price=Int16.Parse(textproductprice);
                    total_cost += item_price;
                    java.lang.Thread.sleep(3000);
                    
                    if (i != l)
                    {
                        IWebElement nextButton = driver.FindElement(By.XPath("//span[contains(text(),'Next')]"));
                        nextButton.Click();
                    }
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='container']/div/div[1]/div[1]")));

                }
            }

            //Use of IDictionary to store Products and costs
            String productName;
            java.lang.Integer productCost;
            IDictionary<String, java.lang.Integer> map_final_products = new Dictionary<String, java.lang.Integer>();
            for (int i = 0; i < Listofproducts.Count; i++)
            {
                productName = (string)Listofproducts[i]; //Iterate and fetch product name
                productCost = (java.lang.Integer)Listofproductsprice[i]; //Iterate and fetch product price
                
                map_final_products.Add(productName, productCost); //Add product and price in HashMap
            }

            

            //Verify count of product
            IWebElement result = driver.FindElement(By.XPath("//span[contains(text(),'results')][1]"));
            String Result = result.Text;
            String[] no_of_items =Result.Split();
            String No_Of_Items=no_of_items[3];
            int total_no_of_items= java.lang.Integer.parseInt(No_Of_Items);
            if (total_no_of_items == Listofproducts.Count)
            {
                Console.WriteLine("Correct count of product");
            }
            else
            {
                Console.WriteLine("Incorrect count of product");
            }
        }
    }
}
