using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AQA_AlloUa.Pages
{
    public class HomePage : BasePage
    {
        string searchInput = "lg";

        public HomePage(IWebDriver driver) : base(driver) => this.driver = base.driver;

        [FindsBy(How = How.XPath, Using = "//span[@class='mh-loc__label']")] public IWebElement LocationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-geo-select-city='Харків']")] public IWebElement CityButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'RU')]")] public IWebElement LanguageRuButton { get; set; }

        [FindsBy(How = How.Id, Using = "search-form__input")] public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='search-products__items'][1]")] public IWebElement FirstProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")] public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='snap-slider__item']//a[@title='Смартфони та телефони']")] public IWebElement SectionLine { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul//a[@href='https://allo.ua/ua/mobilnye-telefony-i-sredstva-svyazi/proizvoditel-apple/']")] public IWebElement AppleSectionButton { get; set; }

        public void ClickLocationButton() => LocationButton.Click();
        
        public void ClickCityButton() => CityButton.Click();
        
        public void ClickLanguageRuButton() => LanguageRuButton.Click();
        
        public void GoToFirstProductPage() => FirstProduct.Click();
        
        public void ClickSearchButton() => SearchButton.Click();

        public void MoveToSectionLine() => SectionLine.Click();//action.MoveToElement(SectionLine).Perform();
        
        public void GoToAppleSection() => AppleSectionButton.Click();

        public void InputSearchValue()
        {
            SearchInput.SendKeys(searchInput);
            SearchInput.Click();
        }
    }
}
