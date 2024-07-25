using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace UnilyChallenge.PageObjects
{
    public class ProductDetailPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ProductDetailPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement QuantityInput => _driver.FindElement(By.Id("quantity"));
        private IWebElement AddToCartButton => _driver.FindElement(By.XPath("//button[text()[contains(.,'Add to cart')]]"));
        private IWebElement ContinueShoppingButton => _driver.FindElement(By.XPath("//button[text()='Continue Shopping']"));
        private IWebElement ViewCartButton => _driver.FindElement(By.XPath("//a[@href='/view_cart']"));

        public bool IsProductDetailVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("quantity"))).Displayed;
        }

        public void SetProductQuantity(int quantity)
        {
            QuantityInput.Clear();
            QuantityInput.SendKeys(quantity.ToString());
        }

        public void ClickAddToCartButton()
        {
            AddToCartButton.Click();
        }

        public void ClickContinueShoppingButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton)).Click();
        }

        public void ClickViewCartButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(ViewCartButton)).Click();
        }
    }
}