using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace SpecflowParallelTest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "usernameField")]
        private IWebElement enterUserName;

        [FindsBy(How = How.Id, Using = "passwordField")]
        private IWebElement enterPassword;

        [FindsBy(How = How.XPath, Using = "//*[@data-ga-track='spa-event|login|login|Save']")]
        private IWebElement btnLogin;

        public void EnterUserNameAndPassword(string userName, string password)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            enterUserName.SendKeys(userName);
            enterPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnLogin.Click();
        }
    }
}