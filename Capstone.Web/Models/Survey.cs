using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }

        [Required (ErrorMessage = "*")]
        public string ParkCode { get; set; }

        [Required (ErrorMessage = "Please Enter Your Email")]
        [EmailAddress (ErrorMessage ="Please Enter A Valid Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Enter Your State of Residence")]
        public string State { get; set; }

        [Required(ErrorMessage = "*")]
        public string ActivityLevel { get; set; }

        public string ParkName { get; set; }
        public int SurveyCount { get; set; }


    }
}