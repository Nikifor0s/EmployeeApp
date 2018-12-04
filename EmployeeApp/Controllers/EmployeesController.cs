using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectEmployeeApp.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeAppDbContext _context;

        public EmployeesController()
        {
            _context = new EmployeeAppDbContext();
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _context.Employees
                .Include(e => e.PersonalDetails)
                .Include(e => e.ContactDetails)
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToList();

            return View(employees);
        }

        public ActionResult Create()
        {
            var viewModel = new EmployeeFormViewModel
            {
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList(),
                Heading = "Add Employee"
            };
            return View("EmployeeForm", viewModel);
        }

        //post create an Employee (works)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();
                viewModel.Roles = _context.Roles.ToList();
                return View("EmployeeForm", viewModel);
            }

            var employee = new Employee(viewModel);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return View("Index", "Employees");
        }

        public ActionResult Edit(int Id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == Id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View("Save", viewModel);
        }
    }
}