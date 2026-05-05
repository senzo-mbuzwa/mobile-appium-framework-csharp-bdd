using MobileAppiumFramework.Utilities;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAppiumFramework.Drivers;

/// <summary>
/// Responsible for creating Appium driver instances.
/// 
/// This factory centralizes all Android capability setup so that
/// test classes and page objects do not need to know how the driver is created.
/// </summary>
public static class AppiumDriverFactory
{
    /// <summary>
    /// Creates and returns an AndroidDriver instance using configuration
    /// values from appsettings.json.
    /// </summary>
    /// <returns>Initialized AndroidDriver session</returns>
    public static AndroidDriver CreateAndroidDriver()
    {
        var options = new AppiumOptions();

        options.PlatformName = ConfigReader.Get("Appium:PlatformName");
        options.AutomationName = ConfigReader.Get("Appium:AutomationName");
        options.DeviceName = ConfigReader.Get("Appium:DeviceName");

        options.AddAdditionalAppiumOption("appPackage", ConfigReader.Get("Appium:AppPackage"));
        options.AddAdditionalAppiumOption("noReset", bool.Parse(ConfigReader.Get("Appium:NoReset")));
        options.AddAdditionalAppiumOption("newCommandTimeout", int.Parse(ConfigReader.Get("Appium:NewCommandTimeout")));

        var serverUrl = new Uri(ConfigReader.Get("Appium:ServerUrl"));

        return new AndroidDriver(serverUrl, options);
    }
}