using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.DAL_s
{
    public class WeatherSQLDAL: IWeatherSqlDal
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkGeek;User ID=te_student;Password=techelevator";

        //public ParkSQLDAL(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        public List<Weather> GetWeather()
        {
            List<Weather> list = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from weather", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Models.Weather()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"])
                        });

                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }
    }
}