using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Remote;
using SpecflowParallelTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium.Chrome;

namespace SpecflowParallelTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        LoginPage page;

       [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.naukri.com/nlogin/login");
        }

        [Given(@"I enter the invalid username and password (.*) and (.*)")]
        public void GivenIEnterTheInvalidUsernameAndPasswordAnd(string userName, string passWord)
        {
            page = new LoginPage(driver);
            page.EnterUserNameAndPassword(userName, passWord);
        }

        [Given(@"I click login")]
        public void GivenIClickLogin()
        {
            page.ClickLogin();
        }

        [Then(@"I should see the error message")]
        public void ThenIShouldSeeTheErrorMessage()
        {
            String actualMessage = driver.FindElement(By.XPath("//*[text()='Invalid details. Please check the Email ID - Password combination.']")).Text;
            Assert.AreEqual("Invalid details. Please check the Email ID - Password combination.", actualMessage, "Login Successful");
            driver.Quit();
        }

    }
}