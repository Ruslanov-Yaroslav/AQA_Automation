using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace AQA_AlloUa.Tests
{
    public class Test : BaseTest
    {
        [Test, Order(1)]
        public void CheckingIfCangingOfLocationIsCorrect()
        {
            GetHomePage().WaitVisibilityOfElement(20, By.CssSelector("button[data-geo-label]"));
            GetHomePage().ClickLocationButton();
            GetHomePage().WaitVisibilityOfElement(60, By.CssSelector("section[data-geo-tooltip]"));
            GetHomePage().ClickCityButton();
            GetHomePage().WaitVisibilityOfElement(20, By.CssSelector("button[data-geo-label]"));
            StringAssert.Contains("Харків", GetHomePage().LocationButton.Text);
        }

        [Test, Order(2)]
        public void CheckingLanguageChange()
        {
            GetHomePage().WaitPageLoad();
            if (!GetHomePage().LanguageRuButton.GetAttribute("class").Contains("active"))
            {
                GetHomePage().ClickLanguageRuButton();
            }
            StringAssert.Contains("active", GetDriver().FindElement(By.XPath("//span[contains(text(), 'UA')]")).GetAttribute("class"));
        }

        [Test, Order(3)]
        public void CheckingFirstItemofSearchIsrelevant()
        {
            GetHomePage().WaitVisibilityOfElement(20, By.Id("search-form__input"));
            GetHomePage().InputSearchValue();
            GetHomePage().WaitVisibilityOfElement(20, By.XPath("//div[@data-search-suggest-products]"));
            GetHomePage().GoToFirstProductPage();
            GetProductPage().WaitPageLoad();
            StringAssert.Contains("lg", GetDriver().Url);
        }

        [Test, Order(4)]
        public void CheckingSearchResultsCorrespondToSearchWord()
        {
            GetHomePage().WaitVisibilityOfElement(20, By.Id("search-form__input"));
            GetHomePage().InputSearchValue();
            GetHomePage().ClickSearchButton();
            Thread.Sleep(10000);

            foreach (var item in GetSearchResultstPage().ProductsList)
            {
                StringAssert.Contains("lg", item.Text.ToLower());
            }
        }

        [Test, Order(5)]
        public void CheckingFilteringCorresponsDataToFilteredResults()
        {
            GetHomePage().WaitPageLoad();
            GetHomePage().MoveToSectionLine();
            GetSectionPage().WaitPageLoad();
            GetHomePage().GoToAppleSection();
            GetHomePage().WaitVisibilityOfElement(20, By.XPath("//label[@for='pricerange-from']//input[@class='price-form__input']"));
            GetSectionPage().SetPriceRange();
            GetSectionPage().SelectMakrdown();
            GetSectionPage().WaitVisibilityOfElement(20, By.XPath("//button[@class='filter-popup__button']"));
            GetSectionPage().ClickShowFilteredButton();
            Thread.Sleep(5000);
            GetSectionPage().GoToFirstProductPage();
            GetProductPage().WaitVisibilityOfElement(20, By.XPath("//span[@class = 'info-tag-list__item-text']"));
            StringAssert.Contains("iPhone", GetProductPage().ProductName.Text);
            StringAssert.Contains("Уцінка", GetProductPage().MarkdownTag.Text);
        }
    }
}
