using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace UnilyChallenge.PageObjects
{
    public class CartPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement FirstProduct => _driver.FindElement(By.XPath("(//td[@class='cart_description']/h4/a)[1]"));
        private IWebElement SecondProduct => _driver.FindElement(By.XPath("(//td[@class='cart_description']/h4/a)[2]"));
        private IWebElement FirstProductPrice => _driver.FindElement(By.XPath("(//td[@class='cart_price']/p)[1]"));
        private IWebElement SecondProductPrice => _driver.FindElement(By.XPath("(//td[@class='cart_price']/p)[2]"));
        private IWebElement FirstProductQuantity => _driver.FindElement(By.XPath("(//td[@class='cart_quantity']/button)[1]"));
        private IWebElement SecondProductQuantity => _driver.FindElement(By.XPath("(//td[@class='cart_quantity']/button)[2]"));
        private IWebElement FirstProductTotalPrice => _driver.FindElement(By.XPath("(//td[@class='cart_total']/p)[1]"));
        private IWebElement SecondProductTotalPrice => _driver.FindElement(By.XPath("(//td[@class='cart_total']/p)[2]"));
        private IWebElement CartProductQuantity => _driver.FindElement(By.XPath("//td[@class='cart_quantity']/button"));


        public bool AreProductsInCart()
        {
            return FirstProduct.Displayed && SecondProduct.Displayed;
        }

        public bool ArePricesCorrect()
        {
            return FirstProductPrice.Displayed && SecondProductPrice.Displayed;
        }

        public bool AreQuantitiesCorrect()
        {
            return FirstProductQuantity.Displayed && SecondProductQuantity.Displayed;
        }

        public bool AreTotalPricesCorrect()
        {
            return FirstProductTotalPrice.Displayed && SecondProductTotalPrice.Displayed;
        }

        public bool IsProductInCartWithQuantity(int expectedQuantity)
        {
            string quantityText = CartProductQuantity.Text;
            return quantityText == expectedQuantity.ToString();
        }
    }
}