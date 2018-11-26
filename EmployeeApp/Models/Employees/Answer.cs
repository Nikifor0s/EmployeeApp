﻿namespace EmployeeProject.Models.Employees
{
    //
    public class Answer
    {
        public enum Rating
        {
            Poor = 1,
            Fair,
            Satisfactory,
            Good,
            Excellent
        }

        //[Key]
        //[ForeignKey("Question")]
        //public int? QuestionID { get; set; }

        public int ID { get; set; }

        public int QuestionID { get; set; }

        public int PerformanceID { get; set; }

        public string Text { get; set; }

        public Rating? QuestionAnswer { get; set; }

        public virtual Question Question { get; set; }

        public virtual Performance Performance { get; set; }
    }
}