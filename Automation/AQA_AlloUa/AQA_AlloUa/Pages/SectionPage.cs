using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AQA_AlloUa.Pages
{
    public class SectionPage :  BasePage
    {
        public int price = 18000;
        public SectionPage(IWebDriver driver) : base(driver) => this.driver = base.driver;
        
        [FindsBy(How = How.XPath, Using = "//h2[@data-id='price']")] public IWebElement PriceFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@for='pricerange-from']//input[@class='price-form__input']")] public IWebElement PriceRangeInput { get; set; }

        [FindsBy(How = How.Id, Using = "filter_id-markdown")] public IWebElement MarkDownFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class = 'product-card'])[1]")] public IWebElement FirstProduct { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='filter-popup__button']")] public IWebElement ShowFilteredButton { get; set; }

        public void ClickPriceFilter() => PriceFilter.Click();
        
        public void SelectMakrdown() => MarkDownFilter.Click();
        
        public void GoToFirstProductPage() => FirstProduct.Click();
        
        public void ClickShowFilteredButton() => ShowFilteredButton.Click();

        public void SetPriceRange()
        {
            PriceRangeInput.Clear();
            PriceRangeInput.SendKeys(price.ToString());
        }
    }
}
