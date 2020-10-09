
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp5;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation2
{
    public class HomePage1
    {
        IWebDriver driver;
        public HomePage1(IWebDriver d)
        {
            driver = d;
        }

        //Find the HomePage field
        private By textBox = By.XPath("//input[@title='Search for products, brands and more']");

        //Setting the minimun range
        private By minDropdownElement = By.XPath("//span[text()='Price']/ancestor::section/*/following-sibling::*//select[contains(.,'Min')]");

        //Setting header
        private By header = By.XPath("//body/div[@id='container']/div/div[1]/div[1]");
        private By maxDropdownElement = By.XPath("//option[@value='Min']/../../following-sibling::div[not(contains(.,'to'))]/select");

        //Setting filter
        private By availability = By.XPath("//div[contains(text(),'Availability')]");
        private By excludeOutOfStockFilter = By.XPath("//div[contains(text(),'Exclude')]");

        //Scrolling through the pages
        private By pageNumber = By.XPath("//div[@class='_2zg3yZ']/span[contains(text(),'Page')]");

        //Identifying the product
        private String productName = "(//a[contains(@href,'apple-iphone')]/div[2]/div/div[contains(text(),'Apple iPhone')])[{0}]";

        //Identifying the product price
        private String productPrice = "(//a[contains(@href,'apple-iphone')]/div[2]/div[2]/div[1]/div/div[1][contains(text(),'₹')])[{0}]";

        //Storing the count of product displayed for a search
        private By searchResultCount = By.XPath("//span[contains(text(),'results')][1]");

        //Displaying the count of the matching items present
        private By totalItems = By.XPath("//span[contains(text(),'Showing')]");

        //Item unavailable
        private String unavailableItem = "(//img[contains(@alt,'Apple')])[{0}]/ancestor::div/following-sibling::div/span";

        //Available item
        private String availableitem = "(//img[contains(@alt,'Apple')])[{0}]";

        //Search result 
        private By searchResult = By.XPath("//div[contains(text(),'My Cart')]");

        //Next button
        private By nextButton = By.XPath("//span[contains(text(),'Next')]");

        //Total cost of the products
        private By totalCost = By.XPath("//span[contains(text(),'Price details')]/../div/div/span[contains(text(),'₹')]");

        //Display the product name        
        private string addedProductsName = "(//div[contains(@class,'PaJLWc')])[{0}]/div[1]/div[1]/a[contains(text(),'Apple iPhone')]";

        //Display the product cost
        private string addedProductsCost = "((//div[contains(@class,'PaJLWc')])[{0}]/div[1]/span[contains(text(),'₹')])";

        string numberOfItemsOnPage;
        public int itemsCount;
              
        public void EnterSearchItem()
        {
            Thread.Sleep(2000);
            driver.FindElement(textBox).SendKeys("iphone 6");
            driver.FindElement(textBox).SendKeys(Keys.Enter);
        }

        public void SelectMinDropdownElement()
        {
            java.lang.Thread.sleep(1000);
            SelectElement MinimumValue = new SelectElement(driver.FindElement(minDropdownElement));
            MinimumValue.SelectByValue("Min");
        }
        public void SelectMaxDropdownElement()
        {
            SelectElement MaximunValue = new SelectElement(driver.FindElement(maxDropdownElement));
            MaximunValue.SelectByValue("50000+");
        }

        public void ApplyingFilters()
        {
            java.lang.Thread.sleep(1000 );
            driver.FindElement(availability).Click();                     
            java.lang.Thread.sleep(2000);
            driver.FindElement(excludeOutOfStockFilter).Click();
        }

        public int GetNumberOfPages()
        {
            try
            {
                Boolean disp = !(driver.FindElement(pageNumber).Displayed);
            }
            catch (Exception e)
            {
                return 1;
            }

            if (driver.FindElement(pageNumber).Displayed)
            {
                String textPages = driver.FindElement(pageNumber).Text;
                string[] textPagesFooter = textPages.Split(' ');
                int Pages = short.Parse(textPagesFooter[3]);
                return (Pages);
            }
            else
            {
                return 1;
            }
        }

        public int DiplayTotalItemsPresent()
        {
            String showingTotalItems = driver.FindElement(this.totalItems).Text;
            String[] totalitemsAvailable = showingTotalItems.Split(' ');
            int numberOfItemsAvailableOnPage = Int16.Parse(totalitemsAvailable[3]);
            return (numberOfItemsAvailableOnPage);
        }
        public bool ItemUnavailable(int index)
        {
            try
            {
                return driver.FindElement(By.XPath(string.Format(unavailableItem, index))).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        internal void AddToCart()
        {
            int pageCounter = 1;
            int ppageCount = GetNumberOfPages();            
            java.lang.Thread.sleep(1000);
            ProductPage cart = new ProductPage(driver);
            while (pageCounter <= ppageCount)
            {
                int itemCount = driver.FindElements(By.XPath("(//img[contains(@alt,'Apple')])")).Count;
               for (int index = 1; index <= itemCount; index++)
                {
                    bool itemUnavailable = ItemUnavailable(index);
                    if (!itemUnavailable) // if item available
                    {
                        //add to cart.
                        java.lang.Thread.sleep(1000);
                        try
                        {
                            driver.FindElement(By.XPath(string.Format(availableitem, index))).Click();
                        }
                        catch (Exception e)
                        {
                            driver.Close();
                        }
                        java.lang.Thread.sleep(2000);

                        //Window Handles implementation
                        ArrayList tabs = new ArrayList(driver.WindowHandles);
                        driver.SwitchTo().Window((string)tabs[1]);
                        cart.AddItemToCart();
                        java.lang.Thread.sleep(1000);
                        driver.SwitchTo().Window(driver.WindowHandles.First());
                    }
                }
                pageCounter++;
                if (pageCounter <= ppageCount)
                {
                    ClickNextButton();
                    Thread.Sleep(2000);
                }                
            }
        }
        public string FinalSearchResult()
        {
            string r = driver.FindElement(searchResult).Text;
            return r;
        }

        public void ClickNextButton()
        {
            driver.FindElement(nextButton).Click();

        }
        public string GetProductName(int index)
        {
            string nameOfProduct = driver.FindElement(By.XPath(string.Format(productName, index))).Text;
            return nameOfProduct;
        }

        public string GetProductPrice(int index)
        {
            string priceOfProduct = driver.FindElement(By.XPath(string.Format(productPrice, index))).Text;
            return priceOfProduct;
        }
        public string TotalPriceOfProducts()
        {
            ArrayList tabs = new ArrayList(driver.WindowHandles);
            driver.SwitchTo().Window((string)tabs[1]);
            Thread.Sleep(2000);
            string totalProductsCost = driver.FindElement(totalCost).Text;
            return totalProductsCost;
        }

        //Verify Count of the product
        public void FinalCountOfProduct()
        {
            string searchResult = FinalSearchResult();            
            String[] displayOfNumberOfItems = searchResult.Split(' ');
            numberOfItemsOnPage = displayOfNumberOfItems[2];
            //int TotalNoOfItems = java.lang.Integer.parseInt(NumberOfItems);
            Console.WriteLine("Total Number Of Products Are" + numberOfItemsOnPage);
        }
        //Displaying Products And Their Costs
        public void PrintProductNameAndPrice()
        {
            int numberOfItems = Int16.Parse(numberOfItemsOnPage.Substring(1, 2));
            string displayProductName;
            string displayProductCost;
            for (int index = 1; index <= numberOfItems; index++)
            {

                displayProductName = driver.FindElement(By.XPath(string.Format(addedProductsName, index))).Text; //Iterate and fetch product name
                displayProductCost = driver.FindElement(By.XPath(string.Format(addedProductsCost, index))).Text; //Iterate and fetch product price
                Console.WriteLine("Product Name:" + displayProductName);
                Console.WriteLine("Product Cost:" + displayProductCost);
            }
        }
    }
}


