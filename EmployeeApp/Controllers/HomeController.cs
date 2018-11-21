using EmployeeApp.DAL;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeAppDbContext _context;

        public HomeController()
        {
            _context = new EmployeeAppDbContext();
        }

        public ActionResult Index()
        {
            //
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}