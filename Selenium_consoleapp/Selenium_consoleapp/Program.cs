using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gherkin.CucumberMessages.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace Selenium_consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com");

            webDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            webDriver.FindElement(By.Id("password")).SendKeys("secret_sauce");

            webDriver.FindElement(By.CssSelector("#login-button")).Click();

            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-backpack")).Click();
            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light")).Click();
            webDriver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-onesie")).Click();

            webDriver.FindElement(By.CssSelector("#shopping_cart_container")).Click();

            webDriver.FindElement(By.CssSelector("#checkout")).Click();

            webDriver.FindElement(By.Id("first-name")).SendKeys("Dawid");
            webDriver.FindElement(By.Id("last-name")).SendKeys("Nakrewicz");
            webDriver.FindElement(By.Id("postal-code")).SendKeys("78-200");

            webDriver.FindElement(By.CssSelector("#continue")).Click();

            var price = webDriver.FindElement(By.CssSelector(".summary_subtotal_label")).Text;
            Console.WriteLine($"{price} without tax");
                Assert.IsTrue(price == "Item total: $47.97");
                Assert.IsNotNull(price);

            webDriver.FindElement(By.CssSelector("#finish")).Click();

            var endingtext = webDriver.FindElement(By.CssSelector(".complete-header")).Text;
            Console.WriteLine($"{endingtext}");
            Assert.IsTrue(endingtext == "THANK YOU FOR YOUR ORDER");
            Assert.IsNotNull(endingtext);
        
            webDriver.Quit();

            Console.ReadKey();
        }
    }
}
