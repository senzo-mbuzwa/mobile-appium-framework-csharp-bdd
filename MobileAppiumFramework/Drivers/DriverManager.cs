using OpenQA.Selenium.Appium.Android;

namespace MobileAppiumFramework.Drivers;

/// <summary>
/// Manages the lifecycle of the Appium driver for the test run.
/// 
/// This class provides a single access point to the active driver instance
/// and ensures the driver is properly started and disposed.
/// </summary>
public static class DriverManager
{
    private static AndroidDriver? _driver;

    /// <summary>
    /// Returns the active AndroidDriver instance.
    /// Throws a clear error if the driver has not been started yet.
    /// </summary>
    public static AndroidDriver Driver =>
        _driver ?? throw new InvalidOperationException("Driver has not been initialized. Call StartDriver() before using Driver.");

    /// <summary>
    /// Starts the Android driver if it has not already been created.
    /// </summary>
    public static void StartDriver()
    {
        _driver ??= AppiumDriverFactory.CreateAndroidDriver();
    }

    /// <summary>
    /// Ends the Appium session and disposes the driver instance.
    /// </summary>
    public static void QuitDriver()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _driver = null;
    }
}