using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Web.DAL_s
{
    public interface IParksSqlDal
    {
        List<Park> GetParks();
        List<SelectListItem> GetDropDown();
    }
}
