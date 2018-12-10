using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
using System;
using System.Collections.Generic;
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
        

        //get
        public ActionResult NewWork(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var shift = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.ShiftType)
                .SingleOrDefault(s => s.Id == id);

            if (shift == null)
            {
                return HttpNotFound();
            }

            var employees = _context.Employees
                .Where(e => e.DepartmentId == shift.DepartmentId &&
                !e.Works.Any(w => w.ShiftId == shift.Id && !w.IsCanceled))
                .ToList();

            var workingEmployees = _context.Employees
                .Where(e => e.DepartmentId == shift.DepartmentId &&
                e.Works.Any(w => w.ShiftId == shift.Id && !w.IsCanceled))
                .ToList();

            var viewModel = new AssignShiftEmployeesViewModel
            {
                Shift = shift,
                Employees = employees,
                WorkingEmployees = workingEmployees
            };

            return View(viewModel);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewWork(AssignShiftEmployeesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Employees = _context.Employees
                    .Where(e => e.DepartmentId == viewModel.Shift.DepartmentId)
                    .ToList();
                return View("NewWork", viewModel);
            }

            var employee = viewModel.EmployeeId;
            var shift = viewModel.Shift.Id;

            var exist = _context.Works.Any(w => w.EmployeeID == employee && w.ShiftId == shift);
            var existandiscanceled = _context.Works.Any(w => w.EmployeeID == employee && w.ShiftId == shift && w.IsCanceled);

            if (existandiscanceled)
            {
                var updatedWork = _context.Works.Where(w => w.EmployeeID == employee && w.ShiftId == shift).Single();
                updatedWork.IsCanceled = false;
                _context.SaveChanges();
                 return RedirectToAction("NewWork", viewModel.Shift.Id);
            }
            if (exist)
            {
                return RedirectToAction("");
            }

            var work = new Work(viewModel.EmployeeId, viewModel.Shift.Id);
            _context.Works.Add(work);
            _context.SaveChanges();

            return RedirectToAction("NewWork", viewModel.Shift.Id);
        }

        public ActionResult AddAWorkWeek()
        {
            var viewModel = new WorkDayViewModel
            {
                Departments = _context.Departments.ToList()
            };

            return View(viewModel);
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
                for (int j = 0; j < viewModel.NumberOfWorkDays; j++)
                {
                    for (byte i = 1; i <= viewModel.NumbersOfShifts; i++)
                    {
                        var newShift = new Shift(viewModel.WorkDate.AddDays(j), i, viewModel.DepartmentId);
                        _context.Shifts.Add(newShift);
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.Departments = _context.Departments.ToList();
            return View(viewModel);
        }

        public ActionResult Index(DateTime? dateTime, int? departmentId)
        {
            var departments = new GetWorkDayViewModel
            {
                Departments = _context.Departments.ToList()
            };
            if (dateTime == null && departmentId == null)
            {
                return View(departments);
            }
            else
            {
               
                return RedirectToAction("GetWorkDay", new { currentDatetime = dateTime, currnetDpertmentId = departmentId, departmentsToList = departments } );
            }
            

        }



        //Index (works)
        public ActionResult GetWorkDay(DateTime? dateTime, int? departmentId )
        {
               
            var shifts = _context.Shifts
                                .Include(s => s.Department)
                                .Include(s => s.ShiftType)
                                .Include(s => s.Works)
                                .Include(s => s.Works.Select(w => w.Employee))
                                .Where(s => s.DateTime == dateTime && s.DepartmentId == departmentId )
                                .ToList();
            


            var ShiftResults = shifts.First();
                               
                                
                      
            var workDay = new GetWorkDayViewModel
            {
                Datetime = ShiftResults.DateTime,
                DepartemtName = ShiftResults.Department.Name,
                Shifts = shifts,
                Departments = _context.Departments.ToList()
            };

            

            return View("GetWorkDay",workDay);
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