using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ConsoleApp5
{
    class Cart1
    {
        IWebDriver driver;
        By AddToCart = By.XPath("//button[text()='ADD TO CART']");
        public Cart1(IWebDriver d)
        {
            driver = d;
        }

        public void AddItemToCart()
        {
            java.lang.Thread.sleep(1500);
            try
            {
                driver.FindElement(AddToCart).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Not in store");
            }
        }
    }
}
