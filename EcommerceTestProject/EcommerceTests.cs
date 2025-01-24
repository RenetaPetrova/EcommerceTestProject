using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace EcommerceTestAutomation
{
    [TestFixture]
    public class EcommerceTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string baseUrl = "https://www.ozone.bg";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Verify_HomePage_LoadsWithKeyElements()
        {
            IWebElement logo = wait.Until(d => d.FindElement(By.CssSelector("a.logo")));
            IWebElement searchBox = wait.Until(d => d.FindElement(By.Name("q")));
            IWebElement catButton = wait.Until(d => d.FindElement(By.XPath("//div[@class='open-main-cat-nav-wrapper js-opening']")));
            IWebElement offerButton = wait.Until(d => d.FindElement(By.CssSelector("li a[href='/oferti-po-kategoriya/']")));
            IWebElement storesButton = wait.Until(d => d.FindElement(By.CssSelector("a[title='Нашите магазини']")));

            Assert.Multiple(() =>
            {
                // Verify page title
                Assert.That(driver.Title, Is.EqualTo("Mагазин за игри, книги, геймърски аксесоари и играчки | Ozone.bg"),
                    $"Expected title was 'Mагазин за игри, книги, геймърски аксесоари и играчки | Ozone.bg', but found '{driver.Title}'");

                // Verify elements are displayed
                Assert.IsTrue(logo.Displayed, "The logo is not found.");
                Assert.IsTrue(searchBox.Displayed, "The search bar is not found.");
                Assert.IsTrue(catButton.Displayed, "The categories button is not found.");
                Assert.IsTrue(offerButton.Displayed, "The offer button is not found.");
                Assert.IsTrue(storesButton.Displayed, "The Our Stores button is not found.");
            });
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
