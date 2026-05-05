using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace MobileAppiumFramework.Pages;

/// <summary>
/// Base class for all mobile page objects.
/// 
/// Contains common reusable actions such as finding elements,
/// tapping, entering text, and reading text.
/// </summary>
public abstract class BasePage
{
    protected readonly AndroidDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(AndroidDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
    }

    /// <summary>
    /// Waits for an element to exist and returns it.
    /// </summary>
    protected IWebElement Find(By locator)
    {
        return Wait.Until(driver => driver.FindElement(locator));
    }

    /// <summary>
    /// Taps an element after waiting for it.
    /// </summary>
    protected void Tap(By locator)
    {
        Find(locator).Click();
    }

    /// <summary>
    /// Clears and types text into an input field.
    /// </summary>
    protected void EnterText(By locator, string text)
    {
        var element = Find(locator);
        element.Clear();
        element.SendKeys(text);
    }

    /// <summary>
    /// Returns the visible text of an element.
    /// </summary>
    protected string GetText(By locator)
    {
        return Find(locator).Text;
    }

    /// <summary>
    /// Scrolls down until text becomes visible on the screen.
    /// Uses Android UiScrollable, which is more reliable than coordinate-based swipes.
    /// </summary>
    /// <param name="text">Visible text to scroll to</param>
    protected void ScrollToText(string text)
    {
        var scrollCommand =
            $"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"{text}\"))";

        Driver.FindElement(MobileBy.AndroidUIAutomator(scrollCommand));
    }
}