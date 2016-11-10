using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL_s
{
    public class SurveySqlDAL : ISurveySqlDal
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkGeek;User ID=te_student;Password=techelevator";




        public bool SaveSurvey(Survey post)
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result VALUES (@parkCode, @email, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", post.ParkCode);
                    cmd.Parameters.AddWithValue("@email", post.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", post.State);
                    cmd.Parameters.AddWithValue("@activityLevel", post.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Survey> GetSurveyResult()
        {
            List<Survey> list = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select park.parkName, Count(survey_result.parkCode) AS \"ParkCount\" from dbo.survey_result inner join park on park.parkCode = survey_result.parkCode group by park.parkName order by ParkCount desc", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new Models.Survey()
                        {
                            ParkName = Convert.ToString(reader["parkName"]),
                            SurveyCount = Convert.ToInt32(reader["ParkCount"]),
                            
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