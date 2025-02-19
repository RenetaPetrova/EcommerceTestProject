using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace EcommerceTestAutomation
{
    [TestFixture]
    public class EcommerceTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string baseUrl = "https://www.ozone.bg";

        [SetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void VerifyHomePageLoadsWithKeyElements()
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

        [Test]
        public void VerifySearchFunctionality()
        {
            string searchQuery = "Големак";

            SearchForProduct(searchQuery);

            IWebElement resultsHeader = wait.Until(d => d.FindElement(By.XPath("//span[@id='isp_results_search_text']")));
            Assert.IsTrue(resultsHeader.Displayed, "Search results header is not displayed.");

            string resultsText = resultsHeader.Text.Trim();
            Assert.IsTrue(resultsText.Contains(searchQuery, StringComparison.OrdinalIgnoreCase),
                $"Expected search query '{searchQuery}' was not found in the results header. Found: {resultsText}");

            IWebElement searchResultsContainer = wait.Until(d => d.FindElement(By.Id("isp_search_results_container")));

            IReadOnlyCollection<IWebElement> searchResults = searchResultsContainer.FindElements(By.XPath(".//li"));

            Assert.IsTrue(searchResults.Count > 0, "No search results were found.");

            IWebElement firstProduct = searchResults.First();
            Assert.IsTrue(firstProduct.Displayed, "The first search result is not displayed.");
        }

        [Test]
        public void VerifyAddToCardFunctionality()
        {
            string searchQuery = "Големак";

            SearchForProduct(searchQuery);

            IWebElement resultsHeader = wait.Until(d => d.FindElement(By.XPath("//span[@id='isp_results_search_text']")));
            Assert.IsTrue(resultsHeader.Displayed, "Search results header is not displayed.");

            string resultsText = resultsHeader.Text.Trim();
            Assert.IsTrue(resultsText.Contains(searchQuery, StringComparison.OrdinalIgnoreCase),
                $"Expected search query '{searchQuery}' was not found in the results header. Found: {resultsText}");

            IWebElement searchResultsContainer = wait.Until(d => d.FindElement(By.Id("isp_search_results_container")));

            IReadOnlyCollection<IWebElement> searchResults = searchResultsContainer.FindElements(By.XPath(".//li"));

            Assert.IsTrue(searchResults.Count > 0, "No search results were found.");

            IWebElement firstProduct = searchResults.First();

            IWebElement addToCartButton = driver.FindElement(By.XPath("//input[@class='isp_add_to_cart_btn']"));
            addToCartButton.Click();

            IWebElement toastMessage = wait.Until(d => d.FindElement(By.XPath("//div[@class='iziToast-texts']/p[@class='iziToast-message slideIn']")));

            string toastText = toastMessage.Text.Trim();
            Assert.That(toastText, Is.EqualTo("Големак беше успешно добавен в количката"), $"Expected toast message was not {toastText}");

        }

        [Test]
        public void VerifyRemoveFromCardFunctionality()
        {
            string searchQuery = "Големак";
            SearchForProduct(searchQuery);

            // Verify that the search results page is displayed
            IWebElement resultsHeader = driver.FindElement(By.XPath("//span[@id='isp_results_search_text']"));
            Assert.IsTrue(resultsHeader.Displayed, "Search results header is not displayed.");

            // Verify that the search results contain the keyword
            string resultsText = resultsHeader.Text.Trim();
            Assert.IsTrue(resultsText.Contains(searchQuery, StringComparison.OrdinalIgnoreCase),
                $"Expected search query '{searchQuery}' was not found in the results header. Found: {resultsText}");

            IWebElement addToCardButton = driver.FindElement(By.XPath("//input[@class='isp_add_to_cart_btn']"));
            addToCardButton.Click();

            IWebElement cartButton = wait.Until(d => d.FindElement(By.XPath("//a[@class='mini-cart-open clever-link-cart']")));
            cartButton.Click();

            Assert.That(driver.Url, Is.EqualTo("https://www.ozone.bg/checkout/cart/"), "URL does not match.");

            //ElementToBeClickable
            IWebElement removeIcon = wait.Until(d => d.FindElement(By.XPath("//a[contains(@href, '/checkout/cart/delete/')]")));
            removeIcon.Click();

            IWebElement emptyCartMessage = wait.Until(d => d.FindElement(By.XPath("//div[@class='shopping-cart-content']//h1")));
            string emptyCartMessageText = emptyCartMessage.Text.Trim();
            Assert.That(emptyCartMessageText, Is.EqualTo("Количката ти е празна"), $"Expected toast message was not {emptyCartMessageText}");
        }

        [Test]
        public void VerifyProductDetails()
        {
            string searchQuery = "Големак";
            SearchForProduct(searchQuery);

            // Verify that the search results page is displayed
            IWebElement resultsHeader = driver.FindElement(By.XPath("//span[@id='isp_results_search_text']"));
            Assert.IsTrue(resultsHeader.Displayed, "Search results header is not displayed.");

            // Verify that the search results contain the keyword
            string resultsText = resultsHeader.Text.Trim();
            Assert.IsTrue(resultsText.Contains(searchQuery, StringComparison.OrdinalIgnoreCase),
                $"Expected search query '{searchQuery}' was not found in the results header. Found: {resultsText}");

            IWebElement bookImage = driver.FindElement(By.XPath("//img[@class='isp_product_image']"));
            bookImage.Click();

            IWebElement bookTitle = driver.FindElement(By.XPath("//div[@class='col-xs-5 middle-info']//h1[@itemprop='name']"));
            IWebElement bookAuthor = driver.FindElement(By.XPath("//a[text()='Петя Петрова']"));
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("https://www.ozone.bg/product/golemak/"), "URL does not match.");
                Assert.That(bookTitle.Text.Trim(), Is.EqualTo("Големак"), "Product title does not match.");
                Assert.That(bookAuthor.Text.Trim(), Is.EqualTo("Петя Петрова"), "Book author does not match.");
            });

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
        public void OneTimeTearDown()
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
