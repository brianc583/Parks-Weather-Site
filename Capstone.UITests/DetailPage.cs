using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Capstone.UITests.StepDefinitions

{
    internal class DetailPage
    {
        private IWebDriver driver;
        public const string Url = "http://localhost:55601/Home/Detail/CVNP";

        [FindsBy(How = How.Id, Using = "forecast")]
        public IWebElement WeatherLink { get; set; }

        public DetailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(Url);
        }

        public WeatherPage ClickOnWeatherLink()
        {

            WeatherLink.Click();

            return new WeatherPage(driver);



        }
    }
}