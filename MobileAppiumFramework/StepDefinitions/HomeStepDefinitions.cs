using MobileAppiumFramework.Drivers;
using MobileAppiumFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;

namespace MobileAppiumFramework.StepDefinitions
{
    /// <summary>
    /// Step definitions for the Home feature.
    /// 
    /// These bindings connect the Gherkin steps in Home.feature
    /// to executable C# automation code.
    /// </summary>
    [Binding]
    public class HomeStepDefinitions
    {
        private readonly HomePage _homePage;
        private readonly CartPage _cartPage;

        public HomeStepDefinitions()
        {
            _homePage = new HomePage(DriverManager.Driver);
            _cartPage = new CartPage(DriverManager.Driver);
        }

        [Given("the mobile app is launched")]
        public void GivenTheMobileAppIsLaunched()
        {
            Assert.That(DriverManager.Driver, Is.Not.Null);
        }

        [Then("the products screen should be displayed")]
        public void ThenTheProductsScreenShouldBeDisplayed()
        {
            Assert.That(_homePage.IsProductsTitleDisplayed(), Is.True);
        }

        [Then("at least one product should be visible")]
        public void ThenAtLeastOneProductShouldBeVisible()
        {
            Assert.That(_homePage.IsAnyProductDisplayed(), Is.True);
        }

        [When("I open the first product")]
        public void WhenIOpenTheFirstProduct()
        {
            _homePage.OpenFirstProduct();
        }

        [When("I open the product {string}")]
        public void WhenIOpenTheProduct(string productName)
        {
            _homePage.OpenProductByName(productName);
        }

        [When("I add the product to the cart")]
        public void WhenIAddTheProductToTheCart()
        {
            _homePage.TapAddToCart();
        }

        [When("I open the cart")]
        public void WhenIOpenTheCart()
        {
            _cartPage.OpenCart();
        }

        [Then("the product {string} should be in the cart")]
        public void ThenTheProductShouldBeInTheCart(string productName)
        {
            Assert.That(_cartPage.IsProductInCart(productName), Is.True);
        }

        [When("I scroll to the product {string}")]
        public void WhenIScrollToTheProduct(string productName)
        {
            _homePage.ScrollToProduct(productName);
        }

        [Then("the product {string} should be visible")]
        public void ThenTheProductShouldBeVisible(string productName)
        {
            Assert.That(_homePage.IsProductVisible(productName), Is.True);
        }
    }
}
