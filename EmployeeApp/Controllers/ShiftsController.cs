using EmployeeApp.DAL;
using EmployeeApp.Models;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
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

        // GET: Shifts
        public ActionResult Index()
        {
            var shifts = _context.Shifts
                .Include(s => s.Department)
                .Include(s => s.Works)
                .ToList();

            return View(shifts);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var shift = _context.Shifts.Find(Id);

            if (shift == null)
                return HttpNotFound();

            var viewModel = new EmployeesAssignToShiftViewModel
            {
                Employees = _context.Employees.Where(e => e.Department == shift.Department).ToList(),
                Shift = shift
            };

            return View("Details", viewModel);
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