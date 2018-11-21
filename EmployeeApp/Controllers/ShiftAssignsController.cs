using EmployeeApp.DAL;
using EmployeeApp.Models;
using EmployeeApp.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class ShiftAssignsController : Controller
    {
        private EmployeeAppDbContext _context;

        public ShiftAssignsController()
        {
            _context = new EmployeeAppDbContext();
        }

        // GET: ShiftAssigns
        public ActionResult Index()
        {
            var upcomingShiftAssings = _context.ShiftAssigns
                .Where(u => u.DateTime > DateTime.Now)
                .ToList();

            return View(upcomingShiftAssings);
        }

        public ActionResult Assign()
        {
            var viewModel = new ShiftAssignViewModel
            {
                Shifts = _context.Shifts.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(ShiftAssign assign)
        {
            if (assign.ShiftId == 0 && assign.EmployeeId != 0)
            {
                _context.ShiftAssigns.Add(assign);
            }

            var shiftAssignInDb = _context.ShiftAssigns.Single(s => s.EmployeeId == assign.EmployeeId);
            shiftAssignInDb.EmployeeId = assign.EmployeeId;
            shiftAssignInDb.ShiftId = assign.ShiftId;

            _context.SaveChanges();

            return View("Index", "ShiftAssigns");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}