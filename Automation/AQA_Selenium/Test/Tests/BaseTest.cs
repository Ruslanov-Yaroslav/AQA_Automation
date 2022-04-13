using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.Pages;

namespace Test.Tests
{
    public class BaseTest
    {
        private WebDriver driver;
        private string _seleniumDev = "https://www.selenium.dev/";


        [SetUp]
        public void TestSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_seleniumDev);
        }

        [TearDown]
        public void TestTearDown() => driver.Close();

        public WebDriver GetDriver() => driver;

        public MainPage GetMainPage() => new(driver);

        public DocumentationPage GetDocumentationPage() => new(driver);
    }
}
