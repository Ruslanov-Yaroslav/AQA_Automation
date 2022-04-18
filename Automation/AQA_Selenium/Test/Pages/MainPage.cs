using OpenQA.Selenium;

namespace Test.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(WebDriver driver) : base(driver) => this.driver = driver; 
        
        private string _documetation = "//a[@href = '/documentation']";

        public void ClickOnDocumentationButton() => driver.FindElement(By.XPath(_documetation)).Click();
    }
}
