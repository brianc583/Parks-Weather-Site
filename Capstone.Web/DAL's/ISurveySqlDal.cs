using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL_s
{
     public interface ISurveySqlDal
    {
        bool SaveSurvey(Survey post);
        List<Survey> GetSurveyResult();
    }
}