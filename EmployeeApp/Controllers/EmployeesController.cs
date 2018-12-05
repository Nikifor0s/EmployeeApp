using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using EmployeeApp.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectEmployeeApp.Controllers
{
    //
    public class EmployeesController : Controller
    {
        private EmployeeAppDbContext _context;

        public EmployeesController()
        {
            _context = new EmployeeAppDbContext();
        }

        public ActionResult RequestLeave()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequestLeave([Bind(Include = "StartDateOfLeave,EndDateOfLeave,Type,Description")] Leave leave, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var request = employee.MakeARequestForLeave(leave); 
               

                _context.Leaves.Add(leave);
                _context.Requests.Add(request);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leave);
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
            var employee = _context.Employees
                .Include(e => e.ContactDetails)
                .Include(e => e.PersonalDetails)
                .Include(e => e.Department)
                .Include(e => e.Role)
                .SingleOrDefault(e => e.Id == Id);

            var viewModel = new EmployeeFormViewModel
            {
                ContactDetails = employee.ContactDetails,
                PersonalDetails = employee.PersonalDetails,
                Departments = _context.Departments.ToList(),
                Roles = _context.Roles.ToList(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                RoleId = employee.RoleId,
                DepartmentId = employee.DepartmentId,
                Id = employee.Id,
                Heading = "Update Employee"
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Roles = _context.Roles.ToList();
                viewModel.Departments = _context.Departments.ToList();
                return View("EmployeeForm", viewModel);
            }

            var employee = _context.Employees
                .Include(e => e.ContactDetails)
                .Include(e => e.PersonalDetails)
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Single(e => e.Id == viewModel.Id);

            employee.EmployeeModify(viewModel);

            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}