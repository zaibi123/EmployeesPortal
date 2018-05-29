using System.Web.Mvc;
using EmployeesPortal.Web.Helpers;

namespace EmployeesPortal.Web.Controllers
{
    [CustomAuthorizeAttribute(Roles = "Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
