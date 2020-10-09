using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ConsoleApp5
{
    class ProductPage
    {
        IWebDriver driver;
        private By addToCart = By.XPath("//button[text()='ADD TO CART']");
        public ProductPage(IWebDriver d)
        {
            driver = d;
        }

        public void AddItemToCart()
        {
            java.lang.Thread.sleep(1500);
            try
            {
                driver.FindElement(addToCart).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not in store");
            }
        }
    }
}
