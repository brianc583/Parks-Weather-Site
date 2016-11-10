//using Capstone.UITests.StepDefinitions.Capstone.UITests.StepDefinitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Capstone.UITests.StepDefinitions
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private static IWebDriver driver;

        [BeforeFeature]
        public static void InitFeature()
        {
            driver = new ChromeDriver();
        }

        [AfterFeature]
        public static void FeatureCleanup()
        {
            driver.Close();
            driver.Quit();
        }

        [Given(@"I am on the Home page")]
        public void GivenIAmOnTheHomePage()
        {
            HomePage homepage = new HomePage(driver);
            homepage.Navigate();


            ScenarioContext.Current.Set(homepage, "CurrentPage");
        }

        [When(@"I click on the survey link")]
        public void WhenIClickOnTheSurveyLink()
        {
            HomePage personalPage = ScenarioContext.Current.Get<HomePage>("CurrentPage");
            SurveyPage surveyPage = personalPage.ClickOnSurveyLink();

            ScenarioContext.Current.Set(surveyPage, "CurrentPage");
        }

        [Then(@"I am on the Survey Page")]
        public void ThenIAmOnTheSurveyPage()
        {
            SurveyPage surveyPage = ScenarioContext.Current.Get<SurveyPage>("CurrentPage");

            Assert.AreEqual("http://localhost:55601/Home/GoToSurvey", driver.Url);
        }

        [Given(@"I am on Park Detail page")]
        public void GivenIAmOnParkDetailPage()
        {
            DetailPage detailpage = new DetailPage(driver);
            detailpage.Navigate();


            ScenarioContext.Current.Set(detailpage, "CurrentPage");
        }

        [When(@"I click on the weather link at the bottom of the screen")]
        public void WhenIClickOnTheWeatherLinkAtTheBottomOfTheScreen()
        {
            DetailPage personalPage = ScenarioContext.Current.Get<DetailPage>("CurrentPage");
            WeatherPage weatherpage = personalPage.ClickOnWeatherLink();

            ScenarioContext.Current.Set(weatherpage, "CurrentPage");
        }

        [Then(@"I am now on the weather Page")]
        public void ThenIAmNowOnTheWeatherPage()
        {
            WeatherPage surveyPage = ScenarioContext.Current.Get<WeatherPage>("CurrentPage");

            Assert.AreEqual("http://localhost:55601/Home/FiveDayForecast/CVNP", driver.Url);
        }

        [Given(@"I am on the Survey Page")]
        public void GivenIAmOnTheSurveyPage()
        {
            SurveyPage surveypage = new SurveyPage(driver);
            surveypage.Navigate();


            ScenarioContext.Current.Set(surveypage, "CurrentPage");
        }

        [When(@"I Click Submit")]
        public void WhenIClickSubmit()
        {
           SurveyPage personalPage = ScenarioContext.Current.Get<SurveyPage>("CurrentPage");
            SurveyPage surveypage = personalPage.ClickOnSurveySubmitButton();

            ScenarioContext.Current.Set(surveypage, "CurrentPage");
        }

        [Then(@"I am back on the Survey Page")]
        public void ThenIAmBackOnTheSurveyPage()
        {
            SurveyPage surveyPage = ScenarioContext.Current.Get<SurveyPage>("CurrentPage");

            Assert.AreEqual("http://localhost:55601/Home/GoToSurvey", driver.Url);
        }


    }
}
