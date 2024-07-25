using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UnilyChallenge.PageObjects
{
    public class ProductsPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _actions;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _actions = new Actions(_driver);
        }

        private IWebElement FirstProduct => _driver.FindElement(By.XPath("(//div[@class='productinfo text-center'])[1]"));
        private IWebElement SecondProduct => _driver.FindElement(By.XPath("(//div[@class='productinfo text-center'])[2]"));
        private IWebElement AddToCartButton(int productIndex) => _driver.FindElement(By.XPath($"(//a[@data-product-id='{productIndex}'])"));
        private IWebElement ContinueShoppingButton => _driver.FindElement(By.XPath("//button[text()='Continue Shopping']"));
        private IWebElement ViewCartButton => _driver.FindElement(By.XPath("//a[@href='/view_cart']"));

        private void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsAllProductsPageVisible()
        {
            try
            {
                // Esperar hasta que el elemento específico en la página de productos esté presente
                _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='All Products']")));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void EnterProductNameAndSearch(string productName)
        {
            var searchInput = _driver.FindElement(By.Id("search_product"));
            searchInput.SendKeys(productName);
            _driver.FindElement(By.Id("submit_search")).Click();
        }

        public bool IsSearchedProductsVisible()
        {
            return _driver.FindElement(By.XPath("//h2[contains(text(), 'Searched Products')]")).Displayed;
        }

        public bool AreSearchedProductsVisible()
        {
            try
            {
                // Esperar hasta que el elemento específico en la página de productos esté presente
                _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h2[text()='Searched Products']")));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }


        public void HoverOverProductAndAddToCart(int productIndex)
        {
            IWebElement product = productIndex == 1 ? FirstProduct : SecondProduct;
            _actions.MoveToElement(product).Perform();
            IWebElement addToCartButton = AddToCartButton(productIndex);
            _wait.Until(ExpectedConditions.ElementToBeClickable(addToCartButton));
            ScrollToElement(addToCartButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", addToCartButton);
        }

        public void ClickContinueShopping()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton)).Click();
        }

        public void ClickViewCartButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ViewCartButton)).Click();
        }
    }
}
