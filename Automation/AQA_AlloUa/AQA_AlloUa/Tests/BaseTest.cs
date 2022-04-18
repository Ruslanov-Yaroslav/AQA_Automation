using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;
using AQA_AlloUa.Pages;

namespace AQA_AlloUa.Tests
{
    public class BaseTest
    {
        static IWebDriver driver;
        string url = "https://allo.ua/";
        public Actions action;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            action = new Actions(driver);
        }

        [TearDown]
        public void TearDown() => driver.Close();
        
        public IWebDriver GetDriver()=> driver;
        
        public HomePage GetHomePage() => new HomePage(GetDriver());
        
        public ProductPage GetProductPage() => new ProductPage(GetDriver());
        
        public SearchResultsPage GetSearchResultstPage() => new SearchResultsPage(GetDriver());
        
        public SectionPage GetSectionPage() =>  new SectionPage(GetDriver());
        
    }
}
