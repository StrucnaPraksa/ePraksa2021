using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using PracticeManagement.Controllers;
using PracticeManagement.Core.Helpers;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class GradeFormViewModel
    {
        public int Id { get; set; }

        public int PracticeId { get; set; }

        public int MentorId { get; set; }

        public int ProfesorId { get; set; }

        public int StudentId { get; set; }

        public int FirmId { get; set; }
        public int PGrade1 { get; set; }
        public int PGrade2 { get; set; }
        public int PGrade3 { get; set; }
        public int MGrade1 { get; set; }
        public int MGrade2 { get; set; }
        public int MGrade3 { get; set; }
        public string ProfesorComment { get; set; }
        public string MentorComment { get; set; }




        public string Action
        {
            get
            {
                Expression<Func<GradesController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GradesController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        #region for dropdownlist

        public IEnumerable<SelectListItem> GendersList
        {
            get { return PracticeMgtHelpers.GenderToSelectList(); }
            set { }
        }

        public IEnumerable<PracticeType> PracticeTypes { get; set; }
        public string Heading { get; internal set; }
        public IEnumerable<Firm> Firms { get; set; }
        public IEnumerable<Student> Students { get;  set; }
        public IEnumerable<Profesor> Profesors { get; internal set; }
        public IEnumerable<Mentor> Mentors { get; internal set; }
        public IEnumerable<Internship> Internships { get; internal set; }

        #endregion
    }
}