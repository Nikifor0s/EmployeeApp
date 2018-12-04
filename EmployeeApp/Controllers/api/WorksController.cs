using EmployeeApp.DAL;
using EmployeeApp.Dtos;
using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeApp.Controllers.api
{
    public class WorksController : ApiController
    {
        private EmployeeAppDbContext _context;

        public WorksController()
        {
            _context = new EmployeeAppDbContext();
        }

        public IHttpActionResult Working(WorkDto dto)
        {

            var exists = _context.Works.Any(w => w.ShiftId == dto.ShiftId && w.EmployeeID == dto.EmployeeId);

            if (exists)
                return BadRequest("The work already exists");

            var work = new Work()
            {
                EmployeeID = dto.EmployeeId,
                ShiftId = dto.ShiftId
            };

            _context.Works.Add(work);
            _context.SaveChanges();
            return Ok();
        }
    }
}
