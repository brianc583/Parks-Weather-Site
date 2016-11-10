using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Capstone.UITests.StepDefinitions
{
    internal class HomePage
    {
        private IWebDriver driver;
        public const string Url = "http://localhost:55601/";

        [FindsBy(How = How.Id, Using = "survey")]
        public IWebElement SurveyLink { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public SurveyPage ClickOnSurveyLink()
        {

            SurveyLink.Click();

            return new SurveyPage(driver);



        }
    }
}