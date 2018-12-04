﻿using EmployeeApp.Models.Employees;
using ProjectEmployeeApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace EmployeeApp.ViewModels
{
    public class EmployeeFormViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public int RoleId { get; set; }

        public PersonalDetails PersonalDetails { get; set; }

        public ContactDetails ContactDetails { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<EmployeesController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<EmployeesController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }
    }
}