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
        //By AddToCart = By.XPath("//body/div[@id='container']/div[1]/div[3]/div[1]/div[1]/div[2]/div[1]/ul[1]/li[1]/button[1]");

        public Cart1(IWebDriver d)
        {
            driver = d;
        }

        public void AddItemToCart()
        {
            java.lang.Thread.sleep(1500);
            driver.FindElement(AddToCart).Click();            
            //driver.SwitchTo().Window(driver.WindowHandles.First());

        }

    }
}

