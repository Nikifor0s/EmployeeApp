using EmployeeApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IHttpActionResult Cancel(string id)
        {
            string myId = id;
            string[] stringId = myId.Split();

            var employeeId = int.Parse(stringId[1]);
            var shiftId = int.Parse(stringId[0]);

            var work = _context.Works
                .Where(w => w.EmployeeID == employeeId && w.ShiftId == shiftId)
                .Single();
                

            if (work.IsCanceled)
                return NotFound();

            _context.Works.Remove(work);
            _context.SaveChanges();

            return Ok();
        }
    }
}
