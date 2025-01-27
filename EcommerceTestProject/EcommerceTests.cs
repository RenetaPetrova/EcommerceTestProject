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

        [Test, Order (1)]
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

        [Test, Order (2)]
        public void Verify_Search_Functionality()
        {
            string searchQuery = "Големак";

            // Use the search helper method
            SearchForProduct(searchQuery);

            // Verify that the search results page is displayed
            IWebElement resultsHeader = wait.Until(d => d.FindElement(By.XPath("//span[@id='isp_results_search_text']")));
            Assert.IsTrue(resultsHeader.Displayed, "Search results header is not displayed.");

            // Verify that the search results contain the keyword
            string resultsText = resultsHeader.Text.Trim();
            Assert.IsTrue(resultsText.Contains(searchQuery, StringComparison.OrdinalIgnoreCase),
                $"Expected search query '{searchQuery}' was not found in the results header. Found: {resultsText}");

            // Wait for the search results container to be present
            IWebElement searchResultsContainer = wait.Until(d => d.FindElement(By.Id("isp_search_results_container")));

            // Get the list of search result items (li elements)
            IReadOnlyCollection<IWebElement> searchResults = searchResultsContainer.FindElements(By.XPath(".//li"));

            // Assert that there is at least one result
            Assert.IsTrue(searchResults.Count > 0, "No search results were found.");

            // Verify the first product is displayed in the list
            IWebElement firstProduct = searchResults.First();
            Assert.IsTrue(firstProduct.Displayed, "The first search result is not displayed.");
        }

        private void SearchForProduct(string searchQuery)
        {
            IWebElement searchBox = wait.Until(d => d.FindElement(By.Name("q")));
            searchBox.Clear();
            searchBox.SendKeys(searchQuery);
            IWebElement searchButton = driver.FindElement(By.CssSelector("button[title='Търси']"));
            searchButton.Click();
        }

          [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

    }
}
