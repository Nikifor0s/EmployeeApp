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
        public IHttpActionResult Cancel(int Id)
        {

            var work = _context.Works
                .Where(w => w.EmployeeID == Id)
                .First();
                

            if (work.IsCanceled)
                return NotFound();

            work.Cancel();
            _context.SaveChanges();

            return Ok();
        }
    }
}
