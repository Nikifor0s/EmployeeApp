using EmployeeApp.Controllers;
using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.ViewModels
{
    public class WorkDayViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime WorkDate { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ShiftsController, ActionResult>> addAWorkDay =
                    (c => c.AddAWorkDay(this));
                Expression<Func<ShiftsController, ActionResult>> addAWorkWeek =
                    (c => c.AddAWorkWeek(this));

                var action = (Id != 0) ? addAWorkDay : addAWorkWeek;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }
    }
}