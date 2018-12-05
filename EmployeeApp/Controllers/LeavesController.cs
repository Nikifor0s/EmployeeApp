using EmployeeApp.DAL;
using EmployeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class LeavesController : Controller
    {
        private EmployeeAppDbContext _context;

        public LeavesController()
        {
            _context = new EmployeeAppDbContext();
        }
        // GET: Leaves
        public ActionResult Index()
        {
            var requests = _context.Requests
                                .Include(r => r.Leave)
                                .Include(r => r.Employee)   
                                .Where(r => r.Leave.EndDateOfLeave > DateTime.Now)
                                .ToList();

            return View(requests);
        }
    }
}