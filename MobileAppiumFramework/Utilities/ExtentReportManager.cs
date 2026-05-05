using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace MobileAppiumFramework.Utilities;

public static class ExtentReportManager
{
    private static ExtentReports _extent;
    private static ExtentTest _test;

    public static ExtentReports GetExtent()
    {
        if (_extent == null)
        {
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "ExtentReport.html");

            var htmlReporter = new ExtentSparkReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        return _extent;
    }

    public static ExtentTest CreateTest(string testName)
    {
        _test = GetExtent().CreateTest(testName);
        return _test;
    }

    public static ExtentTest GetTest()
    {
        return _test;
    }
}