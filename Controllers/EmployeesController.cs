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
                .Include(e => e.Account)
                .Include(e => e.ContactDetails)
                .Include(e => e.PersonalDetails)
                .Include(e => e.Department)
                //.Include(e => e.Shift)
                .Include(e => e.Role)
                .ToList();

            return View(employees);
        }

        public ActionResult Save()
        {
            var viewModel = new EmployeeFormViewModels
            {
                //Shifts = _context.Shifts.ToList(),
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
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
                //Shifts = _context.Shifts.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View("Save", viewModel);
        }
    }
}