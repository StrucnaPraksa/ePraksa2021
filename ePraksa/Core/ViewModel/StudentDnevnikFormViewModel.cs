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
    public class StudentDnevnikFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public int studentPraksaId { get; set; }
        [Required]
        public DateTime datum { get; set; }
        [Required]
        public string aktivnost { get; set; }
        [Required]
        public string linkovi { get; set; }
        [Required]
        public string dodatno { get; set; }
        public string komentar { get; set; }

        public string Action
        {
            get
            {
                //Expression<Func<StudentDnevnikController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<StudentDnevnikController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? null : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }

        public string Heading { get; internal set; }
        public IEnumerable<StudentDnevnik> StudentDnevniks { get; internal set; }
    }
}