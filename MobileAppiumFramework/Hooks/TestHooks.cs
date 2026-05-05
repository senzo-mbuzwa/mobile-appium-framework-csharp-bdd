using AventStack.ExtentReports;
using MobileAppiumFramework.Drivers;
using MobileAppiumFramework.Utilities;
using Reqnroll;

namespace MobileAppiumFramework.Hooks;

[Binding]
public class TestHooks
{
    private readonly ScenarioContext _scenarioContext;
    private ExtentTest _test;

    public TestHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        DriverManager.StartDriver();
        _test = ExtentReportManager.CreateTest(_scenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (_scenarioContext.TestError != null)
        {
            _test.Fail(_scenarioContext.TestError.Message);

            var scenarioName = _scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
            ScreenshotHelper.CaptureScreenshot(DriverManager.Driver, scenarioName);
        }
        else
        {
            _test.Pass("Test Passed");
        }

        DriverManager.QuitDriver();
        ExtentReportManager.GetExtent().Flush();
    }
}