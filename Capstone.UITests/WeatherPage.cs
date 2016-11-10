using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Capstone.UITests.StepDefinitions
{
    internal class WeatherPage
    {
        private IWebDriver driver;
        const string url = "http://localhost:55601/Home/FiveDayForecast/CVNP";
        public WeatherPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}