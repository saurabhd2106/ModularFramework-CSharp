using System;
using System.IO;
using AventStack.ExtentReports;
using CommonLibs.Implementation;
using CommonLibs.Utils;
using Guru99Application.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Guru99Tests.Tests
{
    public class BaseTests
    {
        public CommonDriver cmnDriver;

        public Guru99LoginPage loginPage; 

        public ExtentReport extentReport;

        private string reportFilename;

        public string currentWorkingDirectory;
        public string currentProjectDirectory;
        private IConfigurationRoot _configuration;
        public string testExecutionStartTime;

        public ScreenshotUtils screenshotUtils;

        private IWebDriver driver;

        [OneTimeSetUp]
        public void preSetup(){

            string workingDirectory = Environment.CurrentDirectory;

            currentWorkingDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

             _configuration = new ConfigurationBuilder()
            .AddJsonFile(currentProjectDirectory + "/appSettings.json").Build();

            
            testExecutionStartTime = DateUtils.GetCurrentDateAndTime();

            reportFilename = $"{currentWorkingDirectory}/reports/Guru99Report.html";

            extentReport = new ExtentReport(reportFilename);

        }

        [SetUp]
        public void SetUp(){
           extentReport.CreateATestCase("Setup");

            string browserType = _configuration["browserType"];

            extentReport.AddTestLog(Status.Info, "Browsertype - "+ browserType);

            cmnDriver = new CommonDriver(browserType);

            string baseUrl = _configuration["baseUrl"];;

            cmnDriver.navigateToFirstUrl(baseUrl);

            driver = cmnDriver.Driver;

            loginPage = new Guru99LoginPage(driver);

            screenshotUtils = new ScreenshotUtils(driver);
        }

        [TearDown]
        public void TearDown(){

             try
            {

                if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                {
                    extentReport.AddTestLog(Status.Fail, "Test case failed, please check logs or screenshots for failure reason");

                    string testcaseExecutionStartTime = DateUtils.GetCurrentDateAndTime();

                    string screenshotFile = $"{currentWorkingDirectory}/screenshots/test-{testcaseExecutionStartTime}.jpeg";
                    
                    screenshotUtils.CaptureAndSaveScreenshot(screenshotFile);

                    extentReport.AddScreenshotInReport(screenshotFile);
                }
                extentReport.AddTestLog(Status.Info, "Closing all Browsers");

            }
            catch (Exception ex)
            {
                extentReport.AddTestLog(Status.Error, ex.StackTrace);
            }
            finally
            {
                cmnDriver.CloseAllBrowsers();

            }
        }
        

         [OneTimeTearDown]
        public void postTearDown(){


            extentReport.FlushExtentReports();
        }
    }
}