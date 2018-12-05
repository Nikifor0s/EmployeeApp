using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class WorksController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}