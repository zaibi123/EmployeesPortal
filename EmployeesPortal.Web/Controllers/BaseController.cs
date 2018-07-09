using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesPortal.Web.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected bool IsLoggedIn()
        {
            bool IsLoggedIn = (User.Identity.IsAuthenticated && Session["User"] != null) ? true : false;            
            return IsLoggedIn;
            
        }
    }
}