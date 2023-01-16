using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //go to web page
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.saucedemo.com");
            webDriver.Manage().Window.Maximize();

            //click into element
            By loginBtn = By.CssSelector("#login-button");
            webDriver.FindElement(loginBtn).Click();

            //send keys
            webDriver.FindElement(By.Id("user-name")).SendKeys("standard_user");

            //clear field
            webDriver.FindElement(By.Id("user-name")).Clear();

            //is displayed
            bool isDisplayed = webDriver.FindElement(By.Id("login-button")).Displayed;
            Console.WriteLine($"Login button is displayed: {isDisplayed}");

            //is enabled
            var isEnabled = webDriver.FindElement(By.Id("login-button")).Enabled;
            Console.WriteLine($"Login button is enabled: {isEnabled}");

            //CSS value
            var cssValue = webDriver.FindElement(By.Id("login-button")).GetCssValue("color");
            Console.WriteLine($"Login button has colour: {cssValue}");

            //text
            var text = webDriver.FindElement(By.CssSelector("div>h3")).Text;
            Console.WriteLine($"Login button has text: {text}");

            //webDriver.Quit();
            Console.ReadKey();
        }
    }
}
