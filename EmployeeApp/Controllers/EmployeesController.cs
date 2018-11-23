using EmployeeApp.DAL;
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

        public ActionResult Save()
        {
            var viewModel = new EmployeeFormViewModel
            {
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(EmployeeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();
                viewModel.Roles = _context.Roles.ToList();

                return View("Save", viewModel);
            }

            _context.Employees.Add(viewModel.Employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
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