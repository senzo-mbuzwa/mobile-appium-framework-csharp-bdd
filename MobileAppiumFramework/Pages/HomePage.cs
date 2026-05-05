using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAppiumFramework.Pages;

/// <summary>
/// Represents the home/products screen of the Sauce Labs demo mobile app.
/// 
/// This page contains validations for the product listing screen,
/// which is the landing screen after the application launches.
/// </summary>
public class HomePage : BasePage
{
    public HomePage(AndroidDriver driver) : base(driver)
    {
    }

    private readonly By ProductsTitle = By.Id("com.saucelabs.mydemoapp.android:id/productTV");
    private readonly By ProductTitles = By.Id("com.saucelabs.mydemoapp.android:id/titleTV");
    private readonly By ProductImages = By.Id("com.saucelabs.mydemoapp.android:id/productIV");
    private readonly By AddToCartButton = By.Id("com.saucelabs.mydemoapp.android:id/cartBt");

    /// <summary>
    /// Checks whether the Products screen title is displayed.
    /// </summary>
    public bool IsProductsTitleDisplayed()
    {
        return Find(ProductsTitle).Displayed;
    }

    /// <summary>
    /// Waits until at least one product title is visible on the screen.
    /// </summary>
    public bool IsAnyProductDisplayed()
    {
        return Wait.Until(driver =>
        {
            var products = driver.FindElements(ProductTitles);
            return products.Count > 0;
        });
    }

    /// <summary>
    /// Validate if a specific item is available in the catalogue
    /// </summary>
    /// <param name="productName"></param>
    /// <returns></returns>
    public bool IsProductVisible(string productName)
    {
        var productTitle = By.XPath($"//android.widget.TextView[@text='{productName}']");

        return Wait.Until(driver =>
        {
            var elements = driver.FindElements(productTitle);
            return elements.Count > 0 && elements.First().Displayed;
        });
    }

    /// <summary>
    /// Scrolls to a product by its visible product name.
    /// </summary>
    public void ScrollToProduct(string productName)
    {
        ScrollToText(productName);
    }

    /// <summary>
    /// Taps on the first product on the screen.
    /// </summary>
    public void OpenFirstProduct()
    {
        Wait.Until(driver => driver.FindElements(ProductImages).Count > 0);
        Driver.FindElements(ProductImages).First().Click();
    }

    /// <summary>
    /// Taps on the product named in parameter
    /// </summary>
    /// <param name="productName"></param>
    public void OpenProductByName(string productName)
    {
        var productImage = By.XPath(
            $"//android.widget.TextView[@text='{productName}']/preceding-sibling::android.widget.ImageView"
        );

        Wait.Until(driver => driver.FindElements(productImage).Count > 0);

        Driver.FindElement(productImage).Click();
    }

    /// <summary>
    /// Taps on the "Add to cart" button.
    /// </summary>
    public void TapAddToCart()
    {
        Tap(AddToCartButton);
    }
}