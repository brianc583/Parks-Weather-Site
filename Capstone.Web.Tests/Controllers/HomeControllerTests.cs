using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using Capstone.Web.DAL_s;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]
        public void GoToSurvey_TakesYouToGoToSurvey()
        {
            Mock<ISurveySqlDal> mockSurvey = new Mock<ISurveySqlDal>();
            Mock<IWeatherSqlDal> mockWeather = new Mock<IWeatherSqlDal>();
            Mock<IParksSqlDal> mockParks = new Mock<IParksSqlDal>();
            HomeController controller = new HomeController(mockSurvey.Object, mockWeather.Object, mockParks.Object);
            var result = controller.GoToSurvey();

            Assert.IsTrue(result is ViewResult);
            var viewresult = result as ViewResult;
            Assert.AreEqual("GoToSurvey", viewresult.ViewName);
        }

        [TestMethod]
        public void GoToSurvey_SaveSurvey_TakesYouToSurveyResult()
        {
            Mock<ISurveySqlDal> mockSurvey = new Mock<ISurveySqlDal>();
            Mock<IWeatherSqlDal> mockWeather = new Mock<IWeatherSqlDal>();
            Mock<IParksSqlDal> mockParks = new Mock<IParksSqlDal>();
            

            mockSurvey.Setup(m => m.SaveSurvey(It.IsAny<Survey>())).Returns(true);
            HomeController controller = new HomeController(mockSurvey.Object, mockWeather.Object, mockParks.Object);

            var result = controller.GoToSurvey(It.IsAny<Survey>());

            Assert.IsTrue(result is RedirectToRouteResult);
            var viewresult = result as RedirectToRouteResult;
            Assert.AreEqual("SurveyResult", viewresult.RouteValues["action"]);
        }

        [TestMethod]
        public void ActionIndex_TakesYouToIndex()
        {
            Mock<ISurveySqlDal> mockSurvey = new Mock<ISurveySqlDal>();
            Mock<IWeatherSqlDal> mockWeather = new Mock<IWeatherSqlDal>();
            Mock<IParksSqlDal> mockParks = new Mock<IParksSqlDal>();
            HomeController controller = new HomeController(mockSurvey.Object, mockWeather.Object, mockParks.Object);
            var result = controller.Index();

            Assert.IsTrue(result is ViewResult);
            var viewresult = result as ViewResult;
            Assert.AreEqual("Index", viewresult.ViewName);
           
        }
    }
}