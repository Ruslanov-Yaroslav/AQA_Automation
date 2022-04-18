using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace Test.Tests
{
    [TestFixture]
    public class Test : BaseTest
    {
        readonly List<string> supportedLanguages = new() { "Java", "Python", "CSharp", "Ruby", "JavaScript", "Kotlin" };

        [Test]
        public void CheckThatSupportedLanguagesIsPresent()
        {
            GetMainPage().ClickOnDocumentationButton();
            var langs = GetDocumentationPage().GetLanguages().Select(languige => languige.Text);
            CollectionAssert.IsNotEmpty(supportedLanguages.Intersect(langs));
        }

        [Test]
        public void CheckExampleForEachLanguage()
        {
            GetMainPage().ClickOnDocumentationButton();
            var langs = GetDocumentationPage().GetLanguages();
            foreach(var lang in langs)
            {
                lang.Click();
                Assert.IsTrue(GetDocumentationPage().AreaWithCodeIsDisplayed());
            }
        }
    }
}
