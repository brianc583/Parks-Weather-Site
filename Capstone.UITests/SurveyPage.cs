using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.UITests.StepDefinitions
{
    internal class SurveyPage
    {
        private IWebDriver driver;
        const string url = "http://localhost:55601/Home/GoToSurvey";
        public SurveyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "surveyButton")]
        public IWebElement SurveyButton { get; set; }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public SurveyPage ClickOnSurveySubmitButton()
        {

            SurveyButton.Click();

            return new SurveyPage(driver);
        }


    }
}