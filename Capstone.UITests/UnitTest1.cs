using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Capstone.UITests
{
    [TestClass]
    public class UnitTest1
    {
        // IWebDriver is the object that represents a browser
        // and can make calls to the browser 
        private static IWebDriver driver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            // Run our tests against the Chrome browser
            driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void TestWebDriver_GoToSurveyPage()
        {

            driver.Navigate().GoToUrl("http://localhost:55601");

            driver.FindElement(By.Id("survey")).Click();

            Assert.AreEqual("http://localhost:55601/Home/GoToSurvey", driver.Url);
        }

        [TestMethod]
        public void TestWebDriver_GoToSurveyPage_FillOutForms_LandOnSurveyPage()
        {

            driver.Navigate().GoToUrl("http://localhost:55601/Home/GoToSurvey");

            // Find the email textbox and enter login
            IWebElement usernameField = driver.FindElement(By.Name("EmailAddress"));
            usernameField.SendKeys("parklover@parks.com");

            // Find the password textbox and enter password
            IWebElement passwordField = driver.FindElement(By.Name("State"));
            passwordField.SendKeys("CA");

            IWebElement submitButton = driver.FindElement(By.Id("surveyButton"));
            submitButton.Click();

            Assert.AreEqual("http://localhost:55601/Home/SurveyResult", driver.Url);
        }

        [TestMethod]
        public void TestWebDriver_GoToParkDetails_ClickOnForecastLink_LandWeatherPage()
        {

            driver.Navigate().GoToUrl("http://localhost:55601/Home/Detail/CVNP");

            // Find the email textbox and enter login
            driver.FindElement(By.Id("forecast")).Click();

            Assert.AreEqual("http://localhost:55601/Home/FiveDayForecast/CVNP", driver.Url);
        }
    }
}
