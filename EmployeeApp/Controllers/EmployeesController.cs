using EmployeeApp.DAL;
using EmployeeApp.Models;
using EmployeeApp.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeAppDbContext _context;

        public EmployeesController()
        {
            _context = new EmployeeAppDbContext();
        }

        // GET: Employees
        public ViewResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.ContactDetails)
                .Include(e => e.PersonalDetails)
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToList();

            return View(employees);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Save()
        {
            var viewModel = new EmployeeFormViewModels
            {
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                //Automapper
                var employeeInDb = _context.Employees.Single(e => e.Id == employee.Id);
                employeeInDb = employee;

                employeeInDb.PersonalDetails = employee.PersonalDetails;
                employeeInDb.ContactDetails = employee.ContactDetails;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

        public ActionResult Edit(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == Id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModels
            {
                Employee = employee,
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View("Save", viewModel);
        }

        //public ActionResult UpComingShifts()
        //{
        //    var upcomingShifts = _context.Employees
        //        .Where(e => e.Shift.DateTime > DateTime.Now)
        //        .ToList();

        //    return View(upcomingShifts);
        //}

        //public ActionResult ShiftForm()
        //{
        //    var viewModel = new EmployeeFormViewModels
        //    {
        //        Shifts = _context.Shifts.ToList(),
        //        Departments = _context.Departments.ToList(),
        //        Roles = _context.Roles.ToList()
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ShiftForm(EmployeeFormViewModels viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        viewModel.Roles = _context.Roles.ToList();
        //        viewModel.Departments = _context.Departments.ToList();
        //        viewModel.Shifts = _context.Shifts.ToList();

        //        return View("ShiftForm", viewModel);
        //    }

        //    var employeeShiftInDb = _context.Employees.Single(s => s.Id == viewModel.Employee.Id);//an  den douleuei na to xanaalazw

        //    employeeShiftInDb.Shift.Id = viewModel.ShiftId;
        //    employeeShiftInDb.Department.Id = viewModel.DepartmentId;
        //    employeeShiftInDb.Role.Id = viewModel.RoleId;
        //    employeeShiftInDb.Shift.DateTime = viewModel.GetDateTime();

        //    _context.Employees.Add(employeeShiftInDb);
        //    _context.SaveChanges();

        //    return RedirectToAction("UpComingShifts", "Employees");
        //}

        //public ActionResult ShiftEdit(int Id)
        //{
        //    var employee = _context.Employees.Single(e => e.Id == Id);

        //    var viewModel = new EmployeeFormViewModels
        //    {
        //        Roles = _context.Roles.ToList(),
        //        Departments = _context.Departments.ToList(),
        //        Shifts = _context.Shifts.ToList(),
        //        Date = employee.Shift.DateTime.ToString("d MMM yyyy"),
        //        Time = employee.Shift.DateTime.ToString("HH:mm"),
        //    };

        //    return View("UpComingShifts", viewModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}
    }
}