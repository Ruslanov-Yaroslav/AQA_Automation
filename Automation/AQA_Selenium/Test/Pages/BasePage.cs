using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Test.Pages
{
    public class BasePage
    {
        public WebDriver driver;

        public BasePage(WebDriver driver) => this.driver = driver;
    }
}
