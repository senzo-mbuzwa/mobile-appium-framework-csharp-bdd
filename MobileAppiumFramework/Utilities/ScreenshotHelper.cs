using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace MobileAppiumFramework.Utilities;

/// <summary>
/// Handles screenshot capture for failed test scenarios.
/// </summary>
public static class ScreenshotHelper
{
    public static void CaptureScreenshot(AndroidDriver driver, string scenarioName)
    {
        try
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Screenshots");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            var fileName = $"{scenarioName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var filePath = Path.Combine(directory, fileName);

            screenshot.SaveAsFile(filePath);

            Console.WriteLine($"Screenshot saved: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
        }
    }
}