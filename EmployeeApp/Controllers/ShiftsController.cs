using EmployeeApp.DAL;
using EmployeeApp.Models;
using EmployeeApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class ShiftsController : Controller
    {
        private EmployeeAppDbContext _context;

        public ShiftsController()
        {
            _context = new EmployeeAppDbContext();
        }

        // GET: Shifts
        public ActionResult Index()
        {
            var upcomingShifts = _context.Shifts
                .Include(s => s.Employee)
                .Where(s => s.DateTime > DateTime.Now);

            return View(upcomingShifts);
        }

        public ActionResult ShiftForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShiftForm(ShiftFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ShiftForm", viewModel);

            var shift = new Shift
            {
                EmployeeId = viewModel.EmployeeId,
                DateTime = viewModel.GetDateTime()
            };

            _context.Shifts.Add(shift);
            _context.SaveChanges();

            return RedirectToAction("Index", "Shifts");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShiftFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ShiftForm", "Shifts");

            var employee = _context.Employees.Single();
            var shift = _context.Shifts
                .Single(s => s.Id == viewModel.Shift.Id && s.EmployeeId == employee.Id);
            shift.EmployeeId = viewModel.EmployeeId;
            shift.DateTime = viewModel.GetDateTime();

            _context.SaveChanges();

            return RedirectToAction("Index", "Shifts");
        }

        public ActionResult Edit(int Id)
        {
            var employee = _context.Employees.Single(e => e.Id == Id);
            var shift = _context.Shifts.Single();

            var viewModel = new ShiftFormViewModel
            {
                EmployeeId = employee.Id,
                Date = shift.DateTime.ToString("d MMM yyyy"),
                Time = shift.DateTime.ToString("d MMM yyyy")
            };

            return View("ShiftForm", "Shifts");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}