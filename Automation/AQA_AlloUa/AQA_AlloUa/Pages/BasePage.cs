using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AQA_AlloUa.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public Actions action;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            action = new Actions(driver);
            PageFactory.InitElements(driver , this);
        }

        public void WaitPageLoad()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitVisibilityOfElement(int timeout , By selector)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
        }
    }
}
