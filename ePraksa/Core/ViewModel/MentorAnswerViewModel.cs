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
    public class MentorAnswerViewModel
    {
        public int Id { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int A5 { get; set; }
    }
}