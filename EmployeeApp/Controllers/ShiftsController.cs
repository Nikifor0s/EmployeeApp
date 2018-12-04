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

        public ActionResult AssignEmployeesToShift(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var shift = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.ShiftType)
                .Include(s => s.Works)
                .Single(s => s.Id == id);          

            if (shift == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AssignShiftEmployeesViewModel
            {
                Shift = shift,
                Employees = _context.Employees.Where(e => e.DepartmentId == shift.DepartmentId).ToList()
            };

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