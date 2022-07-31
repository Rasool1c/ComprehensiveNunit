using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Serilog.Core;
using Serilog;
using log4net;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace ComprehensiveNunit
{
    public class Tests
    {
        public static IWebDriver driver;
        public static LoggingLevelSwitch loggingLevel;
        public static ExtentReports extents;
        public ExtentTest test = null;
        //public static ITakesScreenshot screenshot;
        public void scr(string name)
        {

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\Screenshot" + name+  ".png");
        }


        [SetUp]
        public void Setup()
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tide.com/en-us");
            Log.Information("tide web application opened");


        }
        [OneTimeSetUp]
        public void logging()
        {
            var htmlreport = new ExtentHtmlReporter(@"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\ExtentReport.html");
            htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extents = new ExtentReports();
            extents.AttachReporter(htmlreport);
            LoggingLevelSwitch loggingLevel = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Serilog.Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.ControlledBy(levelSwitch: loggingLevel)
                                .WriteTo.File(@"C:\Users\mindc1may214\source\repos\ComprehensiveNunit\logger.log",
                                outputTemplate: "{TimeStamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine} {Exception}",
                                rollingInterval: RollingInterval.Day).CreateLogger();
            
        }

        [TearDown]
        public void Teardown()
        {
            Log.Information("Tide web application Closed");
            driver.Close();
        }
        [OneTimeTearDown]
        public static void CloseExtentReport()
        {
            extents.Flush();
        }
    }
}