using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(WebDriver driver) : base(driver) => this.driver = driver; 
        
        private string _documetation = "//a[@href = '/documentation']";

        public void ClickOnDocumentationButton() => driver.FindElement(By.XPath(_documetation)).Click();
    }
}
