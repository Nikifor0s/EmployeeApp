using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeProject.Models;

namespace EmployeeProject.Models.Employees
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; } //question.Text
        

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Form> Forms { get; set; }

    }
}