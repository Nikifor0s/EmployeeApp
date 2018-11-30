using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly EmployeeAppDbContext _context;

        public ShiftsController()
        {
            _context = new EmployeeAppDbContext();
        }

        //Index
        public ActionResult Index()
        {
            var shifts = _context.Shifts
                                .Include(s => s.Department)
                                .Include(s => s.ShiftType)
                                .Where(s => s.DateTime > DateTime.Now)
                                .ToList();
            return View(shifts);
        }

        //Create Get

        public ActionResult Create()
        {
            var viewModel = new ShiftFormViewModel
            {
                Departments = _context.Departments.ToList(),
                ShiftTypes = _context.ShiftTypes.ToList(),
            };

            return View(viewModel);
        }

        //Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShiftFormViewModel viewModel)
        {
            if ((!ModelState.IsValid || !viewModel.IsValidDayComparedToDate())
                || (ModelState.IsValid && !viewModel.IsValidDayComparedToDate()))
            {
                viewModel.Departments = _context.Departments.ToList();
                viewModel.ShiftTypes = _context.ShiftTypes.ToList();

                return View("Create", viewModel);
            };

            var shift = new Shift(viewModel.GetDateTime(), viewModel.ShiftTypeId, viewModel.DepartmentId);
            _context.Shifts.Add(shift);
            _context.SaveChanges();

            return View("Index");
        }
    }
}