using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

       public ActionResult NewWork(int id)
        {
            var shift = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.ShiftType)
                .Single(s => s.Id == id);

            var employees = _context.Employees
                .Where(e => e.DepartmentId == shift.DepartmentId).ToList();

            var viewModel = new AssignShiftEmployeesViewModel
            {
                Shift = shift,
                Employees = employees
            };

            return View(viewModel);
        }

        public ActionResult AddAWorkWeek()
        {
            var viewModel = new WorkDayViewModel
            {
                Departments = _context.Departments.ToList(),
                Heading = "Create a work week"
            };

            return View("AddAWorkDay",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAWorkWeek(WorkDayViewModel viewModel)
        {
            var shift = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.ShiftType)
                .Any(s => s.DateTime == viewModel.WorkDate && s.DepartmentId == viewModel.DepartmentId);
            if (!shift)
            {
                for(int j = 0; j<5; j++)
                {
                    
                    for (byte i = 1; i <= 3; i++)
                    {
                        var newShift = new Shift(viewModel.WorkDate.AddDays(j), i, viewModel.DepartmentId);
                        _context.Shifts.Add(newShift);
                    }
                }
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.Departments = _context.Departments.ToList();
            viewModel.Heading = "Create a work week";
            return View("AddAWorkDay",viewModel);
        }

        //get
        public ActionResult AddAWorkDay()
        {
            var viewModel = new WorkDayViewModel
            {
                Departments = _context.Departments.ToList(),
                Heading = "Create a work day"
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAWorkDay(WorkDayViewModel viewModel)
        {
            var shift = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.ShiftType)
                .Any(s => s.DateTime == viewModel.WorkDate && s.DepartmentId == viewModel.DepartmentId);
            if (!shift)
            {
                for (byte i = 1; i <= 3; i++)
                {
                    var newShift = new Shift(viewModel.WorkDate, i, viewModel.DepartmentId);
                    _context.Shifts.Add(newShift);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.Departments = _context.Departments.ToList();
            viewModel.Heading = "Create a work day";
            return View(viewModel);
        }

        //Index (works)
        public ActionResult Index()
        {
            var shifts = _context.Shifts
                                .Include(s => s.Department)
                                .Include(s => s.ShiftType)
                                .Include(s => s.Works)
                                .Where(s => s.DateTime > DateTime.Now)
                                .OrderBy(s => s.DateTime)
                                .ToList();

            
            return View(shifts);
        }

        //Create Get (works)
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

            return RedirectToAction("Index");
        }
    }
}