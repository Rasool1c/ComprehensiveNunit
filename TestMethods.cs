using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Serilog;
using log4net;
using AventStack.ExtentReports;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Configuration;

namespace ComprehensiveNunit
{
    [TestFixture]
    public class TestMethods:Tests
    {
       
        Tests obj = new Tests();
        ReadFromExcel ExcelOp = new ReadFromExcel();
        

        [Test]
        public void signup()
        {
            //signup

            ExtentTest test1 = extents.CreateTest("SignUp").Info("Signup has started");
            driver.Navigate().GoToUrl("https://www.pggoodeveryday.com/signup/tide-coupons/");
            Thread.Sleep(3000);
            Log.Information("opened signup page");
            test1.Info("opened signup page");
            driver.FindElement(By.XPath("//*[@aria-label='text']")).SendKeys(ExcelOp.ReadExcelName());
            Log.Debug("Entering first name");
            test1.Debug("Entering first name");
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(ExcelOp.ReadExcelEmail());
            Log.Debug("Entering email");
            test1.Debug("Entering email");
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys(ExcelOp.ReadExcelPassword());
            Log.Warning("Enter password with given requirements");
            test1.Info("Enter password with given requirements");
            Log.Debug("Entering password");
            test1.Debug("Entering password");
            driver.FindElement(By.XPath("//input[@value='CREATE ACCOUNT']")).Click();
            Log.Information("signup completed successfully");
            test1.Info("signup completed successfully");
            //Thread.Sleep(2000);
            obj.scr("signup");
       
          


        }
        [Test]
        public void SignupInvalidPassword()
        {
            //signup invalid pass
            ExtentTest test2 = extents.CreateTest("SignUp With invalid password").Info("Signup has started");
            driver.Navigate().GoToUrl("https://www.pggoodeveryday.com/signup/tide-coupons/");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@aria-label='text']")).SendKeys(ExcelOp.ReadExcelName());
            Log.Debug("Entering first name");
            test2.Debug("Entering first name");
            driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(ExcelOp.ReadExcelEmail());
            Log.Debug("Entering email");
            test2.Debug("Entering email");
            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Abcd");
            Log.Warning("Enter password with given requirements");
            test2.Info("Enter password with given requirements");
            Log.Debug("Entering invalid password");
            test2.Debug("Entering invalid password");
            Log.Error("Invalid password entered");
            test2.Info("invalid password");
            Thread.Sleep(2000);
            obj.scr("signup invalid pass");

        }
        [Test]
        public void SignupInvalidClick()
        {
            try
            {
                //signup invalid and click
                ExtentTest test3 = extents.CreateTest("SignUp invalid click").Info("Signup has started");
                driver.Navigate().GoToUrl("https://www.pggoodeveryday.com/signup/tide-coupons/");
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//*[@aria-label='text']")).SendKeys(ExcelOp.ReadExcelName());
                Log.Debug("Entering first name");
                test3.Debug("Entering first name");
                driver.FindElement(By.XPath("//input[@id='email']")).SendKeys(ExcelOp.ReadExcelEmail());
                Log.Debug("Entering email");
                test3.Debug("Entering email");
                driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("Ab");
                Log.Warning("Enter password with given requirements");
                test3.Info("Enter password with given requirements");
                Log.Debug("Entering invalid password");
                test3.Debug("Entering invalid password");
                Log.Error("Invalid password entered");
                test3.Info("invalid password");
                driver.FindElement(By.XPath("//input[@value='CREATE ACCOUNT']")).Click();
                Log.Information("cannot click on login");
                test3.Info("unable to click on login");
                Thread.Sleep(2000);
                obj.scr("signup invalid click");
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message);
                Log.Information(ex.Message);
            }

        }

        [Test]
        public void login()
        {
            //login
            ExtentTest test4 = extents.CreateTest("Login").Info("login has started");
            driver.Navigate().GoToUrl("https://www.pggoodeveryday.com/signup/tide-coupons/");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[normalize-space()='Log in']")).Click();
            Thread.Sleep(3000);
            Log.Information("login page opened");
            driver.FindElement(By.XPath("//*[@id='login-email']")).SendKeys(ExcelOp.ReadExcelEmail());
            Log.Debug("Entering email");
            test4.Debug("Entering email");
            driver.FindElement(By.XPath("//*[@id='login-password']")).SendKeys(ExcelOp.ReadExcelPassword());
            Log.Warning("Enter password with given requirements");
            test4.Info("Enter password with given requirements");
            Log.Debug("Entering password");
            test4.Debug("Entering password");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@value='LOG IN']")).Click();
            Log.Information("login completed successfully");
            test4.Info("login completed successfully");
            //Thread.Sleep(1000);
            obj.scr("login");

        }
        [Test]
        public void ForgotPassword()
        {
            //forgot password
            ExtentTest test5 = extents.CreateTest("forgot password").Info("forgot password process stsarted");
            driver.Navigate().GoToUrl("https://www.pggoodeveryday.com/signup/tide-coupons/");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[normalize-space()='Log in']")).Click();
            Log.Information("login page opened");
            test5.Info("login page opened");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@href='/forgot-password/']")).Click();
            Log.Information("forgot password page opened");
            test5.Info("forgot password page opened");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='form-input']")).SendKeys(ExcelOp.ReadExcelEmail());
            Log.Debug("Entering email");
            test5.Debug("Entering email");
            
            driver.FindElement(By.XPath("//*[@value='Submit']")).Click();
            Log.Information("resest link sent to mail successfully");
            test5.Info("resest link sent to mail successfully");
            Thread.Sleep(2000);
            obj.scr("forgot password");

        }
        [Test]
        public void Search()
        {
            // search
            ExtentTest test6 = extents.CreateTest("Search").Info("Search has started");
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            Log.Information("clicked on search");
            test6.Info("clicked on search");
            driver.FindElement(By.XPath("//input[@placeholder='Search']")).SendKeys("Detergent");
            Log.Debug("Entering search text");
            test6.Debug("Entering search text");
            driver.FindElement(By.XPath("//*[@aria-label='Sumbit Search']")).Click();
            Log.Information("search results displayed");
            test6.Info("search results displayed");
            Thread.Sleep(4000);
  
            obj.scr("search");

        }
        [Test]
        public void Contactus()
        {

            try
            {
                // contact us
                ExtentTest test7 = extents.CreateTest("contactus").Info("contactus started");
                Thread.Sleep(7000);
                driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
                Log.Information("clicked on contact us");
                test7.Info("search results displayed");
                driver.FindElement(By.XPath("//a[contains(text(),'Contact Us')]")).Click();
                Thread.Sleep(15000);
                driver.FindElement(By.XPath("//*[@placeholder='Type here to search for answers']")).SendKeys("Detergent");
                Log.Debug("entering text");
                test7.Debug("entering text");
                Thread.Sleep(2000);
                obj.scr("contact us");
                driver.FindElement(By.XPath("//span[@class='fa fa-search']")).Click();
                Thread.Sleep(7000);
                
                
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Log.Information(ex.Message);
            }


        }
        [Test]
        public void Shop()
        {
            // shop products
            ExtentTest test8 = extents.CreateTest("SHOP").Info("Shop test has started");
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//*[@href='/en-us/shop']")).Click();
            Log.Information("clicked on shop products");
            test8.Info("clicked on shop products");
            Thread.Sleep(3000);
            
            new SelectElement(driver.FindElement(By.XPath("//*[@name='sortBy']"))).SelectByValue("title_az");
            Log.Debug("sorted the search results");
            test8.Debug("sorted the search results");
            
            Thread.Sleep(2000);
            obj.scr("shop");

        }
        [Test]
        public void Language()
        {
            //language
            ExtentTest test9 = extents.CreateTest("language").Info("language test has started");
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//button[normalize-space()='US - English']")).Click();
            Log.Information("clicked on language and location");
            test9.Info("clicked on language and location");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[normalize-space()='US - Spanish']")).Click();
            Log.Debug("selected on different language");
            test9.Debug("selected on different language");
            Log.Information("page is reloaded with seleted language");
            test9.Info("page is reloaded with seleted language");
            Thread.Sleep(10000);
            
            obj.scr("language");


        }
        [Test]
        public void WashVerify()
        {
            // how to wash clothes
            ExtentTest test10 = extents.CreateTest("wash verify").Info("test has started");
            Thread.Sleep(7000);
            driver.FindElement(By.XPath("//a[@class='lilo3746-close-link lilo3746-close-icon']")).Click();
            driver.FindElement(By.XPath("//a[normalize-space()='How to Wash Clothes']")).Click();
            Log.Information("clicked on How to Wash Clothes");
            test10.Info("clicked on How to Wash Clothes");
            Thread.Sleep(3000);
            string text = driver.FindElement(By.XPath("//strong[normalize-space()='How to Wash Clothes']")).Text;
            Log.Debug("extracing the text from the page to verify");
            test10.Debug("extracing the text from the page to verify");
            Assert.IsTrue(text.Contains("How to Wash Clothes"));
            Log.Information("Text veified successfully");
            test10.Info("Text veified successfully");
            Console.WriteLine(text);
            Log.Information("Text printed to console");
            obj.scr("washverify");
        }

    }
}
