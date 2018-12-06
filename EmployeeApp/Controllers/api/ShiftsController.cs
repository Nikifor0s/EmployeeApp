using EmployeeApp.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace EmployeeApp.Controllers.api
{
    public class ShiftsController : ApiController
    {
        private EmployeeAppDbContext _context;

        public ShiftsController()
        {
            _context = new EmployeeAppDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var employee = _context.Employees
                .Include(e => e.Works.Select(w => w.Employee))
                .Single(g => g.Id == Id);

            if (employee.IsRemoved)
                return NotFound();

            employee.IsRemoved = true;

            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }
    }
}