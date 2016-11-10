using Capstone.Web.DAL_s;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web
{
    public class ParkSQLDAL : IParksSqlDal
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkGeek;User ID=te_student;Password=techelevator";

        //public ParkSQLDAL(string connectionString)
        //{
        //    this.connectionString = connectionString;
        //}

        public List<Park> GetParks()
        {
            List<Park> list = new List<Park>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from park",conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Models.Park()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            Name = Convert.ToString(reader["parkName"]),
                            State = Convert.ToString(reader["state"]),
                            Acreage = Convert.ToInt32(reader["acreage"]),
                            Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                            MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]),
                            NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                            Climate = Convert.ToString(reader["climate"]),
                            YearFounded = Convert.ToInt32(reader["yearFounded"]),
                            AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                            Quote = Convert.ToString(reader["inspirationalQuote"]),
                            QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                            Description = Convert.ToString(reader["parkDescription"]),
                            EntryFee = Convert.ToInt32(reader["entryFee"]),
                            NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
                        });

                    }
                }
            }
            catch(Exception e)
            {
                throw;
            }

            return list;
        }
        public List<SelectListItem> GetDropDown()
        {
            List<Park> list = GetParks();
            List<SelectListItem> dropDown = new List<SelectListItem>();
            foreach (var park in list)
            {
                dropDown.Add(new SelectListItem() { Text = $"{park.Name}", Value = $"{park.ParkCode}" });

            }

            return dropDown;
        }
        
    }
}