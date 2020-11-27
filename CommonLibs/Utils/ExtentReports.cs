using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CommonLibs.Utils
{
    public class ExtentReport
    {
        ExtentHtmlReporter HtmlReporter;
        ExtentReports extentReports;
        ExtentTest extentTest;

        public ExtentReport(string htmlReportFilename)
        {
            HtmlReporter = new ExtentHtmlReporter(htmlReportFilename);
            extentReports = new ExtentReports();

            extentReports.AttachReporter(HtmlReporter);
        }

        public void CreateATestCase(string testcasename)
        {
            extentTest = extentReports.CreateTest(testcasename);
        }

        public void AddTestLog(Status status, string comments)
        {
            extentTest.Log(status, comments);
        }

        public void AddScreenshotInReport(string filename)
        {
            extentTest.AddScreenCaptureFromPath(filename);
        }

        public void FlushExtentReports()
        {
            extentReports.Flush();
        }
    }
}