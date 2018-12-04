using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models.Employees
{
    public class Leave
    {
        public int ID { get; set; }
        
        [Display(Name = "Start Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDateOfLeave { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDateOfLeave { get; set; }
        public int HowManyDays
        {
            get
            {
                if (EndDateOfLeave > StartDateOfLeave)
                    return EndDateOfLeave.DayOfYear - StartDateOfLeave.DayOfYear;

                else
                    return 0;
            }
        }
        public TypeOfLeave Type { get; set; }

        public string Description { get; set; }

        //connection 1-N
        public virtual ICollection<Request> Requests { get; set; }
    }
}