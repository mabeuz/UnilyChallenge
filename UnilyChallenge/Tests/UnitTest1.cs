using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using UnilyChallenge.PageObjects;

namespace UnilyChallenge.Tests
{
    public class Tests
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private ProductsPage _productsPage;
        private CartPage _cartPage;
        private ProductDetailPage _productDetailPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
            _productsPage = new ProductsPage(_driver);
            _cartPage = new CartPage(_driver);
            _productDetailPage = new ProductDetailPage(_driver);
        }

        [Test]
        public void SearchProduct()
        {
            // Step 1: Launch browser and navigate to URL
            _homePage.NavigateToHomePage();
            Assert.IsTrue(_homePage.IsHomePageVisible());

            // Step 2: Click on 'Products' button
            _homePage.ClickProductsButton();

            // Step 3: Verify user is navigated to ALL PRODUCTS page successfully
            Assert.IsTrue(_productsPage.IsAllProductsPageVisible());

            // Step 4: Enter product name in search input and click search button
            string productName = "dress"; // replace with actual product name
            _productsPage.EnterProductNameAndSearch(productName);

            // Step 5: Verify 'SEARCHED PRODUCTS' is visible
            Assert.IsTrue(_productsPage.IsSearchedProductsVisible());

            // Step 6: Verify all the products related to search are visible
            Assert.IsTrue(_productsPage.AreSearchedProductsVisible());
        }


        [Test]
        public void AddProductsToCart()
        {
            // Step 1: Launch browser and navigate to URL
            _homePage.NavigateToHomePage();

            // Step 2: Click on 'Products' button
            _homePage.ClickProductsButton();

            // Step 3: Wait for the products page to load and verify user is navigated to ALL PRODUCTS page successfully
            Assert.IsTrue(_productsPage.IsAllProductsPageVisible());

            // Step 4: Hover over first product and click 'Add to cart'
            _productsPage.HoverOverProductAndAddToCart(1);

            _productsPage.ClickContinueShopping();

            // Step 5: Hover over second product and click 'Add to cart'
            _productsPage.HoverOverProductAndAddToCart(2);
            _productsPage.ClickViewCartButton();

            // Step 6: Verify both products are added to Cart
            Assert.IsTrue(_cartPage.AreProductsInCart());

            // Step 7: Verify their prices, quantity, and total price
            Assert.IsTrue(_cartPage.ArePricesCorrect());
            Assert.IsTrue(_cartPage.AreQuantitiesCorrect());
            Assert.IsTrue(_cartPage.AreTotalPricesCorrect());
        }


        [Test]
        public void VerifyProductQuantityInCart()
        {
            // Step 1: Launch browser and navigate to URL
            _homePage.NavigateToHomePage();
            Assert.IsTrue(_homePage.IsHomePageVisible());

            // Step 2: Click 'View Product' for any product on home page
            _homePage.ClickViewProductButton(1);

            // Step 3: Verify product detail is opened
            Assert.IsTrue(_productDetailPage.IsProductDetailVisible());

            // Step 4: Increase quantity to 4
            _productDetailPage.SetProductQuantity(4);

            // Step 5: Click 'Add to cart' button
            _productDetailPage.ClickAddToCartButton();

            // Step 6: Click 'Continue Shopping' button
            _productDetailPage.ClickContinueShoppingButton();

            // Step 7: Click 'View Cart' button
            _productDetailPage.ClickViewCartButton();

            // Step 8: Verify that product is displayed in cart page with exact quantity
            Assert.IsTrue(_cartPage.IsProductInCartWithQuantity(4));
        }
    }
}