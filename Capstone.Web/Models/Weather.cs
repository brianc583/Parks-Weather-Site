using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int ForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string TempType { get; set; }

        public int ConvertTemp(double temp)
        {
           if(TempType == "C")
            {
                temp = (temp - 32) * ((5.0 / 9.0));
            }
            return (int)temp;
        }
    }
}