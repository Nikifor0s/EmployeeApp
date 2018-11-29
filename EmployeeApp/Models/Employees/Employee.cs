using EmployeeApp.DAL;
using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EmployeeApp.Models.Employees
{
    public class Employee
    {
        //YELLOW
        //Red
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public virtual PersonalDetails PersonalDetails { get; set; }

        public virtual ContactDetails ContactDetails { get; set; }

        public ICollection<Work> Works { get; set; }

        public ICollection<Request> Requests { get; set; }

        public int RemaingDaysOfLeave { get; set; } = 23;

        public ICollection<Assignment> Assignments { get; set; }

        public Employee()
        {
            Works = new Collection<Work>();
            Requests = new Collection<Request>();
        }

        public Employee(int employeeId)
        {
            Id = employeeId;
        }

        //methods
        //Employee Add Shift to Employee

        public void  AddEmployeeToShift(Shift shift)
        {
            var work = new Work(this.Id, shift.Id);
            Works.Add(work);
        }



        //Make A Leave Request 
        public Request MakeARequestForLeave(EmployeeAppDbContext db, Employee employee, Leave leave)
        {
            var request = new Request()
            {
                Employee = employee,
                Leave = leave,
                DateRequestedLeave = DateTime.Now.Date,
                IsAccepted = true
            };
            if (employee.RemaingDaysOfLeave < leave.HowManyDays || leave.HowManyDays <= 0)
                request.IsAccepted = false;

            if (request.IsAccepted)
                employee.RemaingDaysOfLeave -= leave.HowManyDays;

            try
            {
                db.Leaves.Add(leave);
                db.Requests.Add(request);
                db.SaveChanges();
            }
            catch (DataException e)
            {
                throw new DataException(e.Message);
            }

            return request;
        }
    }
}