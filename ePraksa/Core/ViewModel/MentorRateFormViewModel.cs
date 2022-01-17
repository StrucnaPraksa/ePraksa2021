using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;
using PracticeManagement.Controllers;
using PracticeManagement.Core.Helpers;
//using PracticeManagement.Core.Models;
using System.Linq.Expressions;
using System.Web.Mvc;
using System;
namespace PracticeManagement.Core.ViewModel
{
    public class MentorRateFormViewModel
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public int MentorsID { get; set; }
        [Required]
        public int StudentsID { get; set; }
        [Required]
        public int A1 { get; set; }
        [Required]
        public int A2 { get; set; }
        [Required]
        public int A3 { get; set; }
        [Required]
        public int A4 { get; set; }
        [Required]
        public int A5 { get; set; }

        [Required]
        public int InternshipsID { get; set; }
        public bool Activated { get; set; }
        [Required]
        public decimal Rate { get; set; }
        //public string Heading { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Mentor> Mentors { get; set; }



        public IEnumerable<MentorRate> MentorRates { get; set; }

        //public RegisterViewModel RegisterViewModel { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<MentorRatesController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<MentorRatesController, ActionResult>> create = (c => c.Create(this));
                //Expression<Func<StudentRatesController, ActionResult>> create = (c => c.Create(1));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        public IEnumerable<Internship> Internships { get; internal set; }
    }
}