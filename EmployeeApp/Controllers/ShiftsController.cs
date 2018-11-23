﻿using EmployeeApp.DAL;
using EmployeeApp.Models;
using EmployeeApp.ViewModels;
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

        // GET: Shifts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new ShiftFormViewModel
            {
                Departments = _context.Departments.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShiftFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();
                return View("Create", viewModel);
            }

            var shift = new Shift
            {
                DateTime = viewModel.Shift.DateTime,
                DayShift = viewModel.Shift.DayShift,
                DepartmentId = viewModel.Shift.DepartmentId
            };

            _context.Shifts.Add(shift);
            _context.SaveChanges();

            return RedirectToAction("Index", "Shifts");
        }
    }
}