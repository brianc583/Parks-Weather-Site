using Capstone.Web.DAL_s;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private ISurveySqlDal surveyDal;
        private IWeatherSqlDal weatherDal;
        private IParksSqlDal parkDal;

        public HomeController(ISurveySqlDal surveyDal, IWeatherSqlDal weatherDal, IParksSqlDal parkDal)
        {
            this.surveyDal = surveyDal;
            this.weatherDal = weatherDal;
            this.parkDal = parkDal;
        }



        // GET: Home
        public ActionResult Index()
        {
            List<Park> list = parkDal.GetParks();

            return View("Index", list);
        }

        [HttpPost]
        public ActionResult SetTemperaturePreference(string TempType)
        {
            Session["TempType"] = TempType;
            string pathway = Request.UrlReferrer.ToString();
            return Redirect(pathway);
        }


        // GET: Home
        public ActionResult Detail(string id)
        {

            Park park = parkDal.GetParks().Find(i => i.ParkCode == id);
            return View("Detail", park);
        }

        // GET: Home
        public ActionResult FiveDayForecast(string id)
        {
            List<Weather> weather = weatherDal.GetWeather().Where(i => i.ParkCode == id).ToList();

            if (Session["TempType"] == null)
            {
                Session["TempType"] = "F";
            }
            else
            {
                string tempType = Session["TempType"].ToString();
                foreach (var day in weather)
                {
                    day.TempType = tempType;
                }
            }

            return View("FiveDayForecast", weather);
        }

        public ActionResult GoToSurvey()
        {
            ViewBag.parks = parkDal.GetDropDown();
            ViewBag.activityLevel = activityLevel;
            ViewBag.state = state;
            return View("GoToSurvey", new Survey());
        }

        [HttpPost]
        public ActionResult GoToSurvey(Survey survey)
        {
            string surveySent = null;
            if (ModelState.IsValid)
            {
                if (Session["Surveyed"] != null)
                {
                    return View("Sorry");
                }
                else
                {
                    surveySent = "Surveyed";
                    Session["Surveyed"] = surveySent;
                    surveyDal.SaveSurvey(survey);
                    return RedirectToAction("SurveyResult");
                }

            }
            else
            {
                ViewBag.parks = parkDal.GetDropDown();
                ViewBag.activityLevel = activityLevel;
                ViewBag.state = state;
                return View("GoToSurvey", survey);
            }

        }

        public ActionResult SurveyResult()
        {
            List<Survey> list = surveyDal.GetSurveyResult();
            return View("SurveyResult", list);
        }

        private List<SelectListItem> activityLevel = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Bum" },
            new SelectListItem() { Text = "Couch Potato" },
            new SelectListItem() { Text = "Drifter" },
            new SelectListItem() { Text = "Vagabond" },
            new SelectListItem() { Text = "Mall Walker" },
            new SelectListItem() { Text = "Jogger" },
            new SelectListItem() { Text = "Iron Man" }

        };
        private List<SelectListItem> state = new List<SelectListItem>()
        {
           new SelectListItem() { Text ="ALASKA" },
           new SelectListItem() { Text ="ALABAMA" },
           new SelectListItem() { Text ="ARIZONA" },
           new SelectListItem() { Text ="ARKANSAS" },
           new SelectListItem() { Text ="CALIFORNIA" },
           new SelectListItem() { Text ="COLORADO" },
           new SelectListItem() { Text ="CONNECTICUT" },
           new SelectListItem() { Text ="DELAWARE" },
           new SelectListItem() { Text ="FLORIDA" },
           new SelectListItem() { Text ="GEORGIA" },
           new SelectListItem() { Text ="HAWAII" },
           new SelectListItem() { Text ="IDAHO" },
           new SelectListItem() { Text ="ILLINOIS" },
           new SelectListItem() { Text ="INDIANA" },
           new SelectListItem() { Text ="IOWA" },
           new SelectListItem() { Text ="KANSAS" },
           new SelectListItem() { Text ="KENTUCKY" },
           new SelectListItem() { Text ="LOUISIANA" },
           new SelectListItem() { Text ="MAINE" },
           new SelectListItem() { Text ="MARYLAND" },
           new SelectListItem() { Text ="MASSACHUSETTS" },
           new SelectListItem() { Text ="MICHIGAN" },
           new SelectListItem() { Text ="MINNESOTA" },
           new SelectListItem() { Text ="MISSISSIPPI" },
           new SelectListItem() { Text ="MISSOURI" },
           new SelectListItem() { Text ="MONTANA" },
           new SelectListItem() { Text ="NEBRASKA" },
           new SelectListItem() { Text ="NEVADA" },
           new SelectListItem() { Text ="NEW HAMPSHIRE" },
           new SelectListItem() { Text ="NEW JERSEY" },
           new SelectListItem() { Text ="NEW MEXICO" },
           new SelectListItem() { Text ="NEW YORK" },
           new SelectListItem() { Text ="NORTH CAROLINA" },
           new SelectListItem() { Text ="NORTH DAKOTA"},
           new SelectListItem() { Text ="OHIO"},
           new SelectListItem() { Text ="OKLAHOMA"},
           new SelectListItem() { Text ="OREGON"},
           new SelectListItem() { Text ="PENNSYLVANIA"},
           new SelectListItem() { Text ="RHODE ISLAND"},
           new SelectListItem() { Text ="SOUTH CAROLINA"},
           new SelectListItem() { Text ="SOUTH DAKOTA"},
           new SelectListItem() { Text ="TENNESSEE"},
           new SelectListItem() { Text ="TEXAS"},
           new SelectListItem() { Text ="UTAH"},
           new SelectListItem() { Text ="VERMONT"},
           new SelectListItem() { Text ="VIRGINIA"},
           new SelectListItem() { Text ="WASHINGTON"},
           new SelectListItem() { Text ="WEST VIRGINIA"},
           new SelectListItem() { Text ="WISCONSIN"},
           new SelectListItem() { Text ="WYOMING"}
        };

    }
}