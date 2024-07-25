using OpenQA.Selenium;

namespace UnilyChallenge.PageObjects
{
    public class HomePage
    {
        private IWebDriver _driver;
        private const string HomePageUrl = "http://automationexercise.com";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ProductButton => _driver.FindElement(By.XPath("//a[@href='/products']"));
        private IWebElement ViewProductButton(int productIndex) => _driver.FindElement(By.XPath($"(//a[@href='/product_details/{productIndex}'])[1]"));


        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        public bool IsHomePageVisible()
        {
            return _driver.Title.Contains("Automation Exercise");
        }

        public void ClickProductsButton()
        {
            ProductButton.Click();
        }

        public void ClickViewProductButton(int productIndex)
        {
            ViewProductButton(productIndex).Click();
        }
    }
}
