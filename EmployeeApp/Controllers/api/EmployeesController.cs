using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeApp.Controllers.api
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeAppDbContext _context;

        public EmployeesController()
        {
            _context = new EmployeeAppDbContext();
        }

        public IEnumerable<Employee> Employees()
        {
            var employees = _context.Employees
                 .Include(e => e.Department)
                 .Include(e => e.PersonalDetails)
                 .Include(e => e.Role)
                 .Include(e => e.ContactDetails)
                 .ToList();

            return employees;
        }
    }
}
