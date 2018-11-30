using EmployeeApp.DAL;
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

        //Index
        public ActionResult Index()
        {
            return View();
        }

        //Create Get

        public ActionResult Create()
        {
            var viewModel = new ShiftFormViewModel
            {
                Departments = _context.Departments.ToList()
            };

            return View(viewModel);
        }

        //Create
        [HttpPost]
        public ActionResult Create(ShiftFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Departments = _context.Departments.ToList();

                return View("Create", viewModel);
            };

            return View("Index", "Shifts");
        }
    }
}