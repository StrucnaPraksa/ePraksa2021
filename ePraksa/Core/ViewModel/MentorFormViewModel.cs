using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.ViewModel
{
    public class MentorFormViewModel
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int FirmId { get; set; }
        public IEnumerable<Firm> Firms { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int YearsOfExperience { get; set; }

        [Required]
        public string Competence { get; set; }

        [Required]
        public string CV { get; set; }

        public string Heading { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}