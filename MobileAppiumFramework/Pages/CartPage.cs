using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAppiumFramework.Pages;

/// <summary>
/// Represents the cart screen.
/// Handles navigation and validation of items added to the cart.
/// </summary>
public class CartPage : BasePage
{
    public CartPage(AndroidDriver driver) : base(driver)
    {
    }

    private readonly By CartIcon = By.Id("com.saucelabs.mydemoapp.android:id/cartTV");
    private readonly By CartItems = By.Id("com.saucelabs.mydemoapp.android:id/titleTV");

    /// <summary>
    /// Opens the cart screen.
    /// </summary>
    public void OpenCart()
    {
        Tap(CartIcon);
    }

    /// <summary>
    /// Validates that at least one item exists in the cart.
    /// </summary>
    public bool IsItemInCart()
    {
        return Wait.Until(driver =>
        {
            var items = driver.FindElements(CartItems);
            return items.Count > 0;
        });
    }

    /// <summary>
    /// Validates that the specific item exists in the cart.
    /// </summary>
    /// <param name="productName"></param>
    /// <returns></returns>
    public bool IsProductInCart(string productName)
    {
        var productLocator = By.XPath($"//android.widget.TextView[@text='{productName}']");

        return Wait.Until(driver =>
        {
            var items = driver.FindElements(productLocator);
            return items.Count > 0;
        });
    }
}