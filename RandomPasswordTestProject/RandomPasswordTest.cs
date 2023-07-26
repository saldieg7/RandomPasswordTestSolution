using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Task1Tests
{
    [TestFixture]
    public class RandomPasswordTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void RandomPasswordTestExecution()
        {           

            //  Navigate to the URL
            driver.Navigate().GoToUrl(" http://google.com");

            //  Wait for the page to load completely
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            //wait.Until(d => d.Url.Contains("sampleapp"));

            //  Send random value to username field
            string randomUsername = "testuser" + System.DateTime.Now.Millisecond;
            IWebElement usernameField = driver.FindElement(By.Id("username"));
            usernameField.SendKeys(randomUsername);
         

            //  Send "pwd" to password field
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys("pwd");

            //  Click login button
            IWebElement loginButton = driver.FindElement(By.Id("loginButton"));
            loginButton.Click();

            //  Click logout button
            IWebElement logoutButton = driver.FindElement(By.Id("logoutButton"));
            logoutButton.Click();

            //  Assert expected results
            Assert.IsTrue(driver.Url.Contains("sample-app-page"), "Sample app page is not displayed.");
            Assert.IsTrue(driver.FindElement(By.Id("welcomeMessage")).Displayed, "Welcome message is not displayed.");
            Assert.IsTrue(driver.FindElement(By.Id("logoutMessage")).Displayed, "User logged out message is not displayed.");
        }
    }
}

